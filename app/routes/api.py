from flask import Blueprint, request, jsonify
from flask_login import login_required
from app import db
from app.models import Product, Batch, AccountMaster, AccountGroup, Invoice, InvoiceItem, ProductBarcode
from sqlalchemy import or_

api_bp = Blueprint('api', __name__)

# Product APIs
@api_bp.route('/products')
@login_required
def get_products():
    page = request.args.get('page', 1, type=int)
    per_page = request.args.get('per_page', 50, type=int)
    search = request.args.get('search', '')
    
    query = Product.query.filter_by(is_active=True)
    
    if search:
        query = query.filter(
            or_(
                Product.product_code.ilike(f'%{search}%'),
                Product.product_name.ilike(f'%{search}%'),
                Product.barcode.ilike(f'%{search}%')
            )
        )
    
    products = query.order_by(Product.product_name).paginate(page=page, per_page=per_page, error_out=False)
    
    return jsonify({
        'items': [{
            'id': p.id,
            'product_code': p.product_code,
            'product_name': p.product_name,
            'generic_name': p.generic_name,
            'mrp': float(p.mrp) if p.mrp else 0,
            'rate': float(p.rate) if p.rate else 0,
            'stock': p.current_stock,
            'barcode': p.barcode
        } for p in products.items],
        'total': products.total,
        'pages': products.pages,
        'current_page': products.page
    })

@api_bp.route('/all-products')
@login_required
def get_all_products():
    """Get all products for autocomplete (purchase/sales)"""
    search = request.args.get('q', '')
    query = Product.query.filter_by(is_active=True)
    
    if search:
        query = query.filter(
            or_(
                Product.product_code.ilike(f'%{search}%'),
                Product.product_name.ilike(f'%{search}%'),
                Product.generic_name.ilike(f'%{search}%')
            )
        )
    
    products = query.order_by(Product.product_name).limit(50).all()
    
    return jsonify([{
        'id': p.id,
        'product_code': p.product_code,
        'product_name': p.product_name,
        'generic_name': p.generic_name,
        'mrp': float(p.mrp) if p.mrp else 0,
        'rate': float(p.rate) if p.rate else 0,
        'stock': p.current_stock
    } for p in products])

@api_bp.route('/products/<int:id>')
@login_required
def get_product(id):
    product = Product.query.get_or_404(id)
    batches = Batch.query.filter_by(product_id=id).filter(Batch.available_qty > 0).order_by(Batch.expiry_date).all()
    
    return jsonify({
        'id': product.id,
        'product_code': product.product_code,
        'product_name': product.product_name,
        'generic_name': product.generic_name,
        'manufacturer': product.manufacturer,
        'mrp': float(product.mrp) if product.mrp else 0,
        'rate': float(product.rate) if product.rate else 0,
        'tax_perc': float(product.tax_perc) if product.tax_perc else 0,
        'discount_perc': float(product.discount_perc) if product.discount_perc else 0,
        'stock': product.current_stock,
        'batches': [{
            'id': b.id,
            'batch_no': b.batch_no,
            'expiry_date': b.expiry_date.isoformat() if b.expiry_date else None,
            'available_qty': b.available_qty,
            'sale_rate': float(b.sale_rate) if b.sale_rate else 0,
            'mrp': float(b.mrp) if b.mrp else 0
        } for b in batches]
    })

@api_bp.route('/products/barcode/<barcode>')
@login_required
def get_product_by_barcode(barcode):
    product = Product.query.filter_by(barcode=barcode, is_active=True).first()
    if not product:
        return jsonify({'error': 'Product not found'}), 404
    
    batch = Batch.query.filter_by(product_id=product.id).filter(Batch.available_qty > 0).order_by(Batch.expiry_date).first()
    
    return jsonify({
        'id': product.id,
        'product_code': product.product_code,
        'product_name': product.product_name,
        'mrp': float(product.mrp) if product.mrp else 0,
        'rate': float(product.rate) if product.rate else 0,
        'tax_perc': float(product.tax_perc) if product.tax_perc else 0,
        'batch_id': batch.id if batch else None,
        'batch_no': batch.batch_no if batch else None,
        'expiry_date': batch.expiry_date.isoformat() if batch and batch.expiry_date else None,
        'available_qty': batch.available_qty if batch else 0,
        'sale_rate': float(batch.sale_rate) if batch and batch.sale_rate else 0
    })

# Customer APIs
@api_bp.route('/customers')
@login_required
def get_customers():
    search = request.args.get('search', '')
    
    query = AccountMaster.query.filter_by(account_type='customer', is_active=True)
    
    if search:
        query = query.filter(
            or_(
                AccountMaster.account_code.ilike(f'%{search}%'),
                AccountMaster.account_name.ilike(f'%{search}%'),
                AccountMaster.mobile.ilike(f'%{search}%')
            )
        )
    
    customers = query.order_by(AccountMaster.account_name).limit(20).all()
    
    return jsonify([{
        'id': c.id,
        'account_code': c.account_code,
        'account_name': c.account_name,
        'mobile': c.mobile,
        'balance': float(c.balance) if c.balance else 0,
        'credit_limit': float(c.credit_limit) if c.credit_limit else 0,
        'discount_perc': float(c.discount_perc) if c.discount_perc else 0
    } for c in customers])

@api_bp.route('/customers/<int:id>')
@login_required
def get_customer(id):
    customer = AccountMaster.query.get_or_404(id)
    
    return jsonify({
        'id': customer.id,
        'account_code': customer.account_code,
        'account_name': customer.account_name,
        'address': customer.address,
        'city': customer.city,
        'mobile': customer.mobile,
        'phone': customer.phone,
        'email': customer.email,
        'gstin': customer.gstin,
        'balance': float(customer.balance) if customer.balance else 0,
        'credit_limit': float(customer.credit_limit) if customer.credit_limit else 0,
        'discount_perc': float(customer.discount_perc) if customer.discount_perc else 0
    })

# Supplier APIs
@api_bp.route('/suppliers')
@login_required
def get_suppliers():
    search = request.args.get('search', '')
    
    query = AccountMaster.query.filter_by(account_type='supplier', is_active=True)
    
    if search:
        query = query.filter(
            or_(
                AccountMaster.account_code.ilike(f'%{search}%'),
                AccountMaster.account_name.ilike(f'%{search}%'),
                AccountMaster.mobile.ilike(f'%{search}%')
            )
        )
    
    suppliers = query.order_by(AccountMaster.account_name).limit(20).all()
    
    return jsonify([{
        'id': s.id,
        'account_code': s.account_code,
        'account_name': s.account_name,
        'mobile': s.mobile,
        'balance': float(s.balance) if s.balance else 0
    } for s in suppliers])

# Invoice APIs
@api_bp.route('/invoices')
@login_required
def get_invoices():
    page = request.args.get('page', 1, type=int)
    per_page = request.args.get('per_page', 50, type=int)
    invoice_type = request.args.get('type', 'sale')
    
    invoices = Invoice.query.filter_by(invoice_type=invoice_type).order_by(
        Invoice.invoice_date.desc()
    ).paginate(page=page, per_page=per_page, error_out=False)
    
    return jsonify({
        'items': [{
            'id': i.id,
            'invoice_no': i.invoice_no,
            'invoice_date': i.invoice_date.isoformat(),
            'customer_name': i.customer.account_name if i.customer else 'N/A',
            'total_amount': float(i.total_amount),
            'payment_status': i.payment_status
        } for i in invoices.items],
        'total': invoices.total,
        'pages': invoices.pages
    })

@api_bp.route('/invoices/<int:id>')
@login_required
def get_invoice(id):
    invoice = Invoice.query.get_or_404(id)
    
    return jsonify({
        'id': invoice.id,
        'invoice_no': invoice.invoice_no,
        'invoice_date': invoice.invoice_date.isoformat(),
        'invoice_type': invoice.invoice_type,
        'customer': {
            'id': invoice.customer.id,
            'account_name': invoice.customer.account_name
        } if invoice.customer else None,
        'subtotal': float(invoice.subtotal),
        'discount_perc': float(invoice.discount_perc) if invoice.discount_perc else 0,
        'discount_amt': float(invoice.discount_amt) if invoice.discount_amt else 0,
        'tax_amt': float(invoice.tax_amt) if invoice.tax_amt else 0,
        'total_amount': float(invoice.total_amount),
        'payment_status': invoice.payment_status,
        'items': [{
            'product_name': item.product.product_name if item.product else 'N/A',
            'batch_no': item.batch_no,
            'quantity': item.quantity,
            'unit_rate': float(item.unit_rate),
            'amount': float(item.amount)
        } for item in invoice.items]
    })

# Batch APIs
@api_bp.route('/batches/product/<int:product_id>')
@login_required
def get_product_batches(product_id):
    batches = Batch.query.filter_by(product_id=product_id).filter(
        Batch.available_qty > 0
    ).order_by(Batch.expiry_date).all()
    
    return jsonify([{
        'id': b.id,
        'batch_no': b.batch_no,
        'expiry_date': b.expiry_date.isoformat() if b.expiry_date else None,
        'available_qty': b.available_qty,
        'sale_rate': float(b.sale_rate) if b.sale_rate else 0,
        'mrp': float(b.mrp) if b.mrp else 0,
        'purchase_rate': float(b.purchase_rate) if b.purchase_rate else 0
    } for b in batches])

# Dashboard stats
@api_bp.route('/dashboard/stats')
@login_required
def dashboard_stats():
    from datetime import datetime, timedelta
    from sqlalchemy import func
    
    today = datetime.utcnow().date()
    
    # Today's sales
    today_sales = db.session.query(func.sum(Invoice.total_amount)).filter(
        Invoice.invoice_type == 'sale',
        func.date(Invoice.invoice_date) == today,
        Invoice.is_cancelled == False
    ).scalar() or 0
    
    today_count = Invoice.query.filter(
        Invoice.invoice_type == 'sale',
        func.date(Invoice.invoice_date) == today,
        Invoice.is_cancelled == False
    ).count()
    
    # Month's sales
    month_start = today.replace(day=1)
    month_sales = db.session.query(func.sum(Invoice.total_amount)).filter(
        Invoice.invoice_type == 'sale',
        Invoice.invoice_date >= month_start,
        Invoice.is_cancelled == False
    ).scalar() or 0
    
    # Stock value
    stock_value = db.session.query(func.sum(Batch.available_qty * Batch.purchase_rate)).filter(
        Batch.available_qty > 0
    ).scalar() or 0
    
    # Low stock count
    low_stock = db.session.query(func.count(Product.id)).join(Batch
    ).filter(
        Product.is_active == True,
        Batch.available_qty <= Product.reorder_level
    ).scalar() or 0
    
    return jsonify({
        'today_sales': float(today_sales),
        'today_count': today_count,
        'month_sales': float(month_sales),
        'stock_value': float(stock_value),
        'low_stock': low_stock
    })

# Search API
@api_bp.route('/search')
@login_required
def search():
    query = request.args.get('q', '')
    search_type = request.args.get('type', 'all')
    
    if len(query) < 2:
        return jsonify({'results': []})
    
    results = []
    
    if search_type in ['all', 'products']:
        products = Product.query.filter(
            Product.is_active == True,
            or_(
                Product.product_code.ilike(f'%{query}%'),
                Product.product_name.ilike(f'%{query}%'),
                Product.barcode.ilike(f'%{query}%')
            )
        ).limit(10).all()
        
        for p in products:
            results.append({
                'type': 'product',
                'id': p.id,
                'title': p.product_name,
                'subtitle': p.product_code,
                'url': f'/products/{p.id}'
            })
    
    if search_type in ['all', 'customers']:
        customers = AccountMaster.query.filter(
            AccountMaster.account_type == 'customer',
            AccountMaster.is_active == True,
            or_(
                AccountMaster.account_code.ilike(f'%{query}%'),
                AccountMaster.account_name.ilike(f'%{query}%')
            )
        ).limit(10).all()
        
        for c in customers:
            results.append({
                'type': 'customer',
                'id': c.id,
                'title': c.account_name,
                'subtitle': c.account_code,
                'url': f'/customers/{c.id}'
            })
    
    if search_type in ['all', 'invoices']:
        invoices = Invoice.query.filter(
            Invoice.invoice_no.ilike(f'%{query}%')
        ).limit(10).all()
        
        for i in invoices:
            results.append({
                'type': 'invoice',
                'id': i.id,
                'title': i.invoice_no,
                'subtitle': f'{i.customer.account_name if i.customer else "N/A"} - ₹{i.total_amount}',
                'url': f'/sales/{i.id}'
            })
    
    return jsonify({'results': results})

# ============ Autocomplete APIs for Product Form ============

# Generic Name APIs
@api_bp.route('/generic-names/search')
@login_required
def search_generic_names():
    term = request.args.get('q', '').strip()
    if len(term) < 1:
        return jsonify([])
    
    generics = db.session.query(Product.generic_name).distinct().filter(
        Product.generic_name.ilike(f'%{term}%'),
        Product.generic_name != None,
        Product.generic_name != ''
    ).limit(20).all()
    
    return jsonify([g[0] for g in generics if g[0]])

@api_bp.route('/generic-names', methods=['POST'])
@login_required
def add_generic_name():
    data = request.get_json()
    name = data.get('name', '').strip()
    if not name:
        return jsonify({'error': 'Name is required'}), 400
    return jsonify({'success': True, 'name': name})

# Manufacturer APIs
@api_bp.route('/manufacturers/search')
@login_required
def search_manufacturers():
    term = request.args.get('q', '').strip()
    if len(term) < 1:
        return jsonify([])
    
    mans = db.session.query(Product.manufacturer).distinct().filter(
        Product.manufacturer.ilike(f'%{term}%'),
        Product.manufacturer != None,
        Product.manufacturer != ''
    ).limit(20).all()
    
    return jsonify([m[0] for m in mans if m[0]])

@api_bp.route('/manufacturers', methods=['POST'])
@login_required
def add_manufacturer():
    data = request.get_json()
    name = data.get('name', '').strip()
    if not name:
        return jsonify({'error': 'Name is required'}), 400
    return jsonify({'success': True, 'name': name})

# Product Type APIs
@api_bp.route('/product-types/search')
@login_required
def search_product_types():
    term = request.args.get('q', '').strip()
    product_types = ['Tablet', 'Capsule', 'Syrup', 'Injection', 'Cream/Ointment', 
                     'Drops', 'Inhaler', 'Granules', 'Powder', 'Other', 'Liquid',
                     'Suspension', 'Gel', 'Solution', 'Pessary', 'Suppository', 'Patch']
    
    if term:
        results = [pt for pt in product_types if term.lower() in pt.lower()]
    else:
        results = product_types
    
    return jsonify(results[:20])

@api_bp.route('/product-types', methods=['POST'])
@login_required
def add_product_type():
    data = request.get_json()
    name = data.get('name', '').strip()
    if not name:
        return jsonify({'error': 'Name is required'}), 400
    return jsonify({'success': True, 'name': name})

# Schedule APIs
@api_bp.route('/schedules/search')
@login_required
def search_schedules():
    term = request.args.get('q', '').strip()
    schedules = ['OTC', 'H', 'Sch-H', 'Sch-H1', 'Sch-X', 'G', 'Sch-G']
    
    if term:
        results = [s for s in schedules if term.lower() in s.lower()]
    else:
        results = schedules
    
    return jsonify(results[:20])

@api_bp.route('/schedules', methods=['POST'])
@login_required
def add_schedule():
    data = request.get_json()
    name = data.get('name', '').strip()
    if not name:
        return jsonify({'error': 'Name is required'}), 400
    return jsonify({'success': True, 'name': name})

# HSN Code APIs
@api_bp.route('/hsn-codes/search')
@login_required
def search_hsn_codes():
    term = request.args.get('q', '').strip()
    if len(term) < 1:
        return jsonify([])
    
    hsns = db.session.query(Product.hsn_code).distinct().filter(
        Product.hsn_code.ilike(f'%{term}%'),
        Product.hsn_code != None,
        Product.hsn_code != ''
    ).limit(20).all()
    
    return jsonify([h[0] for h in hsns if h[0]])

@api_bp.route('/hsn-codes', methods=['POST'])
@login_required
def add_hsn_code():
    data = request.get_json()
    name = data.get('name', '').strip()
    if not name:
        return jsonify({'error': 'Name is required'}), 400
    return jsonify({'success': True, 'name': name})

# Location/Rack APIs
@api_bp.route('/locations/search')
@login_required
def search_locations():
    term = request.args.get('q', '').strip()
    if len(term) < 1:
        return jsonify([])
    
    locations = db.session.query(Product.location).distinct().filter(
        Product.location.ilike(f'%{term}%'),
        Product.location != None,
        Product.location != ''
    ).limit(20).all()
    
    return jsonify([l[0] for l in locations if l[0]])

@api_bp.route('/locations', methods=['POST'])
@login_required
def add_location():
    data = request.get_json()
    name = data.get('name', '').strip()
    if not name:
        return jsonify({'error': 'Name is required'}), 400
    return jsonify({'success': True, 'name': name})

# Pack Type APIs
@api_bp.route('/pack-types/search')
@login_required
def search_pack_types():
    term = request.args.get('q', '').strip()
    if len(term) < 1:
        return jsonify([])
    
    packs = db.session.query(Product.pack_type).distinct().filter(
        Product.pack_type.ilike(f'%{term}%'),
        Product.pack_type != None,
        Product.pack_type != ''
    ).limit(20).all()
    
    return jsonify([p[0] for p in packs if p[0]])

@api_bp.route('/pack-types', methods=['POST'])
@login_required
def add_pack_type():
    data = request.get_json()
    name = data.get('name', '').strip()
    if not name:
        return jsonify({'error': 'Name is required'}), 400
    return jsonify({'success': True, 'name': name})

# Low Stock & Near Expiry Alert
@api_bp.route('/alerts/stock')
@login_required
def get_stock_alerts():
    from datetime import datetime, timedelta
    
    alerts = []
    
    # Low stock products
    low_stock_products = Product.query.filter_by(is_active=True).all()
    for product in low_stock_products:
        total_stock = product.current_stock
        if total_stock <= product.min_stock:
            alerts.append({
                'type': 'low_stock',
                'product_id': product.id,
                'product_name': product.product_name,
                'current_stock': total_stock,
                'min_stock': product.min_stock,
                'message': f'Low Stock: {product.product_name} ({total_stock} left)'
            })
    
    # Near expiry products (within 30 days)
    today = datetime.utcnow().date()
    expiry_threshold = today + timedelta(days=30)
    
    near_expiry_batches = Batch.query.join(Product).filter(
        Batch.expiry_date != None,
        Batch.expiry_date <= expiry_threshold,
        Batch.expiry_date >= today,
        Batch.available_qty > 0,
        Product.is_active == True
    ).order_by(Batch.expiry_date).limit(20).all()
    
    for batch in near_expiry_batches:
        days_left = (batch.expiry_date - today).days
        alerts.append({
            'type': 'near_expiry',
            'product_id': batch.product_id,
            'product_name': batch.product.product_name,
            'batch_no': batch.batch_no,
            'expiry_date': batch.expiry_date.strftime('%d-%m-%Y'),
            'days_left': days_left,
            'quantity': batch.available_qty,
            'message': f'Near Expiry: {batch.product.product_name} ({batch.batch_no}) - {days_left} days'
        })
    
    return jsonify(alerts)
# ============ Barcode APIs ============

@api_bp.route("/barcodes/search")
@login_required
def search_barcodes():
    term = request.args.get("q", "").strip()
    if len(term) < 1:
        return jsonify([])
    
    barcodes = db.session.query(ProductBarcode.barcode, Product.product_name, Product.product_code).join(
        Product, ProductBarcode.product_id == Product.id
    ).filter(
        ProductBarcode.barcode.ilike(f"%{term}%")
    ).limit(20).all()
    
    return jsonify([{"barcode": b[0], "product_name": b[1], "product_code": b[2]} for b in barcodes])

@api_bp.route("/barcodes/check")
@login_required
def check_barcode():
    barcode = request.args.get("barcode", "").strip()
    if not barcode:
        return jsonify({"exists": False, "available": True})
    
    existing = ProductBarcode.query.filter_by(barcode=barcode).first()
    if existing:
        product = Product.query.get(existing.product_id)
        return jsonify({
            "exists": True, "available": False,
            "product_id": existing.product_id,
            "product_name": product.product_name if product else "Unknown",
            "product_code": product.product_code if product else "Unknown"
        })
    return jsonify({"exists": False, "available": True})

@api_bp.route("/barcodes/add", methods=["POST"])
@login_required
def add_barcode():
    data = request.get_json()
    barcode = data.get("barcode", "").strip()
    product_id = data.get("product_id")
    
    if not barcode:
        return jsonify({"success": False, "error": "Barcode is required"}), 400
    if not product_id:
        return jsonify({"success": False, "error": "Product is required"}), 400
    
    existing = ProductBarcode.query.filter_by(barcode=barcode).first()
    if existing:
        product = Product.query.get(existing.product_id)
        return jsonify({"success": False, "error": f"This barcode is already linked to: {product.product_name} ({product.product_code})"}), 400
    
    product = Product.query.get(product_id)
    if not product:
        return jsonify({"success": False, "error": "Product not found"}), 404
    
    is_primary = ProductBarcode.query.filter_by(product_id=product_id).count() == 0
    new_barcode = ProductBarcode(barcode=barcode, product_id=product_id, is_primary=is_primary)
    db.session.add(new_barcode)
    db.session.commit()
    
    return jsonify({"success": True, "barcode": barcode, "product_id": product_id, "product_name": product.product_name, "is_primary": is_primary})

@api_bp.route("/barcodes/delete/<int:id>", methods=["DELETE"])
@login_required
def delete_barcode(id):
    barcode = ProductBarcode.query.get_or_404(id)
    product_id = barcode.product_id
    barcode_str = barcode.barcode
    db.session.delete(barcode)
    db.session.commit()
    
    if ProductBarcode.query.filter_by(product_id=product_id).count() > 0:
        first_barcode = ProductBarcode.query.filter_by(product_id=product_id).first()
        first_barcode.is_primary = True
        db.session.commit()
    
    return jsonify({"success": True, "message": f"Barcode {barcode_str} deleted"})

@api_bp.route("/barcodes/product/<int:product_id>")
@login_required
def get_product_barcodes(product_id):
    barcodes = ProductBarcode.query.filter_by(product_id=product_id).order_by(ProductBarcode.is_primary.desc()).all()
    return jsonify([{"id": b.id, "barcode": b.barcode, "is_primary": b.is_primary, "created_at": b.created_at.strftime("%d-%m-%Y")} for b in barcodes])
