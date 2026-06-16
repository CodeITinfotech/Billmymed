from flask import Blueprint, render_template, request, jsonify, make_response
from flask_login import login_required
from app import db
from app.models import Invoice, InvoiceItem, Purchase, PurchaseItem, Product, Batch, AccountMaster, Ledger, Payment, ShortList
from sqlalchemy import func, and_, or_, extract
from datetime import datetime, timedelta
from collections import defaultdict
from app.utils.pdf_generator import generate_pdf_report

reports_bp = Blueprint('reports', __name__)

@reports_bp.route('/')
@reports_bp.route('/sales')
@login_required
def sales():
    from_date = request.args.get('from_date', datetime.utcnow().strftime('%Y-%m-%d'))
    to_date = request.args.get('to_date', datetime.utcnow().strftime('%Y-%m-%d'))
    report_type = request.args.get('type', 'summary')
    sales_type = request.args.get('sales_type', '')
    
    from_dt = datetime.strptime(from_date, '%Y-%m-%d')
    to_dt = datetime.strptime(to_date, '%Y-%m-%d') + timedelta(days=1)
    
    # Build query with filters
    query = Invoice.query.filter(
        Invoice.invoice_type == 'sale',
        Invoice.invoice_date >= from_dt,
        Invoice.invoice_date < to_dt,
        Invoice.is_cancelled == False
    )
    
    if sales_type:
        query = query.filter(Invoice.sales_type == sales_type)
    
    sales = query.order_by(Invoice.invoice_date.desc()).all()
    sales_count = len(sales)
    
    if report_type == 'summary':
        # Sales summary
        total_sales = db.session.query(func.sum(Invoice.total_amount)).filter(
            Invoice.invoice_type == 'sale',
            Invoice.invoice_date >= from_dt,
            Invoice.invoice_date < to_dt,
            Invoice.is_cancelled == False
        ).scalar() or 0
        
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
                             credit_sales=credit_sales,
                             sales=sales,
                             sales_type=sales_type)
    
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


@reports_bp.route('/sales/pdf')
@login_required
def sales_pdf():
    from_date = request.args.get('from_date', datetime.utcnow().strftime('%Y-%m-%d'))
    to_date = request.args.get('to_date', datetime.utcnow().strftime('%Y-%m-%d'))
    sales_type = request.args.get('sales_type', '')
    
    from_dt = datetime.strptime(from_date, '%Y-%m-%d')
    to_dt = datetime.strptime(to_date, '%Y-%m-%d') + timedelta(days=1)
    
    # Build query with filters
    query = Invoice.query.filter(
        Invoice.invoice_type == 'sale',
        Invoice.invoice_date >= from_dt,
        Invoice.invoice_date < to_dt,
        Invoice.is_cancelled == False
    ).order_by(Invoice.invoice_date.desc())
    
    if sales_type:
        query = query.filter(Invoice.sales_type == sales_type)
    
    sales = query.all()
    
    # Calculate totals
    total_sales = sum(s.total_amount for s in sales)
    cash_sales = sum(s.total_amount for s in sales if s.sales_type == 'cash')
    credit_sales = sum(s.total_amount for s in sales if s.sales_type == 'credit')
    
    # Filters HTML
    filters_html = f'''
    <div class="filters">
        <strong>Filters:</strong> From: {from_date} | To: {to_date}
        {" | Sales Type: " + sales_type.upper() if sales_type else ""}
    </div>
    '''
    
    # Summary HTML
    summary_html = f'''
    <div class="summary-cards">
        <div class="summary-card">
            <h5>Total Sales</h5>
            <div class="value">₹{total_sales:,.2f}</div>
        </div>
        <div class="summary-card success">
            <h5>Cash Sales</h5>
            <div class="value">₹{cash_sales:,.2f}</div>
        </div>
        <div class="summary-card warning">
            <h5>Credit Sales</h5>
            <div class="value">₹{credit_sales:,.2f}</div>
        </div>
        <div class="summary-card">
            <h5>Invoice Count</h5>
            <div class="value">{len(sales)}</div>
        </div>
    </div>
    '''
    
    # Table HTML
    rows_html = ''
    for s in sales:
        customer_name = s.customer.account_name if s.customer else 'Walk-in'
        badge_class = 'success' if s.sales_type == 'cash' else 'warning' if s.sales_type == 'credit' else 'danger'
        payment_status = s.payment_status.upper()
        rows_html += f'''
        <tr>
            <td>{s.invoice_no}</td>
            <td>{s.invoice_date.strftime('%d-%m-%Y %H:%M')}</td>
            <td>{customer_name}</td>
            <td><span class="badge badge-{badge_class}">{s.sales_type.upper()}</span></td>
            <td class="text-right">₹{s.subtotal:,.2f}</td>
            <td class="text-right">₹{s.discount_amt:,.2f}</td>
            <td class="text-right">₹{s.tax_amt:,.2f}</td>
            <td class="text-right text-bold">₹{s.total_amount:,.2f}</td>
            <td>{payment_status}</td>
        </tr>
        '''
    
    if not rows_html:
        rows_html = '<tr><td colspan="9" class="text-center">No records found</td></tr>'
    
    table_html = f'''
    <table>
        <thead>
            <tr>
                <th>Invoice #</th>
                <th>Date</th>
                <th>Customer</th>
                <th>Type</th>
                <th class="text-right">Subtotal</th>
                <th class="text-right">Discount</th>
                <th class="text-right">Tax</th>
                <th class="text-right">Total</th>
                <th>Payment</th>
            </tr>
        </thead>
        <tbody>
            {rows_html}
        </tbody>
    </table>
    '''
    
    return generate_pdf_report(
        'Sales Summary Report',
        filters_html,
        summary_html,
        table_html,
        f'sales_report_{from_date}_to_{to_date}'
    )

@reports_bp.route('/purchase')
@login_required
def purchase():
    from_date = request.args.get('from_date', datetime.utcnow().strftime('%Y-%m-%d'))
    to_date = request.args.get('to_date', datetime.utcnow().strftime('%Y-%m-%d'))
    report_type = request.args.get('type', 'summary')
    
    from_dt = datetime.strptime(from_date, '%Y-%m-%d')
    to_dt = datetime.strptime(to_date, '%Y-%m-%d') + timedelta(days=1)
    
    # Get purchases for the period
    purchases = Purchase.query.filter(
        Purchase.purchase_date >= from_dt,
        Purchase.purchase_date < to_dt,
        Purchase.is_cancelled == False
    ).order_by(Purchase.purchase_date.desc()).all()
    
    total_purchase = db.session.query(func.sum(Purchase.total_amount)).filter(
        Purchase.purchase_date >= from_dt,
        Purchase.purchase_date < to_dt,
        Purchase.is_cancelled == False
    ).scalar() or 0
    
    purchase_count = len(purchases)
    
    return render_template('reports/purchase.html',
                         from_date=from_date,
                         to_date=to_date,
                         total_purchase=total_purchase,
                         purchase_count=purchase_count,
                         purchases=purchases,
                         summary={
                             'total_purchase': total_purchase,
                             'bill_count': purchase_count,
                             'total_discount': 0,
                             'total_tax': 0,
                             'paid_amount': 0,
                             'pending_amount': 0,
                             'returns': 0,
                             'supplier_count': len(set([p.supplier_id for p in purchases])),
                             'subtotal': total_purchase
                         })


@reports_bp.route('/purchase/pdf')
@login_required
def purchase_pdf():
    from_date = request.args.get('from_date', datetime.utcnow().strftime('%Y-%m-%d'))
    to_date = request.args.get('to_date', datetime.utcnow().strftime('%Y-%m-%d'))
    
    from_dt = datetime.strptime(from_date, '%Y-%m-%d')
    to_dt = datetime.strptime(to_date, '%Y-%m-%d') + timedelta(days=1)
    
    purchases = Purchase.query.filter(
        Purchase.purchase_date >= from_dt,
        Purchase.purchase_date < to_dt,
        Purchase.is_cancelled == False
    ).order_by(Purchase.purchase_date.desc()).all()
    
    total_purchase = sum(p.total_amount for p in purchases)
    suppliers = set([p.supplier_id for p in purchases if p.supplier_id])
    
    # Filters HTML
    filters_html = f'''
    <div class="filters">
        <strong>Filters:</strong> From: {from_date} | To: {to_date}
    </div>
    '''
    
    # Summary HTML
    summary_html = f'''
    <div class="summary-cards">
        <div class="summary-card">
            <h5>Total Purchase</h5>
            <div class="value">₹{total_purchase:,.2f}</div>
        </div>
        <div class="summary-card success">
            <h5>Bill Count</h5>
            <div class="value">{len(purchases)}</div>
        </div>
        <div class="summary-card">
            <h5>Suppliers</h5>
            <div class="value">{len(suppliers)}</div>
        </div>
    </div>
    '''
    
    # Table HTML
    rows_html = ''
    for p in purchases:
        supplier_name = p.supplier.account_name if p.supplier else 'N/A'
        rows_html += f'''
        <tr>
            <td>{p.purchase_no}</td>
            <td>{p.purchase_date.strftime('%d-%m-%Y')}</td>
            <td>{supplier_name}</td>
            <td class="text-right">₹{p.subtotal:,.2f}</td>
            <td class="text-right">₹{p.discount_amt:,.2f}</td>
            <td class="text-right">₹{p.tax_amt:,.2f}</td>
            <td class="text-right text-bold">₹{p.total_amount:,.2f}</td>
        </tr>
        '''
    
    if not rows_html:
        rows_html = '<tr><td colspan="7" class="text-center">No records found</td></tr>'
    
    table_html = f'''
    <table>
        <thead>
            <tr>
                <th>Purchase #</th>
                <th>Date</th>
                <th>Supplier</th>
                <th class="text-right">Subtotal</th>
                <th class="text-right">Discount</th>
                <th class="text-right">Tax</th>
                <th class="text-right">Total</th>
            </tr>
        </thead>
        <tbody>
            {rows_html}
        </tbody>
    </table>
    '''
    
    return generate_pdf_report(
        'Purchase Report',
        filters_html,
        summary_html,
        table_html,
        f'purchase_report_{from_date}_to_{to_date}'
    )

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
                         total_items=total_items,
                         category=category)


@reports_bp.route('/stock/pdf')
@login_required
def stock_pdf():
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
    total_qty = sum(r.total_stock for r in results)
    
    # Filters HTML
    filters_html = f'''
    <div class="filters">
        <strong>Filters:</strong> Category: {category if category else 'All'}
    </div>
    '''
    
    # Summary HTML
    summary_html = f'''
    <div class="summary-cards">
        <div class="summary-card">
            <h5>Total Items</h5>
            <div class="value">{total_items}</div>
        </div>
        <div class="summary-card success">
            <h5>Total Quantity</h5>
            <div class="value">{total_qty:,.0f}</div>
        </div>
        <div class="summary-card warning">
            <h5>Stock Value</h5>
            <div class="value">₹{total_stock_value:,.2f}</div>
        </div>
    </div>
    '''
    
    # Table HTML
    rows_html = ''
    for r in results:
        stock_class = 'danger' if r.total_stock <= r.reorder_level else 'success' if r.total_stock > r.reorder_level * 2 else 'warning'
        rows_html += f'''
        <tr>
            <td>{r.Product.product_code}</td>
            <td>{r.Product.product_name}</td>
            <td>{r.Product.category.category_name if r.Product.category else 'N/A'}</td>
            <td class="text-right">{r.total_stock:,.0f}</td>
            <td class="text-right">₹{r.Product.mrp:,.2f}</td>
            <td class="text-right">₹{r.stock_value:,.2f}</td>
        </tr>
        '''
    
    if not rows_html:
        rows_html = '<tr><td colspan="6" class="text-center">No records found</td></tr>'
    
    table_html = f'''
    <table>
        <thead>
            <tr>
                <th>Code</th>
                <th>Product Name</th>
                <th>Category</th>
                <th class="text-right">Stock</th>
                <th class="text-right">MRP</th>
                <th class="text-right">Value</th>
            </tr>
        </thead>
        <tbody>
            {rows_html}
        </tbody>
    </table>
    '''
    
    return generate_pdf_report(
        'Stock Report',
        filters_html,
        summary_html,
        table_html,
        f'stock_report_{datetime.utcnow().strftime("%Y%m%d")}'
    )

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
        (func.julianday(Batch.expiry_date) - func.julianday('now')).label('days_to_expire')
    ).join(Batch, Batch.product_id == Product.id
    ).filter(
        Batch.expiry_date != None,
        Batch.expiry_date <= cutoff_date,
        Batch.available_qty > 0
    ).order_by(Batch.expiry_date).all()
    
    return render_template('reports/expiry.html', results=results, days=days)


@reports_bp.route('/expiry/pdf')
@login_required
def expiry_pdf():
    days = request.args.get('days', 90, type=int)
    cutoff_date = datetime.utcnow().date() + timedelta(days=days)
    
    results = db.session.query(
        Product.product_code,
        Product.product_name,
        Batch.batch_no,
        Batch.expiry_date,
        Batch.available_qty,
        Batch.mrp,
        (func.julianday(Batch.expiry_date) - func.julianday('now')).label('days_to_expire')
    ).join(Batch, Batch.product_id == Product.id
    ).filter(
        Batch.expiry_date != None,
        Batch.expiry_date <= cutoff_date,
        Batch.available_qty > 0
    ).order_by(Batch.expiry_date).all()
    
    total_value = sum(r.available_qty * r.mrp for r in results)
    expiring_soon = len([r for r in results if r.days_to_expire <= 30])
    
    # Filters HTML
    filters_html = f'''
    <div class="filters">
        <strong>Filters:</strong> Expiring within {days} days
    </div>
    '''
    
    # Summary HTML
    summary_html = f'''
    <div class="summary-cards">
        <div class="summary-card danger">
            <h5>Expiring Items</h5>
            <div class="value">{len(results)}</div>
        </div>
        <div class="summary-card warning">
            <h5>Expiring Soon (30 days)</h5>
            <div class="value">{expiring_soon}</div>
        </div>
        <div class="summary-card">
            <h5>Total Value</h5>
            <div class="value">₹{total_value:,.2f}</div>
        </div>
    </div>
    '''
    
    # Table HTML
    rows_html = ''
    for r in results:
        badge_class = 'danger' if r.days_to_expire <= 7 else 'warning' if r.days_to_expire <= 30 else ''
        badge_text = f'{int(r.days_to_expire)} days' if r.days_to_expire else 'Expired'
        rows_html += f'''
        <tr>
            <td>{r.product_code}</td>
            <td>{r.product_name}</td>
            <td>{r.batch_no}</td>
            <td>{r.expiry_date.strftime('%d-%m-%Y')}</td>
            <td class="text-center"><span class="badge badge-{badge_class}">{badge_text}</span></td>
            <td class="text-right">{r.available_qty}</td>
            <td class="text-right">₹{r.mrp:,.2f}</td>
            <td class="text-right">₹{r.available_qty * r.mrp:,.2f}</td>
        </tr>
        '''
    
    if not rows_html:
        rows_html = '<tr><td colspan="8" class="text-center">No records found</td></tr>'
    
    table_html = f'''
    <table>
        <thead>
            <tr>
                <th>Code</th>
                <th>Product</th>
                <th>Batch</th>
                <th>Expiry Date</th>
                <th class="text-center">Days Left</th>
                <th class="text-right">Qty</th>
                <th class="text-right">MRP</th>
                <th class="text-right">Value</th>
            </tr>
        </thead>
        <tbody>
            {rows_html}
        </tbody>
    </table>
    '''
    
    return generate_pdf_report(
        'Expiry Report',
        filters_html,
        summary_html,
        table_html,
        f'expiry_report_{datetime.utcnow().strftime("%Y%m%d")}'
    )

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
                         total_gst=total_gst,
                         report_type=request.args.get('report_type', 'summary'),
                         tax_type=request.args.get('tax_type', 'sales'),
                         sales_breakdown={},
                         purchase_breakdown={},
                         transactions=[],
                         summary={
                             'taxable_sales': total_taxable,
                             'taxable_purchase': 0,
                             'total_gst': total_gst,
                             'cgst': total_gst / 2,
                             'sgst': total_gst / 2,
                             'igst': 0,
                             'count': len(sales),
                             'output_gst': total_gst,
                             'input_gst': 0,
                             'net_gst': total_gst
                         })


@reports_bp.route('/gst/pdf')
@login_required
def gst_pdf():
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
    cgst = total_gst / 2
    sgst = total_gst / 2
    
    # Filters HTML
    filters_html = f'''
    <div class="filters">
        <strong>Filters:</strong> From: {from_date} | To: {to_date}
    </div>
    '''
    
    # Summary HTML
    summary_html = f'''
    <div class="summary-cards">
        <div class="summary-card">
            <h5>Taxable Sales</h5>
            <div class="value">₹{total_taxable:,.2f}</div>
        </div>
        <div class="summary-card success">
            <h5>Total GST</h5>
            <div class="value">₹{total_gst:,.2f}</div>
        </div>
        <div class="summary-card warning">
            <h5>CGST</h5>
            <div class="value">₹{cgst:,.2f}</div>
        </div>
        <div class="summary-card warning">
            <h5>SGST</h5>
            <div class="value">₹{sgst:,.2f}</div>
        </div>
    </div>
    '''
    
    # Table HTML
    rows_html = ''
    for s in sales:
        rows_html += f'''
        <tr>
            <td>{s.invoice_no}</td>
            <td>{s.invoice_date.strftime('%d-%m-%Y')}</td>
            <td>{s.account_name}</td>
            <td>{s.gstin or 'N/A'}</td>
            <td class="text-right">₹{s.subtotal:,.2f}</td>
            <td class="text-right">₹{s.tax_amt:,.2f}</td>
            <td class="text-right text-bold">₹{s.total_amount:,.2f}</td>
        </tr>
        '''
    
    if not rows_html:
        rows_html = '<tr><td colspan="7" class="text-center">No records found</td></tr>'
    
    table_html = f'''
    <table>
        <thead>
            <tr>
                <th>Invoice #</th>
                <th>Date</th>
                <th>Customer</th>
                <th>GSTIN</th>
                <th class="text-right">Taxable</th>
                <th class="text-right">GST</th>
                <th class="text-right">Total</th>
            </tr>
        </thead>
        <tbody>
            {rows_html}
        </tbody>
    </table>
    '''
    
    return generate_pdf_report(
        'GST Report',
        filters_html,
        summary_html,
        table_html,
        f'gst_report_{from_date}_to_{to_date}'
    )


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
    invoice_count = len(set(r.product_code for r in results))  # Approximate
    items_sold = sum(r.qty_sold for r in results)
    
    summary = {
        'gross_sales': total_sales,
        'cost_of_goods': total_sales - total_profit,
        'gross_profit': total_profit,
        'profit_margin': (total_profit / total_sales * 100) if total_sales > 0 else 0,
        'invoice_count': invoice_count,
        'items_sold': items_sold,
        'returns': 0,
        'discount_given': 0
    }
    
    profit_data = [{
        'product_code': r.product_code,
        'product_name': r.product_name,
        'qty_sold': r.qty_sold,
        'sales_amount': r.sales_amount,
        'cost': r.estimated_cost,
        'profit': r.sales_amount - r.estimated_cost,
        'margin': ((r.sales_amount - r.estimated_cost) / r.sales_amount * 100) if r.sales_amount > 0 else 0
    } for r in results]
    
    return render_template('reports/profit.html',
                         from_date=from_date,
                         to_date=to_date,
                         results=results,
                         total_sales=total_sales,
                         total_profit=total_profit,
                         summary=summary,
                         profit_data=profit_data)


@reports_bp.route('/profit/pdf')
@login_required
def profit_pdf():
    from_date = request.args.get('from_date', (datetime.utcnow().replace(day=1)).strftime('%Y-%m-%d'))
    to_date = request.args.get('to_date', datetime.utcnow().strftime('%Y-%m-%d'))
    
    from_dt = datetime.strptime(from_date, '%Y-%m-%d')
    to_dt = datetime.strptime(to_date, '%Y-%m-%d') + timedelta(days=1)
    
    results = db.session.query(
        Product.product_code,
        Product.product_name,
        func.sum(InvoiceItem.quantity).label('qty_sold'),
        func.sum(InvoiceItem.amount).label('sales_amount'),
        func.sum(InvoiceItem.quantity * InvoiceItem.unit_rate * 0.7).label('estimated_cost')
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
    total_cost = sum(r.estimated_cost for r in results)
    profit_margin = (total_profit / total_sales * 100) if total_sales > 0 else 0
    
    # Filters HTML
    filters_html = f'''
    <div class="filters">
        <strong>Filters:</strong> From: {from_date} | To: {to_date}
    </div>
    '''
    
    # Summary HTML
    summary_html = f'''
    <div class="summary-cards">
        <div class="summary-card">
            <h5>Gross Sales</h5>
            <div class="value">₹{total_sales:,.2f}</div>
        </div>
        <div class="summary-card success">
            <h5>Gross Profit</h5>
            <div class="value">₹{total_profit:,.2f}</div>
        </div>
        <div class="summary-card warning">
            <h5>Profit Margin</h5>
            <div class="value">{profit_margin:.1f}%</div>
        </div>
        <div class="summary-card">
            <h5>Cost of Goods</h5>
            <div class="value">₹{total_cost:,.2f}</div>
        </div>
    </div>
    '''
    
    # Table HTML
    rows_html = ''
    for r in results:
        profit = r.sales_amount - r.estimated_cost
        margin = (profit / r.sales_amount * 100) if r.sales_amount > 0 else 0
        margin_class = 'success' if margin > 20 else 'warning' if margin > 10 else 'danger'
        rows_html += f'''
        <tr>
            <td>{r.product_code}</td>
            <td>{r.product_name}</td>
            <td class="text-right">{r.qty_sold:,.0f}</td>
            <td class="text-right">₹{r.sales_amount:,.2f}</td>
            <td class="text-right">₹{r.estimated_cost:,.2f}</td>
            <td class="text-right text-bold">₹{profit:,.2f}</td>
            <td class="text-right"><span class="badge badge-{margin_class}">{margin:.1f}%</span></td>
        </tr>
        '''
    
    if not rows_html:
        rows_html = '<tr><td colspan="7" class="text-center">No records found</td></tr>'
    
    table_html = f'''
    <table>
        <thead>
            <tr>
                <th>Code</th>
                <th>Product</th>
                <th class="text-right">Qty Sold</th>
                <th class="text-right">Sales</th>
                <th class="text-right">Cost</th>
                <th class="text-right">Profit</th>
                <th class="text-right">Margin</th>
            </tr>
        </thead>
        <tbody>
            {rows_html}
        </tbody>
    </table>
    '''
    
    return generate_pdf_report(
        'Profit Report',
        filters_html,
        summary_html,
        table_html,
        f'profit_report_{from_date}_to_{to_date}'
    )

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

@reports_bp.route('/shortlist')
@login_required
def shortlist_report():
    """Short Listed Items Report"""
    items = db.session.query(ShortList, Product).join(
        Product, ShortList.product_id == Product.id
    ).filter(ShortList.is_ordered == False).order_by(ShortList.created_at.desc()).all()
    
    shortlist_count = len(items)
    return render_template('reports/shortlist.html', items=items, shortlist_count=shortlist_count)