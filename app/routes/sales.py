from flask import Blueprint, render_template, request, redirect, url_for, flash, jsonify
from flask_login import login_required, current_user
from app import db
from app.models import Invoice, InvoiceItem, Product, Batch, AccountMaster, Ledger, Doctor, Prescription, Tax
from sqlalchemy import func, and_
from datetime import datetime, timedelta
import uuid

sales_bp = Blueprint('sales', __name__)

def generate_invoice_no(invoice_type='sale'):
    prefix = 'SI'
    if invoice_type == 'sale_return':
        prefix = 'SR'
    elif invoice_type == 'emergency':
        prefix = 'ES'
    
    today = datetime.utcnow()
    # Format: DD-MM-YY-00001
    date_str = today.strftime('%d-%m-%y')
    
    # Get last invoice number for today with same prefix
    last_invoice = Invoice.query.filter(
        Invoice.invoice_no.like(f'{prefix}{date_str}%')
    ).order_by(Invoice.id.desc()).first()
    
    if last_invoice:
        # Extract the last 5 digits (e.g., "00001")
        last_num = int(last_invoice.invoice_no[-5:])
        new_num = last_num + 1
    else:
        new_num = 1
    
    return f'{prefix}{date_str}-{str(new_num).zfill(5)}'

@sales_bp.route('/')
@login_required
def list():
    page = request.args.get('page', 1, type=int)
    per_page = request.args.get('per_page', 50, type=int)
    search = request.args.get('search', '')
    from_date = request.args.get('from_date', '')
    to_date = request.args.get('to_date', '')
    status = request.args.get('status', '')
    
    query = Invoice.query.filter_by(invoice_type='sale')
    
    if search:
        query = query.join(AccountMaster, Invoice.customer_id == AccountMaster.id).filter(
            or_(
                Invoice.invoice_no.ilike(f'%{search}%'),
                AccountMaster.account_name.ilike(f'%{search}%'),
                AccountMaster.mobile.ilike(f'%{search}%')
            )
        )
    
    if from_date:
        query = query.filter(Invoice.invoice_date >= datetime.strptime(from_date, '%Y-%m-%d'))
    if to_date:
        query = query.filter(Invoice.invoice_date <= datetime.strptime(to_date, '%Y-%m-%d') + timedelta(days=1))
    if status:
        query = query.filter(Invoice.payment_status == status)
    
    invoices = query.order_by(Invoice.invoice_date.desc()).paginate(page=page, per_page=per_page, error_out=False)
    
    return render_template('sales/list.html', 
                         invoices=invoices,
                         search=search,
                         from_date=from_date,
                         to_date=to_date,
                         status=status)

@sales_bp.route('/new')
@login_required
def new():
    invoice_no = generate_invoice_no()
    doctors = Doctor.query.filter_by(is_active=True).order_by(Doctor.doctor_name).all()
    return render_template('sales/new.html', invoice_no=invoice_no, doctors=doctors)

@sales_bp.route('/create', methods=['POST'])
@login_required
def create():
    try:
        invoice_no = generate_invoice_no()
        sales_type = request.form.get('sales_type', 'cash')
        
        customer_id = request.form.get('customer_id', type=int)
        if not customer_id:
            # Create walk-in customer if not selected
            customer = AccountMaster.query.filter_by(account_code='WALKIN').first()
            if not customer:
                customer = AccountMaster(
                    account_code='WALKIN',
                    account_name='Walk-in Customer',
                    account_type='customer',
                    is_active=True
                )
                db.session.add(customer)
                db.session.commit()
            customer_id = customer.id
        
        invoice = Invoice(
            invoice_no=invoice_no,
            invoice_type='sale',
            invoice_date=datetime.utcnow(),
            customer_id=customer_id,
            sales_type=sales_type,
            doctor_id=request.form.get('doctor_id', type=int),
            prescription_no=request.form.get('prescription_no', ''),
            subtotal=0,
            discount_perc=request.form.get('discount_perc', 0, type=float),
            discount_amt=request.form.get('discount_amt', 0, type=float),
            tax_amt=request.form.get('tax_amt', 0, type=float),
            round_off=request.form.get('round_off', 0, type=float),
            total_amount=request.form.get('total_amount', 0, type=float),
            cash_amount=request.form.get('cash_amount', 0, type=float),
            card_amount=request.form.get('card_amount', 0, type=float),
            gpay_amount=request.form.get('gpay_amount', 0, type=float),
            online_amount=request.form.get('online_amount', 0, type=float),
            credit_amount=request.form.get('credit_amount', 0, type=float),
            return_amount=request.form.get('return_amount', 0, type=float),
            payment_status=request.form.get('payment_status', 'paid'),
            remarks=request.form.get('remarks', ''),
            user_id=current_user.id
        )
        
        db.session.add(invoice)
        db.session.flush()
        
        # Process items
        product_ids = request.form.getlist('product_id', type=int)
        batch_ids = request.form.getlist('batch_id', type=int)
        quantities = request.form.getlist('quantity', type=int)
        free_qtys = request.form.getlist('free_qty', type=int)
        rates = request.form.getlist('rate', type=float)
        mrp_list = request.form.getlist('mrp', type=float)
        discount_percs = request.form.getlist('item_discount_perc', type=float)
        tax_percs = request.form.getlist('item_tax_perc', type=float)
        amounts = request.form.getlist('amount', type=float)
        
        subtotal = 0
        for i, product_id in enumerate(product_ids):
            batch = Batch.query.get(batch_ids[i]) if batch_ids[i] else None
            
            item = InvoiceItem(
                invoice_id=invoice.id,
                product_id=product_id,
                batch_id=batch_ids[i] if batch_ids[i] else None,
                batch_no=request.form.getlist('batch_no')[i] if i < len(request.form.getlist('batch_no')) else '',
                expiry_date=datetime.strptime(request.form.getlist('expiry_date')[i], '%Y-%m-%d').date() if i < len(request.form.getlist('expiry_date')) and request.form.getlist('expiry_date')[i] else None,
                quantity=quantities[i],
                free_qty=free_qtys[i] if i < len(free_qtys) else 0,
                unit_rate=rates[i],
                mrp=mrp_list[i] if i < len(mrp_list) else None,
                discount_perc=discount_percs[i] if i < len(discount_percs) else 0,
                tax_perc=tax_percs[i] if i < len(tax_percs) else 0,
                amount=amounts[i]
            )
            
            db.session.add(item)
            subtotal += amounts[i]
            
            # Update batch quantity
            if batch:
                batch.available_qty -= quantities[i]
        
        invoice.subtotal = subtotal
        db.session.commit()
        
        flash(f'Invoice {invoice_no} created successfully.', 'success')
        return jsonify({'success': True, 'invoice_no': invoice_no, 'invoice_id': invoice.id})
    
    except Exception as e:
        db.session.rollback()
        flash(f'Error creating invoice: {str(e)}', 'error')
        return jsonify({'success': False, 'error': str(e)}), 400

@sales_bp.route('/<int:id>')
@login_required
def view(id):
    invoice = Invoice.query.get_or_404(id)
    return render_template('sales/view.html', invoice=invoice)

@sales_bp.route('/<int:id>/print')
@login_required
def print_invoice(id):
    invoice = Invoice.query.get_or_404(id)
    return render_template('sales/print.html', invoice=invoice)

@sales_bp.route('/<int:id>/cancel', methods=['POST'])
@login_required
def cancel(id):
    invoice = Invoice.query.get_or_404(id)
    
    if invoice.is_cancelled:
        flash('Invoice is already cancelled.', 'error')
        return redirect(url_for('sales.view', id=id))
    
    # Restore stock
    for item in invoice.items:
        if item.batch_id:
            batch = Batch.query.get(item.batch_id)
            if batch:
                batch.available_qty += item.quantity
    
    invoice.is_cancelled = True
    invoice.cancelled_by = current_user.id
    invoice.cancelled_at = datetime.utcnow()
    
    db.session.commit()
    flash('Invoice cancelled successfully.', 'success')
    return redirect(url_for('sales.view', id=id))

@sales_bp.route('/returns')
@login_required
def returns():
    page = request.args.get('page', 1, type=int)
    per_page = request.args.get('per_page', 50, type=int)
    search = request.args.get('search', '')
    
    query = Invoice.query.filter_by(invoice_type='sale_return')
    
    if search:
        query = query.filter(Invoice.invoice_no.ilike(f'%{search}%'))
    
    returns = query.order_by(Invoice.invoice_date.desc()).paginate(page=page, per_page=per_page, error_out=False)
    
    # Calculate totals
    total_count = Invoice.query.filter_by(invoice_type='sale_return').count()
    total_amount = db.session.query(db.func.sum(Invoice.total_amount)).filter_by(invoice_type='sale_return').scalar() or 0
    
    returns_data = {
        'total': total_count,
        'total_amount': total_amount
    }
    
    return render_template('sales/returns.html', returns=returns, search=search, returns_data=returns_data)

@sales_bp.route('/return/new', methods=['GET', 'POST'])
@login_required
def returns_new():
    if request.method == 'POST':
        # Handle new return creation
        flash('Return created successfully.', 'success')
        return redirect(url_for('sales.returns'))
    
    return render_template('sales/return_new.html', original=None)

@sales_bp.route('/return/new/<int:original_id>', methods=['GET', 'POST'])
@login_required
def return_new(original_id):
    original = Invoice.query.get_or_404(original_id)
    
    if request.method == 'POST':
        invoice_no = generate_invoice_no('sale_return')
        
        invoice = Invoice(
            invoice_no=invoice_no,
            invoice_type='sale_return',
            invoice_date=datetime.utcnow(),
            customer_id=original.customer_id,
            subtotal=0,
            total_amount=0,
            payment_status='paid',
            remarks=f'Return for Invoice {original.invoice_no}',
            user_id=current_user.id
        )
        
        db.session.add(invoice)
        db.session.flush()
        
        # Process return items
        product_ids = request.form.getlist('product_id', type=int)
        quantities = request.form.getlist('quantity', type=int)
        rates = request.form.getlist('rate', type=float)
        amounts = request.form.getlist('amount', type=float)
        
        subtotal = 0
        for i, product_id in enumerate(product_ids):
            if quantities[i] > 0:
                item = InvoiceItem(
                    invoice_id=invoice.id,
                    product_id=product_id,
                    quantity=quantities[i],
                    unit_rate=rates[i],
                    amount=amounts[i]
                )
                db.session.add(item)
                subtotal += amounts[i]
        
        invoice.subtotal = subtotal
        invoice.total_amount = subtotal
        db.session.commit()
        
        flash(f'Return invoice {invoice_no} created successfully.', 'success')
        return redirect(url_for('sales.view', id=invoice.id))
    
    return render_template('sales/return_new.html', original=original)

# Edit duplicate invoice
@sales_bp.route('/<int:id>/edit-duplicate', methods=['GET', 'POST'])
@login_required
def edit_duplicate(id):
    invoice = Invoice.query.get_or_404(id)
    doctors = Doctor.query.filter_by(is_active=True).order_by(Doctor.doctor_name).all()
    
    if request.method == 'POST':
        # Update invoice
        invoice.customer_id = request.form.get('customer_id', type=int) or None
        invoice.sales_type = request.form.get('sales_type', 'cash')
        invoice.prescription_no = request.form.get('prescription_no', '')
        invoice.doctor_id = request.form.get('doctor_id', type=int) or None
        
        # Get form data
        product_ids = request.form.getlist('product_id', type=int)
        batch_ids = request.form.getlist('batch_id', type=int)
        quantities = request.form.getlist('quantity', type=int)
        unit_rates = request.form.getlist('unit_rate', type=float)
        mrp_values = request.form.getlist('mrp', type=float)
        discount_percs = request.form.getlist('discount_perc', type=float)
        tax_percs = request.form.getlist('tax_perc', type=float)
        amounts = request.form.getlist('amount', type=float)
        
        # Delete old items
        InvoiceItem.query.filter_by(invoice_id=invoice.id).delete()
        
        # Add new items
        subtotal = 0
        for i, product_id in enumerate(product_ids):
            if product_id and quantities[i] > 0:
                batch = Batch.query.get(batch_ids[i]) if batch_ids[i] else None
                
                # Get batch info if available
                batch_no = request.form.getlist('batch_no')[i] if i < len(request.form.getlist('batch_no')) else ''
                expiry_str = request.form.getlist('expiry_date')[i] if i < len(request.form.getlist('expiry_date')) else ''
                expiry_date = datetime.strptime(expiry_str, '%Y-%m-%d').date() if expiry_str else None
                
                item = InvoiceItem(
                    invoice_id=invoice.id,
                    product_id=product_id,
                    batch_id=batch_ids[i] or None,
                    batch_no=batch_no,
                    expiry_date=expiry_date,
                    quantity=quantities[i],
                    free_qty=0,
                    unit_rate=unit_rates[i] if i < len(unit_rates) else 0,
                    mrp=mrp_values[i] if i < len(mrp_values) else 0,
                    discount_perc=discount_percs[i] if i < len(discount_percs) else 0,
                    tax_perc=tax_percs[i] if i < len(tax_percs) else 0,
                    amount=amounts[i] if i < len(amounts) else 0
                )
                db.session.add(item)
                subtotal += amounts[i] if i < len(amounts) else 0
                
                # Update batch stock
                if batch:
                    batch.available_qty -= quantities[i]
        
        invoice.subtotal = subtotal
        invoice.total_amount = subtotal
        invoice.payment_status = 'paid'
        
        db.session.commit()
        
        flash(f'Invoice {invoice.invoice_no} updated successfully.', 'success')
        return redirect(url_for('sales.view', id=invoice.id))
    
    # Get tax rates for dropdown
    taxes = Tax.query.filter_by(is_active=True).order_by(Tax.tax_perc).all()
    
    return render_template('sales/edit_duplicate.html', invoice=invoice, taxes=taxes, doctors=doctors)

# Duplicate bill
@sales_bp.route('/<int:id>/duplicate')
@login_required
def duplicate(id):
    original = Invoice.query.get_or_404(id)
    invoice_no = generate_invoice_no()
    
    new_invoice = Invoice(
        invoice_no=invoice_no,
        invoice_type='sale',
        invoice_date=datetime.utcnow(),
        customer_id=original.customer_id,
        sales_type=original.sales_type,
        subtotal=original.subtotal,
        discount_perc=original.discount_perc,
        discount_amt=original.discount_amt,
        tax_amt=original.tax_amt,
        round_off=original.round_off,
        total_amount=original.total_amount,
        payment_status='paid',
        user_id=current_user.id,
        remarks=f'Duplicate of {original.invoice_no}'
    )
    
    db.session.add(new_invoice)
    db.session.flush()
    
    # Copy items with initial zero amounts (will be recalculated)
    items_data = []
    for item in original.items:
        new_item = InvoiceItem(
            invoice_id=new_invoice.id,
            product_id=item.product_id,
            batch_id=item.batch_id,
            batch_no=item.batch_no,
            expiry_date=item.expiry_date,
            quantity=item.quantity,
            free_qty=item.free_qty,
            unit_rate=item.unit_rate,
            mrp=item.mrp,
            discount_perc=item.discount_perc,
            tax_perc=item.tax_perc,
            amount=item.amount
        )
        db.session.add(new_item)
        items_data.append({
            'product_id': item.product_id,
            'product_name': item.product.product_name if item.product else 'Unknown',
            'batch_id': item.batch_id,
            'batch_no': item.batch_no,
            'quantity': item.quantity,
            'unit_rate': float(item.unit_rate),
            'mrp': float(item.mrp) if item.mrp else 0,
            'discount_perc': float(item.discount_perc) if item.discount_perc else 0,
            'tax_perc': float(item.tax_perc) if item.tax_perc else 0,
            'amount': float(item.amount)
        })
    
    db.session.commit()
    
    flash(f'Duplicate invoice {invoice_no} created. Edit below.', 'success')
    return redirect(url_for('sales.edit_duplicate', id=new_invoice.id))
# View return
@sales_bp.route("/return/<int:id>")
@login_required
def view_return(id):
    invoice = Invoice.query.get_or_404(id)
    return render_template("sales/view.html", invoice=invoice)

# Print return
@sales_bp.route("/return/<int:id>/print")
@login_required
def print_return(id):
    invoice = Invoice.query.get_or_404(id)
    return render_template("sales/print.html", invoice=invoice)
