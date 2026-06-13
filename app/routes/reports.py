from flask import Blueprint, render_template, request, jsonify
from flask_login import login_required
from app import db
from app.models import Invoice, InvoiceItem, Purchase, PurchaseItem, Product, Batch, AccountMaster, Ledger, Payment
from sqlalchemy import func, and_, or_, extract
from datetime import datetime, timedelta
from collections import defaultdict

reports_bp = Blueprint('reports', __name__)

@reports_bp.route('/')
@reports_bp.route('/sales')
@login_required
def sales():
    from_date = request.args.get('from_date', datetime.utcnow().strftime('%Y-%m-%d'))
    to_date = request.args.get('to_date', datetime.utcnow().strftime('%Y-%m-%d'))
    report_type = request.args.get('type', 'summary')
    
    from_dt = datetime.strptime(from_date, '%Y-%m-%d')
    to_dt = datetime.strptime(to_date, '%Y-%m-%d') + timedelta(days=1)
    
    if report_type == 'summary':
        # Sales summary
        total_sales = db.session.query(func.sum(Invoice.total_amount)).filter(
            Invoice.invoice_type == 'sale',
            Invoice.invoice_date >= from_dt,
            Invoice.invoice_date < to_dt,
            Invoice.is_cancelled == False
        ).scalar() or 0
        
        sales_count = Invoice.query.filter(
            Invoice.invoice_type == 'sale',
            Invoice.invoice_date >= from_dt,
            Invoice.invoice_date < to_dt,
            Invoice.is_cancelled == False
        ).count()
        
        cash_sales = db.session.query(func.sum(Invoice.total_amount)).filter(
            Invoice.invoice_type == 'sale',
            Invoice.sales_type == 'cash',
            Invoice.invoice_date >= from_dt,
            Invoice.invoice_date < to_dt,
            Invoice.is_cancelled == False
        ).scalar() or 0
        
        credit_sales = db.session.query(func.sum(Invoice.total_amount)).filter(
            Invoice.invoice_type == 'sale',
            Invoice.sales_type == 'credit',
            Invoice.invoice_date >= from_dt,
            Invoice.invoice_date < to_dt,
            Invoice.is_cancelled == False
        ).scalar() or 0
        
        return render_template('reports/sales_summary.html',
                             from_date=from_date,
                             to_date=to_date,
                             total_sales=total_sales,
                             sales_count=sales_count,
                             cash_sales=cash_sales,
                             credit_sales=credit_sales)
    
    elif report_type == 'productwise':
        # Product-wise sales
        results = db.session.query(
            Product.product_code,
            Product.product_name,
            func.sum(InvoiceItem.quantity).label('total_qty'),
            func.sum(InvoiceItem.amount).label('total_amount')
        ).join(InvoiceItem, InvoiceItem.product_id == Product.id
        ).join(Invoice, Invoice.id == InvoiceItem.invoice_id
        ).filter(
            Invoice.invoice_type == 'sale',
            Invoice.invoice_date >= from_dt,
            Invoice.invoice_date < to_dt,
            Invoice.is_cancelled == False
        ).group_by(Product.id).order_by(func.sum(InvoiceItem.amount).desc()).all()
        
        return render_template('reports/sales_productwise.html',
                             from_date=from_date,
                             to_date=to_date,
                             results=results)
    
    elif report_type == 'customerwise':
        # Customer-wise sales
        results = db.session.query(
            AccountMaster.account_code,
            AccountMaster.account_name,
            func.sum(Invoice.total_amount).label('total_amount'),
            func.count(Invoice.id).label('invoice_count')
        ).join(Invoice, Invoice.customer_id == AccountMaster.id
        ).filter(
            Invoice.invoice_type == 'sale',
            Invoice.invoice_date >= from_dt,
            Invoice.invoice_date < to_dt,
            Invoice.is_cancelled == False,
            AccountMaster.account_type == 'customer'
        ).group_by(AccountMaster.id).order_by(func.sum(Invoice.total_amount).desc()).all()
        
        return render_template('reports/sales_customerwise.html',
                             from_date=from_date,
                             to_date=to_date,
                             results=results)
    
    return render_template('reports/sales.html', from_date=from_date, to_date=to_date)

@reports_bp.route('/purchase')
@login_required
def purchase():
    from_date = request.args.get('from_date', datetime.utcnow().strftime('%Y-%m-%d'))
    to_date = request.args.get('to_date', datetime.utcnow().strftime('%Y-%m-%d'))
    report_type = request.args.get('type', 'summary')
    
    from_dt = datetime.strptime(from_date, '%Y-%m-%d')
    to_dt = datetime.strptime(to_date, '%Y-%m-%d') + timedelta(days=1)
    
    if report_type == 'summary':
        total_purchase = db.session.query(func.sum(Purchase.total_amount)).filter(
            Purchase.purchase_date >= from_dt,
            Purchase.purchase_date < to_dt,
            Purchase.is_cancelled == False
        ).scalar() or 0
        
        purchase_count = Purchase.query.filter(
            Purchase.purchase_date >= from_dt,
            Purchase.purchase_date < to_dt,
            Purchase.is_cancelled == False
        ).count()
        
        return render_template('reports/purchase_summary.html',
                             from_date=from_date,
                             to_date=to_date,
                             total_purchase=total_purchase,
                             purchase_count=purchase_count)
    
    elif report_type == 'productwise':
        results = db.session.query(
            Product.product_code,
            Product.product_name,
            func.sum(PurchaseItem.quantity).label('total_qty'),
            func.sum(PurchaseItem.amount).label('total_amount')
        ).join(PurchaseItem, PurchaseItem.product_id == Product.id
        ).join(Purchase, Purchase.id == PurchaseItem.purchase_id
        ).filter(
            Purchase.purchase_date >= from_dt,
            Purchase.purchase_date < to_dt,
            Purchase.is_cancelled == False
        ).group_by(Product.id).order_by(func.sum(PurchaseItem.amount).desc()).all()
        
        return render_template('reports/purchase_productwise.html',
                             from_date=from_date,
                             to_date=to_date,
                             results=results)
    
    return render_template('reports/purchase.html', from_date=from_date, to_date=to_date)

@reports_bp.route('/stock')
@login_required
def stock():
    category = request.args.get('category', '')
    
    query = db.session.query(
        Product,
        func.coalesce(func.sum(Batch.available_qty), 0).label('total_stock'),
        func.coalesce(func.sum(Batch.available_qty * Batch.purchase_rate), 0).label('stock_value')
    ).outerjoin(Batch, and_(Batch.product_id == Product.id, Batch.available_qty > 0)
    ).filter(Product.is_active == True)
    
    if category:
        query = query.filter(Product.category_id == category)
    
    results = query.group_by(Product.id).order_by(Product.product_name).all()
    
    total_stock_value = sum(r.stock_value for r in results)
    total_items = len(results)
    
    return render_template('reports/stock.html',
                         results=results,
                         total_stock_value=total_stock_value,
                         total_items=total_items)

@reports_bp.route('/expiry')
@login_required
def expiry():
    days = request.args.get('days', 90, type=int)
    cutoff_date = datetime.utcnow().date() + timedelta(days=days)
    
    results = db.session.query(
        Product.product_code,
        Product.product_name,
        Batch.batch_no,
        Batch.expiry_date,
        Batch.available_qty,
        Batch.mrp,
        func.days(Batch.expiry_date - func.current_date()).label('days_to_expire')
    ).join(Batch, Batch.product_id == Product.id
    ).filter(
        Batch.expiry_date != None,
        Batch.expiry_date <= cutoff_date,
        Batch.available_qty > 0
    ).order_by(Batch.expiry_date).all()
    
    return render_template('reports/expiry.html', results=results, days=days)

@reports_bp.route('/ledger/<int:account_id>')
@login_required
def ledger(account_id):
    account = AccountMaster.query.get_or_404(account_id)
    from_date = request.args.get('from_date', (datetime.utcnow().replace(day=1)).strftime('%Y-%m-%d'))
    to_date = request.args.get('to_date', datetime.utcnow().strftime('%Y-%m-%d'))
    
    from_dt = datetime.strptime(from_date, '%Y-%m-%d')
    to_dt = datetime.strptime(to_date, '%Y-%m-%d') + timedelta(days=1)
    
    # Get opening balance
    opening = db.session.query(func.sum(Ledger.debit) - func.sum(Ledger.credit)).filter(
        Ledger.account_id == account_id,
        Ledger.ledger_date < from_dt
    ).scalar() or 0
    
    # Get transactions
    transactions = Ledger.query.filter(
        Ledger.account_id == account_id,
        Ledger.ledger_date >= from_dt,
        Ledger.ledger_date < to_dt
    ).order_by(Ledger.ledger_date).all()
    
    return render_template('reports/ledger.html',
                         account=account,
                         from_date=from_date,
                         to_date=to_date,
                         opening=opening,
                         transactions=transactions)

@reports_bp.route('/trial-balance')
@login_required
def trial_balance():
    from_date = request.args.get('from_date', (datetime.utcnow().replace(day=1)).strftime('%Y-%m-%d'))
    to_date = request.args.get('to_date', datetime.utcnow().strftime('%Y-%m-%d'))
    
    from_dt = datetime.strptime(from_date, '%Y-%m-%d')
    to_dt = datetime.strptime(to_date, '%Y-%m-%d') + timedelta(days=1)
    
    # Get all accounts with balances
    accounts = db.session.query(
        AccountMaster.id,
        AccountMaster.account_code,
        AccountMaster.account_name,
        AccountMaster.account_type,
        func.sum(Ledger.debit).label('debit'),
        func.sum(Ledger.credit).label('credit')
    ).outerjoin(Ledger, and_(
        Ledger.account_id == AccountMaster.id,
        Ledger.ledger_date >= from_dt,
        Ledger.ledger_date < to_dt
    )).filter(
        AccountMaster.is_active == True
    ).group_by(AccountMaster.id).having(
        or_(
            func.sum(Ledger.debit) != None,
            func.sum(Ledger.credit) != None
        )
    ).order_by(AccountMaster.account_type, AccountMaster.account_name).all()
    
    return render_template('reports/trial_balance.html',
                         from_date=from_date,
                         to_date=to_date,
                         accounts=accounts)

@reports_bp.route('/gst')
@login_required
def gst():
    from_date = request.args.get('from_date', datetime.utcnow().strftime('%Y-%m-%d'))
    to_date = request.args.get('to_date', datetime.utcnow().strftime('%Y-%m-%d'))
    
    from_dt = datetime.strptime(from_date, '%Y-%m-%d')
    to_dt = datetime.strptime(to_date, '%Y-%m-%d') + timedelta(days=1)
    
    # Get sales with tax
    sales = db.session.query(
        Invoice.invoice_no,
        Invoice.invoice_date,
        AccountMaster.account_name,
        AccountMaster.gstin,
        Invoice.subtotal,
        Invoice.tax_amt,
        Invoice.total_amount
    ).join(AccountMaster, Invoice.customer_id == AccountMaster.id
    ).filter(
        Invoice.invoice_type == 'sale',
        Invoice.invoice_date >= from_dt,
        Invoice.invoice_date < to_dt,
        Invoice.is_cancelled == False
    ).order_by(Invoice.invoice_date).all()
    
    total_taxable = sum(s.subtotal for s in sales)
    total_gst = sum(s.tax_amt for s in sales)
    
    return render_template('reports/gst.html',
                         from_date=from_date,
                         to_date=to_date,
                         sales=sales,
                         total_taxable=total_taxable,
                         total_gst=total_gst)

@reports_bp.route('/profit')
@login_required
def profit():
    from_date = request.args.get('from_date', (datetime.utcnow().replace(day=1)).strftime('%Y-%m-%d'))
    to_date = request.args.get('to_date', datetime.utcnow().strftime('%Y-%m-%d'))
    
    from_dt = datetime.strptime(from_date, '%Y-%m-%d')
    to_dt = datetime.strptime(to_date, '%Y-%m-%d') + timedelta(days=1)
    
    # Calculate profit from sales - cost
    results = db.session.query(
        Product.product_code,
        Product.product_name,
        func.sum(InvoiceItem.quantity).label('qty_sold'),
        func.sum(InvoiceItem.amount).label('sales_amount'),
        func.sum(InvoiceItem.quantity * InvoiceItem.unit_rate * 0.7).label('estimated_cost')  # Rough estimate
    ).join(InvoiceItem, InvoiceItem.product_id == Product.id
    ).join(Invoice, Invoice.id == InvoiceItem.invoice_id
    ).filter(
        Invoice.invoice_type == 'sale',
        Invoice.invoice_date >= from_dt,
        Invoice.invoice_date < to_dt,
        Invoice.is_cancelled == False
    ).group_by(Product.id).order_by(func.sum(InvoiceItem.amount).desc()).limit(50).all()
    
    total_sales = sum(r.sales_amount for r in results)
    total_profit = sum(r.sales_amount - r.estimated_cost for r in results)
    
    return render_template('reports/profit.html',
                         from_date=from_date,
                         to_date=to_date,
                         results=results,
                         total_sales=total_sales,
                         total_profit=total_profit)

@reports_bp.route('/dashboard-stats')
@login_required
def dashboard_stats():
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
    
    # This month
    month_start = today.replace(day=1)
    month_sales = db.session.query(func.sum(Invoice.total_amount)).filter(
        Invoice.invoice_type == 'sale',
        Invoice.invoice_date >= month_start,
        Invoice.is_cancelled == False
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
        'low_stock': low_stock
    })