from flask import Blueprint, render_template, request, redirect, url_for, flash, jsonify
from flask_login import login_required, current_user
from app import db
from app.models import AccountMaster, AccountGroup, Invoice, Payment, CardDetail, Prescription
from sqlalchemy import or_, and_
from datetime import datetime

customers_bp = Blueprint('customers', __name__)

@customers_bp.route('/')
@login_required
def list():
    page = request.args.get('page', 1, type=int)
    per_page = request.args.get('per_page', 50, type=int)
    search = request.args.get('search', '')
    
    query = AccountMaster.query.filter_by(account_type='customer', is_active=True)
    
    if search:
        query = query.filter(
            or_(
                AccountMaster.account_code.ilike(f'%{search}%'),
                AccountMaster.account_name.ilike(f'%{search}%'),
                AccountMaster.mobile.ilike(f'%{search}%'),
                AccountMaster.phone.ilike(f'%{search}%')
            )
        )
    
    customers = query.order_by(AccountMaster.account_name).paginate(page=page, per_page=per_page, error_out=False)
    
    groups = AccountGroup.query.filter_by(group_type='customer', is_active=True).order_by(AccountGroup.group_name).all()
    
    return render_template('customers/list.html', 
                         customers=customers,
                         groups=groups,
                         search=search)

@customers_bp.route('/<int:id>')
@login_required
def view(id):
    customer = AccountMaster.query.get_or_404(id)
    
    # Get recent invoices
    invoices = Invoice.query.filter_by(customer_id=id, invoice_type='sale').order_by(Invoice.invoice_date.desc()).limit(20).all()
    
    # Get payments
    payments = Payment.query.filter_by(account_id=id).order_by(Payment.payment_date.desc()).limit(20).all()
    
    # Get cards
    cards = CardDetail.query.filter_by(customer_id=id).all()
    
    # Get prescriptions
    prescriptions = Prescription.query.filter_by(customer_id=id).order_by(Prescription.prescription_date.desc()).limit(10).all()
    
    return render_template('customers/view.html', 
                         customer=customer,
                         invoices=invoices,
                         payments=payments,
                         cards=cards,
                         prescriptions=prescriptions)

@customers_bp.route('/add', methods=['GET', 'POST'])
@login_required
def add():
    if request.method == 'POST':
        account_code = request.form.get('account_code', '').strip()
        account_name = request.form.get('account_name', '').strip()
        
        if not account_code or not account_name:
            flash('Account code and name are required.', 'error')
            return redirect(url_for('customers.add'))
        
        if AccountMaster.query.filter_by(account_code=account_code).first():
            flash('Account code already exists.', 'error')
            return redirect(url_for('customers.add'))
        
        customer = AccountMaster(
            account_code=account_code,
            account_name=account_name,
            account_type='customer',
            group_id=request.form.get('group_id', type=int),
            contact_person=request.form.get('contact_person', '').strip(),
            address=request.form.get('address', '').strip(),
            city=request.form.get('city', '').strip(),
            state=request.form.get('state', '').strip(),
            pincode=request.form.get('pincode', '').strip(),
            phone=request.form.get('phone', '').strip(),
            mobile=request.form.get('mobile', '').strip(),
            email=request.form.get('email', '').strip(),
            gstin=request.form.get('gstin', '').strip(),
            pan=request.form.get('pan', '').strip(),
            credit_limit=request.form.get('credit_limit', 0, type=float),
            credit_period=request.form.get('credit_period', 0, type=int),
            opening_balance=request.form.get('opening_balance', 0, type=float),
            discount_perc=request.form.get('discount_perc', 0, type=float),
            notes=request.form.get('notes', '').strip()
        )
        
        db.session.add(customer)
        db.session.commit()
        
        flash(f'Customer {customer.account_name} added successfully.', 'success')
        return redirect(url_for('customers.view', id=customer.id))
    
    groups = AccountGroup.query.filter_by(group_type='customer', is_active=True).order_by(AccountGroup.group_name).all()
    return render_template('customers/add.html', groups=groups)

@customers_bp.route('/<int:id>/edit', methods=['GET', 'POST'])
@login_required
def edit(id):
    customer = AccountMaster.query.get_or_404(id)
    
    if request.method == 'POST':
        customer.account_name = request.form.get('account_name', '').strip()
        customer.group_id = request.form.get('group_id', type=int)
        customer.contact_person = request.form.get('contact_person', '').strip()
        customer.address = request.form.get('address', '').strip()
        customer.city = request.form.get('city', '').strip()
        customer.state = request.form.get('state', '').strip()
        customer.pincode = request.form.get('pincode', '').strip()
        customer.phone = request.form.get('phone', '').strip()
        customer.mobile = request.form.get('mobile', '').strip()
        customer.email = request.form.get('email', '').strip()
        customer.gstin = request.form.get('gstin', '').strip()
        customer.pan = request.form.get('pan', '').strip()
        customer.credit_limit = request.form.get('credit_limit', 0, type=float)
        customer.credit_period = request.form.get('credit_period', 0, type=int)
        customer.discount_perc = request.form.get('discount_perc', 0, type=float)
        customer.notes = request.form.get('notes', '').strip()
        customer.updated_at = datetime.utcnow()
        
        db.session.commit()
        flash('Customer updated successfully.', 'success')
        return redirect(url_for('customers.view', id=customer.id))
    
    groups = AccountGroup.query.filter_by(group_type='customer', is_active=True).order_by(AccountGroup.group_name).all()
    return render_template('customers/edit.html', customer=customer, groups=groups)

@customers_bp.route('/<int:id>/delete', methods=['POST'])
@login_required
def delete(id):
    customer = AccountMaster.query.get_or_404(id)
    customer.is_active = False
    db.session.commit()
    flash('Customer deactivated successfully.', 'success')
    return redirect(url_for('customers.list'))

@customers_bp.route('/search-json')
@login_required
def search_json():
    query = request.args.get('q', '')
    if len(query) < 2:
        return jsonify([])
    
    customers = AccountMaster.query.filter(
        AccountMaster.account_type == 'customer',
        AccountMaster.is_active == True,
        or_(
            AccountMaster.account_code.ilike(f'%{query}%'),
            AccountMaster.account_name.ilike(f'%{query}%'),
            AccountMaster.mobile.ilike(f'%{query}%')
        )
    ).limit(20).all()
    
    results = []
    for c in customers:
        results.append({
            'id': c.id,
            'account_code': c.account_code,
            'account_name': c.account_name,
            'mobile': c.mobile,
            'balance': float(c.balance) if c.balance else 0,
            'credit_limit': float(c.credit_limit) if c.credit_limit else 0,
            'discount_perc': float(c.discount_perc) if c.discount_perc else 0
        })
    
    return jsonify(results)

@customers_bp.route('/<int:id>/statement')
@login_required
def statement(id):
    customer = AccountMaster.query.get_or_404(id)
    from_date = request.args.get('from_date')
    to_date = request.args.get('to_date')
    
    query = Invoice.query.filter_by(customer_id=id, invoice_type='sale')
    
    if from_date:
        query = query.filter(Invoice.invoice_date >= datetime.strptime(from_date, '%Y-%m-%d'))
    if to_date:
        query = query.filter(Invoice.invoice_date <= datetime.strptime(to_date, '%Y-%m-%d'))
    
    invoices = query.order_by(Invoice.invoice_date).all()
    
    return render_template('customers/statement.html', customer=customer, invoices=invoices)

# Customer groups
@customers_bp.route('/groups')
@login_required
def groups():
    groups = AccountGroup.query.filter_by(group_type='customer').order_by(AccountGroup.group_name).all()
    return render_template('customers/groups.html', groups=groups)

@customers_bp.route('/groups/add', methods=['POST'])
@login_required
def add_group():
    group_code = request.form.get('group_code', '').strip()
    group_name = request.form.get('group_name', '').strip()
    
    if not group_code or not group_name:
        flash('Group code and name are required.', 'error')
        return redirect(url_for('customers.groups'))
    
    if AccountGroup.query.filter_by(group_code=group_code).first():
        flash('Group code already exists.', 'error')
        return redirect(url_for('customers.groups'))
    
    group = AccountGroup(
        group_code=group_code,
        group_name=group_name,
        group_type='customer',
        parent_id=request.form.get('parent_id', type=int)
    )
    
    db.session.add(group)
    db.session.commit()
    
    flash('Group added successfully.', 'success')
    return redirect(url_for('customers.groups'))