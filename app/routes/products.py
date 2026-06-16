from flask import Blueprint, render_template, request, redirect, url_for, flash, jsonify
from flask_login import login_required, current_user
from app import db
from app.models import Product, Category, Batch, Rack, Tax, StockAdjustment, StockAdjustmentItem, ProductPackaging, ProductBarcode, HSNCodeMaster, GenericMaster, ManufacturerMaster, ProductTypeMaster
from sqlalchemy import or_
from datetime import datetime
import uuid
import json

products_bp = Blueprint('products', __name__)

@products_bp.route('/')
@login_required
def list():
    page = request.args.get('page', 1, type=int)
    per_page = request.args.get('per_page', 50, type=int)
    search = request.args.get('search', '')
    category = request.args.get('category', '')
    stock_filter = request.args.get('stock_filter', '')
    
    query = Product.query.filter_by(is_active=True)
    
    if search:
        query = query.filter(
            or_(
                Product.product_code.ilike(f'%{search}%'),
                Product.product_name.ilike(f'%{search}%'),
                Product.generic_name.ilike(f'%{search}%'),
                Product.manufacturer.ilike(f'%{search}%')
            )
        )
    
    if category:
        query = query.filter_by(category_id=category)
    
    products = query.order_by(Product.product_name).paginate(page=page, per_page=per_page, error_out=False)
    
    categories = Category.query.filter_by(is_active=True).order_by(Category.category_name).all()
    
    return render_template('products/list.html', 
                         products=products,
                         categories=categories,
                         search=search,
                         selected_category=category,
                         stock_filter=stock_filter)

@products_bp.route('/<int:id>')
@login_required
def view(id):
    product = Product.query.get_or_404(id)
    batches = Batch.query.filter_by(product_id=id).filter(Batch.available_qty > 0).order_by(Batch.expiry_date).all()
    packaging = ProductPackaging.query.filter_by(product_id=id, is_active=True).all()
    
    return render_template('products/view.html', product=product, batches=batches, packaging=packaging)

@products_bp.route('/add', methods=['GET', 'POST'])
@login_required
def add():
    if request.method == 'POST':
        product_code = request.form.get('product_code', '').strip()
        product_name = request.form.get('product_name', '').strip()
        
        if not product_name:
            flash('Product name is required.', 'error')
            return redirect(url_for('products.add'))
        
        # Check for duplicate product name
        if Product.query.filter(Product.product_name.ilike(product_name)).first():
            flash('Product Already Created', 'error')
            return redirect(url_for('products.add'))
        
        # Auto-generate product code if empty
        if not product_code:
            # Generate code from first 3 letters of product name (uppercase)
            prefix = ''.join(c for c in product_name[:3].upper() if c.isalpha())
            if len(prefix) < 3:
                prefix = 'PRD'  # Default prefix if name too short
            
            # Find the highest existing number for this prefix
            existing_codes = Product.query.filter(
                Product.product_code.like(f'{prefix}%')
            ).all()
            
            max_num = 0
            for p in existing_codes:
                try:
                    num = int(p.product_code[len(prefix):])
                    max_num = max(max_num, num)
                except:
                    pass
            
            # Generate new code with increment
            product_code = f'{prefix}{str(max_num + 1).zfill(3)}'
        else:
            # Check if provided code already exists
            if Product.query.filter_by(product_code=product_code).first():
                flash('Product code already exists.', 'error')
                return redirect(url_for('products.add'))
        
        product = Product(
            product_code=product_code,
            product_name=product_name,
            generic_name=request.form.get('generic_name', '').strip(),
            manufacturer=request.form.get('manufacturer', '').strip(),
            schedule=request.form.get('schedule', ''),
            product_type=request.form.get('product_type', ''),
            pack_type=request.form.get('pack_type', ''),
            pack_qty=request.form.get('pack_qty', 1, type=int),
            mrp=request.form.get('mrp', 0, type=float),
            rate=request.form.get('rate', 0, type=float),
            ptr=request.form.get('ptr', 0, type=float),
            pts=request.form.get('pts', 0, type=float),
            discount_perc=request.form.get('discount_perc', 0, type=float),
            tax_perc=request.form.get('tax_perc', 0, type=float),
            min_stock=request.form.get('min_stock', 0, type=int),
            max_stock=request.form.get('max_stock', 0, type=int),
            reorder_level=request.form.get('reorder_level', 0, type=int),
            hsn_code=request.form.get('hsn_code', ''),
            location=request.form.get('location', ''),
            category_id=request.form.get('category_id', type=int)
        )
        
        db.session.add(product)
        db.session.flush()
        
        # Add barcodes
        barcodes_json = request.form.get('barcodes_json', '[]')
        try:
            barcodes = json.loads(barcodes_json)
            for i, barcode_str in enumerate(barcodes):
                barcode_str = barcode_str.strip()
                if barcode_str:
                    existing = ProductBarcode.query.filter_by(barcode=barcode_str).first()
                    if not existing:
                        pb = ProductBarcode(
                            barcode=barcode_str,
                            product_id=product.id,
                            is_primary=(i == 0)
                        )
                        db.session.add(pb)
        except:
            pass
        
        # Add packaging configurations
        packaging_json = request.form.get('packaging_json', '[]')
        print(f"DEBUG add(): packaging_json = '{packaging_json}'")
        print(f"DEBUG add(): Request form keys = {list(request.form.keys())}")
        try:
            packaging_data = json.loads(packaging_json)
            print(f"DEBUG add(): packaging_data = {packaging_data}")
            for pkg in packaging_data:
                pack_type = pkg.get('pack_type', '').strip()
                pack_qty = int(pkg.get('pack_qty', 1))
                if pack_type and pack_qty > 0:
                    pp = ProductPackaging(
                        product_id=product.id,
                        pack_type=pack_type,
                        pack_qty=pack_qty,
                        is_default_sale=pkg.get('is_default_sale', False),
                        is_default_purchase=pkg.get('is_default_purchase', False)
                    )
                    db.session.add(pp)
                    print(f"DEBUG add(): Added packaging - {pack_type} x {pack_qty}")
        except Exception as e:
            print(f"DEBUG ERROR add(): {str(e)}")
            import traceback
            traceback.print_exc()
            pass
        
        db.session.commit()
        flash(f'Product {product.product_name} added successfully.', 'success')
        return redirect(url_for('products.list'))
    
    categories = Category.query.filter_by(is_active=True).order_by(Category.category_name).all()
    taxes = Tax.query.filter_by(is_active=True).order_by(Tax.tax_perc).all()
    hsn_codes = HSNCodeMaster.query.order_by(HSNCodeMaster.hsn_code).all()
    generics = GenericMaster.query.filter_by(is_active=True).order_by(GenericMaster.generic_name).all()
    manufacturers = ManufacturerMaster.query.filter_by(is_active=True).order_by(ManufacturerMaster.manufacturer_name).all()
    product_types = ProductTypeMaster.query.filter_by(is_active=True).order_by(ProductTypeMaster.type_name).all()
    return render_template('products/add.html', categories=categories, taxes=taxes, hsn_codes=hsn_codes, generics=generics, manufacturers=manufacturers, product_types=product_types, is_edit=False)

@products_bp.route('/<int:id>/edit', methods=['GET', 'POST'])
@login_required
def edit(id):
    product = Product.query.get_or_404(id)
    
    # Load all packaging (including inactive) for the edit form
    all_packaging = ProductPackaging.query.filter_by(product_id=id).all()
    print(f"DEBUG edit(): Loading {len(all_packaging)} packaging records for product {id}")
    for pkg in all_packaging:
        print(f"DEBUG edit():   - {pkg.pack_type}: qty={pkg.pack_qty}")
    
    if request.method == 'POST':
        product.product_name = request.form.get('product_name', '').strip()
        product.generic_name = request.form.get('generic_name', '').strip()
        product.manufacturer = request.form.get('manufacturer', '').strip()
        product.schedule = request.form.get('schedule', '')
        product.product_type = request.form.get('product_type', '')
        product.pack_type = request.form.get('pack_type', '')
        product.pack_qty = request.form.get('pack_qty', 1, type=int)
        product.mrp = request.form.get('mrp', 0, type=float)
        product.rate = request.form.get('rate', 0, type=float)
        product.ptr = request.form.get('ptr', 0, type=float)
        product.pts = request.form.get('pts', 0, type=float)
        product.discount_perc = request.form.get('discount_perc', 0, type=float)
        product.tax_perc = request.form.get('tax_perc', 0, type=float)
        product.min_stock = request.form.get('min_stock', 0, type=int)
        product.max_stock = request.form.get('max_stock', 0, type=int)
        product.reorder_level = request.form.get('reorder_level', 0, type=int)
        product.hsn_code = request.form.get('hsn_code', '')
        product.barcode = request.form.get('barcode', '')
        product.location = request.form.get('location', '')
        product.category_id = request.form.get('category_id', type=int)
        product.updated_at = datetime.utcnow()
        
        # Update packaging configurations
        packaging_json = request.form.get('packaging_json', '[]')
        print(f"DEBUG edit POST: packaging_json = '{packaging_json}'")
        print(f"DEBUG edit POST: Request form keys = {list(request.form.keys())}")
        try:
            # Soft delete existing packaging
            existing = ProductPackaging.query.filter_by(product_id=product.id).all()
            for pkg in existing:
                pkg.is_active = False
            
            packaging_data = json.loads(packaging_json)
            print(f"DEBUG edit POST: packaging_data = {packaging_data}")
            for pkg in packaging_data:
                pack_type = pkg.get('pack_type', '').strip()
                pack_qty = int(pkg.get('pack_qty', 1))
                if pack_type and pack_qty > 0:
                    pp = ProductPackaging(
                        product_id=product.id,
                        pack_type=pack_type,
                        pack_qty=pack_qty,
                        is_default_sale=pkg.get('is_default_sale', False),
                        is_default_purchase=pkg.get('is_default_purchase', False),
                        is_active=True
                    )
                    db.session.add(pp)
                    print(f"DEBUG edit POST: Added packaging - {pack_type} x {pack_qty}")
        except Exception as e:
            print(f"DEBUG ERROR edit POST: {str(e)}")
            import traceback
            traceback.print_exc()
            pass
        
        db.session.commit()
        flash('Product updated successfully.', 'success')
        return redirect(url_for('products.view', id=product.id))
    
    categories = Category.query.filter_by(is_active=True).order_by(Category.category_name).all()
    taxes = Tax.query.filter_by(is_active=True).order_by(Tax.tax_perc).all()
    hsn_codes = HSNCodeMaster.query.order_by(HSNCodeMaster.hsn_code).all()
    generics = GenericMaster.query.filter_by(is_active=True).order_by(GenericMaster.generic_name).all()
    manufacturers = ManufacturerMaster.query.filter_by(is_active=True).order_by(ManufacturerMaster.manufacturer_name).all()
    product_types = ProductTypeMaster.query.filter_by(is_active=True).order_by(ProductTypeMaster.type_name).all()
    return render_template('products/add.html', product=product, all_packaging=all_packaging, categories=categories, taxes=taxes, hsn_codes=hsn_codes, generics=generics, manufacturers=manufacturers, product_types=product_types, is_edit=True)

@products_bp.route('/<int:id>/delete', methods=['POST'])
@login_required
def delete(id):
    product = Product.query.get_or_404(id)
    product.is_active = False
    db.session.commit()
    flash('Product deactivated successfully.', 'success')
    return redirect(url_for('products.list'))

@products_bp.route('/search-json')
@login_required
def search_json():
    query = request.args.get('q', '')
    if len(query) < 2:
        return jsonify([])
    
    products = Product.query.filter(
        Product.is_active == True,
        or_(
            Product.product_code.ilike(f'%{query}%'),
            Product.product_name.ilike(f'%{query}%'),
            Product.barcode.ilike(f'%{query}%')
        )
    ).limit(20).all()
    
    results = []
    for p in products:
        results.append({
            'id': p.id,
            'product_code': p.product_code,
            'product_name': p.product_name,
            'generic_name': p.generic_name,
            'mrp': float(p.mrp) if p.mrp else 0,
            'rate': float(p.rate) if p.rate else 0,
            'stock': p.current_stock,
            'barcode': p.barcode
        })
    
    return jsonify(results)

@products_bp.route('/barcode/<barcode>')
@login_required
def by_barcode(barcode):
    product = Product.query.filter_by(barcode=barcode, is_active=True).first()
    if product:
        batch = Batch.query.filter_by(product_id=product.id).filter(Batch.available_qty > 0).first()
        return jsonify({
            'id': product.id,
            'product_code': product.product_code,
            'product_name': product.product_name,
            'mrp': float(product.mrp) if product.mrp else 0,
            'batch_id': batch.id if batch else None,
            'batch_no': batch.batch_no if batch else None,
            'expiry_date': batch.expiry_date.isoformat() if batch and batch.expiry_date else None,
            'available_qty': batch.available_qty if batch else 0,
            'sale_rate': float(batch.sale_rate) if batch and batch.sale_rate else 0
        })
    return jsonify({'error': 'Product not found'}), 404

# Categories
@products_bp.route('/categories')
@login_required
def categories():
    categories = Category.query.order_by(Category.category_name).all()
    return render_template('products/categories.html', categories=categories)

@products_bp.route('/categories/add', methods=['POST'])
@login_required
def add_category():
    category_code = request.form.get('category_code', '').strip()
    category_name = request.form.get('category_name', '').strip()
    
    if not category_code or not category_name:
        flash('Category code and name are required.', 'error')
        return redirect(url_for('products.categories'))
    
    if Category.query.filter_by(category_code=category_code).first():
        flash('Category code already exists.', 'error')
        return redirect(url_for('products.categories'))
    
    category = Category(
        category_code=category_code,
        category_name=category_name,
        parent_id=request.form.get('parent_id', type=int),
        description=request.form.get('description', '')
    )
    
    db.session.add(category)
    db.session.commit()
    
    flash('Category added successfully.', 'success')
    return redirect(url_for('products.categories'))

@products_bp.route('/categories/<int:id>/delete', methods=['POST'])
@login_required
def delete_category(id):
    category = Category.query.get_or_404(id)
    db.session.delete(category)
    db.session.commit()
    flash('Category deleted successfully.', 'success')
    return redirect(url_for('products.categories'))

@products_bp.route('/categories/<int:id>/update', methods=['POST'])
@login_required
def update_category(id):
    category = Category.query.get_or_404(id)
    category.category_code = request.form.get('category_code', '').strip()
    category.category_name = request.form.get('category_name', '').strip()
    category.description = request.form.get('description', '')
    db.session.commit()
    flash('Category updated successfully.', 'success')
    return redirect(url_for('products.categories'))

# Tax rates
@products_bp.route('/tax-rates')
@login_required
def tax_rates():
    taxes = Tax.query.order_by(Tax.tax_perc).all()
    return render_template('products/tax_rates.html', taxes=taxes)

@products_bp.route('/tax-rates/add', methods=['POST'])
@login_required
def add_tax():
    tax_name = request.form.get('tax_name', '').strip()
    tax_perc = request.form.get('tax_perc', request.form.get('tax_percentage', 0), type=float)
    
    tax = Tax(
        tax_name=tax_name,
        tax_perc=tax_perc,
        tax_type=request.form.get('tax_type', 'GST'),
        cgst_perc=request.form.get('cgst_perc', 0, type=float),
        sgst_perc=request.form.get('sgst_perc', 0, type=float),
        igst_perc=request.form.get('igst_perc', 0, type=float)
    )
    
    db.session.add(tax)
    db.session.commit()
    
    flash('Tax rate added successfully.', 'success')
    return redirect(url_for('products.tax_rates'))

@products_bp.route('/tax-rates/<int:id>/delete', methods=['POST'])
@login_required
def delete_tax(id):
    tax = Tax.query.get_or_404(id)
    db.session.delete(tax)
    db.session.commit()
    flash('Tax rate deleted successfully.', 'success')
    return redirect(url_for('products.tax_rates'))

@products_bp.route('/tax-rates/<int:id>/update', methods=['POST'])
@login_required
def update_tax(id):
    tax = Tax.query.get_or_404(id)
    tax.tax_name = request.form.get('tax_name', '').strip()
    tax.tax_perc = request.form.get('tax_perc', 0, type=float)
    tax.tax_type = request.form.get('tax_type', 'GST')
    tax.cgst_perc = request.form.get('cgst_perc', 0, type=float)
    tax.sgst_perc = request.form.get('sgst_perc', 0, type=float)
    tax.igst_perc = request.form.get('igst_perc', 0, type=float)
    db.session.commit()
    flash('Tax rate updated successfully.', 'success')
    return redirect(url_for('products.tax_rates'))


# API: Get product packaging
@products_bp.route('/api/<int:product_id>/packaging')
@login_required
def get_product_packaging(product_id):
    """Get all packaging configurations for a product"""
    # Don't filter by is_active for the edit page
    packaging = ProductPackaging.query.filter_by(product_id=product_id).all()
    return jsonify([{
        'id': p.id,
        'pack_type': p.pack_type,
        'pack_qty': p.pack_qty,
        'is_default_sale': p.is_default_sale,
        'is_default_purchase': p.is_default_purchase
    } for p in packaging])


# API: Get default packaging for sales/purchase
@products_bp.route('/api/<int:product_id>/packaging/default')
@login_required
def get_default_packaging(product_id):
    """Get default sale and purchase packaging for a product"""
    sale_pack = ProductPackaging.get_default_sale(product_id)
    purchase_pack = ProductPackaging.get_default_purchase(product_id)
    
    return jsonify({
        'sale': {
            'id': sale_pack.id,
            'pack_type': sale_pack.pack_type,
            'pack_qty': sale_pack.pack_qty
        } if sale_pack else None,
        'purchase': {
            'id': purchase_pack.id,
            'pack_type': purchase_pack.pack_type,
            'pack_qty': purchase_pack.pack_qty
        } if purchase_pack else None
    })
# Redirect routes for menu - use masters blueprint
@products_bp.route('/generics')
@login_required
def generics():
    from app.routes.masters import masters_bp
    return redirect(url_for('masters.generics'))

@products_bp.route('/manufacturers')
@login_required
def manufacturers():
    return redirect(url_for('masters.manufacturers'))

@products_bp.route('/product-types')
@login_required
def product_types():
    return redirect(url_for('masters.product_types'))

@products_bp.route('/hsn-codes')
@login_required
def hsn_codes():
    return redirect(url_for('masters.hsn_codes'))
