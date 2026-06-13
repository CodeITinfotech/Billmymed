from flask import Blueprint, render_template, request, redirect, url_for, flash, jsonify
from flask_login import login_required, current_user
from app import db
from app.models import Product, Category, Batch, Rack, Tax, StockAdjustment, StockAdjustmentItem
from sqlalchemy import or_
from datetime import datetime
import uuid

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
    
    return render_template('products/view.html', product=product, batches=batches)

@products_bp.route('/add', methods=['GET', 'POST'])
@login_required
def add():
    if request.method == 'POST':
        product_code = request.form.get('product_code', '').strip()
        product_name = request.form.get('product_name', '').strip()
        
        if not product_code or not product_name:
            flash('Product code and name are required.', 'error')
            return redirect(url_for('products.add'))
        
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
            barcode=request.form.get('barcode', ''),
            location=request.form.get('location', ''),
            category_id=request.form.get('category_id', type=int)
        )
        
        db.session.add(product)
        db.session.commit()
        
        flash(f'Product {product.product_name} added successfully.', 'success')
        return redirect(url_for('products.list'))
    
    categories = Category.query.filter_by(is_active=True).order_by(Category.category_name).all()
    return render_template('products/add.html', categories=categories)

@products_bp.route('/<int:id>/edit', methods=['GET', 'POST'])
@login_required
def edit(id):
    product = Product.query.get_or_404(id)
    
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
        
        db.session.commit()
        flash('Product updated successfully.', 'success')
        return redirect(url_for('products.view', id=product.id))
    
    categories = Category.query.filter_by(is_active=True).order_by(Category.category_name).all()
    return render_template('products/edit.html', product=product, categories=categories)

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
    tax_perc = request.form.get('tax_perc', 0, type=float)
    
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