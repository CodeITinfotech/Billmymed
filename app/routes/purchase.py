from flask import Blueprint, render_template, request, redirect, url_for, flash, jsonify
from flask_login import login_required, current_user
from app import db
from app.models import Purchase, PurchaseItem, Product, Batch, AccountMaster, Ledger
from sqlalchemy import or_
from datetime import datetime, timedelta
import uuid

purchase_bp = Blueprint('purchase', __name__)

def generate_purchase_no():
    today = datetime.utcnow()
    date_str = today.strftime('%Y%m%d')
    
    last_purchase = Purchase.query.filter(
        Purchase.purchase_no.like(f'PUR{date_str}%')
    ).order_by(Purchase.id.desc()).first()
    
    if last_purchase:
        last_num = int(last_purchase.purchase_no[-4:])
        new_num = last_num + 1
    else:
        new_num = 1
    
    return f'PUR{date_str}{str(new_num).zfill(4)}'

@purchase_bp.route('/')
@login_required
def list():
    page = request.args.get('page', 1, type=int)
    per_page = request.args.get('per_page', 50, type=int)
    search = request.args.get('search', '')
    from_date = request.args.get('from_date', '')
    to_date = request.args.get('to_date', '')
    
    query = Purchase.query
    
    if search:
        query = query.join(AccountMaster, Purchase.supplier_id == AccountMaster.id).filter(
            or_(
                Purchase.purchase_no.ilike(f'%{search}%'),
                AccountMaster.account_name.ilike(f'%{search}%')
            )
        )
    
    if from_date:
        query = query.filter(Purchase.purchase_date >= datetime.strptime(from_date, '%Y-%m-%d'))
    if to_date:
        query = query.filter(Purchase.purchase_date <= datetime.strptime(to_date, '%Y-%m-%d') + timedelta(days=1))
    
    purchases = query.order_by(Purchase.purchase_date.desc()).paginate(page=page, per_page=per_page, error_out=False)
    
    return render_template('purchase/list.html', 
                         purchases=purchases,
                         search=search,
                         from_date=from_date,
                         to_date=to_date)

@purchase_bp.route('/new')
@login_required
def new():
    purchase_no = generate_purchase_no()
    suppliers = AccountMaster.query.filter_by(account_type='supplier', is_active=True).order_by(AccountMaster.account_name).all()
    return render_template('purchase/new.html', purchase_no=purchase_no, suppliers=suppliers)

@purchase_bp.route('/create', methods=['POST'])
@login_required
def create():
    try:
        purchase_no = generate_purchase_no()
        
        supplier_id = request.form.get('supplier_id', type=int)
        if not supplier_id:
            flash('Supplier is required.', 'error')
            return jsonify({'success': False, 'error': 'Supplier is required'}), 400
        
        purchase = Purchase(
            purchase_no=purchase_no,
            purchase_date=datetime.utcnow(),
            supplier_id=supplier_id,
            invoice_no=request.form.get('invoice_no', ''),
            invoice_date=datetime.strptime(request.form.get('invoice_date'), '%Y-%m-%d') if request.form.get('invoice_date') else None,
            subtotal=0,
            discount_perc=request.form.get('discount_perc', 0, type=float),
            discount_amt=request.form.get('discount_amt', 0, type=float),
            tax_amt=request.form.get('tax_amt', 0, type=float),
            round_off=request.form.get('round_off', 0, type=float),
            total_amount=request.form.get('total_amount', 0, type=float),
            payment_status=request.form.get('payment_status', 'pending'),
            remarks=request.form.get('remarks', ''),
            user_id=current_user.id
        )
        
        db.session.add(purchase)
        db.session.flush()
        
        # Process items
        product_ids = request.form.getlist('product_id', type=int)
        batch_nos = request.form.getlist('batch_no')
        expiry_dates = request.form.getlist('expiry_date')
        quantities = request.form.getlist('quantity', type=int)
        free_qtys = request.form.getlist('free_qty', type=int)
        purchase_rates = request.form.getlist('purchase_rate', type=float)
        mrps = request.form.getlist('mrp', type=float)
        sale_rates = request.form.getlist('sale_rate', type=float)
        discount_percs = request.form.getlist('discount_perc', type=float)
        tax_percs = request.form.getlist('tax_perc', type=float)
        amounts = request.form.getlist('amount', type=float)
        
        subtotal = 0
        for i, product_id in enumerate(product_ids):
            if not product_id:
                continue
            
            expiry = None
            if i < len(expiry_dates) and expiry_dates[i]:
                try:
                    expiry = datetime.strptime(expiry_dates[i], '%Y-%m-%d').date()
                except:
                    pass
            
            # Create or find batch
            batch = Batch(
                batch_no=batch_nos[i] if i < len(batch_nos) else '',
                product_id=product_id,
                expiry_date=expiry,
                purchase_rate=purchase_rates[i] if i < len(purchase_rates) else 0,
                mrp=mrps[i] if i < len(mrps) and mrps[i] else None,
                sale_rate=sale_rates[i] if i < len(sale_rates) and sale_rates[i] else None,
                quantity=quantities[i] + (free_qtys[i] if i < len(free_qtys) else 0),
                available_qty=quantities[i] + (free_qtys[i] if i < len(free_qtys) else 0),
                supplier_id=supplier_id,
                purchase_id=purchase.id
            )
            db.session.add(batch)
            db.session.flush()
            
            item = PurchaseItem(
                purchase_id=purchase.id,
                product_id=product_id,
                batch_no=batch.batch_no,
                expiry_date=expiry,
                quantity=quantities[i],
                free_qty=free_qtys[i] if i < len(free_qtys) else 0,
                purchase_rate=purchase_rates[i] if i < len(purchase_rates) else 0,
                mrp=mrps[i] if i < len(mrps) and mrps[i] else None,
                sale_rate=sale_rates[i] if i < len(sale_rates) and sale_rates[i] else None,
                discount_perc=discount_percs[i] if i < len(discount_percs) else 0,
                tax_perc=tax_percs[i] if i < len(tax_percs) else 0,
                amount=amounts[i] if i < len(amounts) else 0
            )
            
            db.session.add(item)
            subtotal += amounts[i] if i < len(amounts) else 0
        
        purchase.subtotal = subtotal
        db.session.commit()
        
        flash(f'Purchase {purchase_no} created successfully.', 'success')
        return jsonify({'success': True, 'purchase_no': purchase_no, 'purchase_id': purchase.id})
    
    except Exception as e:
        db.session.rollback()
        flash(f'Error creating purchase: {str(e)}', 'error')
        return jsonify({'success': False, 'error': str(e)}), 400

@purchase_bp.route('/<int:id>')
@login_required
def view(id):
    purchase = Purchase.query.get_or_404(id)
    return render_template('purchase/view.html', purchase=purchase)

@purchase_bp.route('/<int:id>/print')
@login_required
def print_purchase(id):
    purchase = Purchase.query.get_or_404(id)
    return render_template('purchase/print.html', purchase=purchase)

@purchase_bp.route('/<int:id>/cancel', methods=['POST'])
@login_required
def cancel(id):
    purchase = Purchase.query.get_or_404(id)
    
    if purchase.is_cancelled:
        flash('Purchase is already cancelled.', 'error')
        return redirect(url_for('purchase.view', id=id))
    
    # Remove batches
    for batch in purchase.batches:
        batch.available_qty = 0
    
    purchase.is_cancelled = True
    db.session.commit()
    
    flash('Purchase cancelled successfully.', 'success')
    return redirect(url_for('purchase.view', id=id))

# Purchase Returns
@purchase_bp.route('/returns')
@login_required
def returns():
    page = request.args.get('page', 1, type=int)
    per_page = request.args.get('per_page', 50, type=int)
    
    # This would need a separate model for purchase returns
    # For now, showing pending purchase payments as returns
    purchases = Purchase.query.filter_by(is_cancelled=False).order_by(Purchase.purchase_date.desc()).paginate(page=page, per_page=per_page, error_out=False)
    
    return render_template('purchase/returns.html', purchases=purchases)

# Payment to supplier
@purchase_bp.route('/payment/<int:supplier_id>', methods=['GET', 'POST'])
@login_required
def payment(supplier_id):
    supplier = AccountMaster.query.get_or_404(supplier_id)
    
    if request.method == 'POST':
        amount = request.form.get('amount', 0, type=float)
        payment_mode = request.form.get('payment_mode', 'cash')
        
        payment = Payment(
            payment_no=f'PAY{datetime.utcnow().strftime("%Y%m%d%H%M%S")}',
            payment_date=datetime.utcnow(),
            account_id=supplier_id,
            amount=amount,
            payment_type='payment',
            payment_mode=payment_mode,
            reference_no=request.form.get('reference_no', ''),
            bank_name=request.form.get('bank_name', ''),
            cheque_no=request.form.get('cheque_no', ''),
            remarks=request.form.get('remarks', ''),
            user_id=current_user.id
        )
        
        db.session.add(payment)
        db.session.commit()
        
        flash(f'Payment of ₹{amount} recorded successfully.', 'success')
        return redirect(url_for('suppliers.view', id=supplier_id))
    
    return render_template('purchase/payment.html', supplier=supplier)