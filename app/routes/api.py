from flask import Blueprint, request, jsonify
from flask_login import login_required
from app import db
from app.models import Product, Batch, AccountMaster, Invoice, InvoiceItem
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