from flask import Blueprint, render_template, request, redirect, url_for, flash, jsonify
from flask_login import login_required, current_user
from app import db
from app.models import AccountMaster, AccountGroup, Purchase, Payment
from sqlalchemy import or_
from datetime import datetime

suppliers_bp = Blueprint('suppliers', __name__)

@suppliers_bp.route('/')
@login_required
def list():
    page = request.args.get('page', 1, type=int)
    per_page = request.args.get('per_page', 50, type=int)
    search = request.args.get('search', '')
    
    query = AccountMaster.query.filter_by(account_type='supplier', is_active=True)
    
    if search:
        query = query.filter(
            or_(
                AccountMaster.account_code.ilike(f'%{search}%'),
                AccountMaster.account_name.ilike(f'%{search}%'),
                AccountMaster.mobile.ilike(f'%{search}%'),
                AccountMaster.phone.ilike(f'%{search}%')
            )
        )
    
    suppliers = query.order_by(AccountMaster.account_name).paginate(page=page, per_page=per_page, error_out=False)
    
    groups = AccountGroup.query.filter_by(group_type='supplier', is_active=True).order_by(AccountGroup.group_name).all()
    
    return render_template('suppliers/list.html', 
                         suppliers=suppliers,
                         groups=groups,
                         search=search)

@suppliers_bp.route('/<int:id>')
@login_required
def view(id):
    supplier = AccountMaster.query.get_or_404(id)
    
    # Get recent purchases
    purchases = Purchase.query.filter_by(supplier_id=id).order_by(Purchase.purchase_date.desc()).limit(20).all()
    
    # Get payments
    payments = Payment.query.filter_by(account_id=id).order_by(Payment.payment_date.desc()).limit(20).all()
    
    # Calculate totals
    total_purchases = sum(p.total_amount for p in purchases)
    total_paid = sum(p.amount for p in payments if p.payment_type == 'payment')
    
    return render_template('suppliers/view.html', 
                         supplier=supplier,
                         purchases=purchases,
                         payments=payments,
                         total_purchases=total_purchases,
                         total_paid=total_paid)

@suppliers_bp.route('/add', methods=['GET', 'POST'])
@login_required
def add():
    if request.method == 'POST':
        account_code = request.form.get('account_code', '').strip()
        account_name = request.form.get('account_name', '').strip()
        
        if not account_code or not account_name:
            flash('Account code and name are required.', 'error')
            return redirect(url_for('suppliers.add'))
        
        if AccountMaster.query.filter_by(account_code=account_code).first():
            flash('Account code already exists.', 'error')
            return redirect(url_for('suppliers.add'))
        
        supplier = AccountMaster(
            account_code=account_code,
            account_name=account_name,
            account_type='supplier',
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
        
        db.session.add(supplier)
        db.session.commit()
        
        flash(f'Supplier {supplier.account_name} added successfully.', 'success')
        return redirect(url_for('suppliers.view', id=supplier.id))
    
    groups = AccountGroup.query.filter_by(group_type='supplier', is_active=True).order_by(AccountGroup.group_name).all()
    return render_template('suppliers/add.html', groups=groups)

@suppliers_bp.route('/<int:id>/edit', methods=['GET', 'POST'])
@login_required
def edit(id):
    supplier = AccountMaster.query.get_or_404(id)
    
    if request.method == 'POST':
        supplier.account_name = request.form.get('account_name', '').strip()
        supplier.group_id = request.form.get('group_id', type=int)
        supplier.contact_person = request.form.get('contact_person', '').strip()
        supplier.address = request.form.get('address', '').strip()
        supplier.city = request.form.get('city', '').strip()
        supplier.state = request.form.get('state', '').strip()
        supplier.pincode = request.form.get('pincode', '').strip()
        supplier.phone = request.form.get('phone', '').strip()
        supplier.mobile = request.form.get('mobile', '').strip()
        supplier.email = request.form.get('email', '').strip()
        supplier.gstin = request.form.get('gstin', '').strip()
        supplier.pan = request.form.get('pan', '').strip()
        supplier.credit_limit = request.form.get('credit_limit', 0, type=float)
        supplier.credit_period = request.form.get('credit_period', 0, type=int)
        supplier.discount_perc = request.form.get('discount_perc', 0, type=float)
        supplier.notes = request.form.get('notes', '').strip()
        supplier.updated_at = datetime.utcnow()
        
        db.session.commit()
        flash('Supplier updated successfully.', 'success')
        return redirect(url_for('suppliers.view', id=supplier.id))
    
    groups = AccountGroup.query.filter_by(group_type='supplier', is_active=True).order_by(AccountGroup.group_name).all()
    return render_template('suppliers/edit.html', supplier=supplier, groups=groups)

@suppliers_bp.route('/<int:id>/delete', methods=['POST'])
@login_required
def delete(id):
    supplier = AccountMaster.query.get_or_404(id)
    supplier.is_active = False
    db.session.commit()
    flash('Supplier deactivated successfully.', 'success')
    return redirect(url_for('suppliers.list'))

@suppliers_bp.route('/search-json')
@login_required
def search_json():
    query = request.args.get('q', '')
    if len(query) < 2:
        return jsonify([])
    
    suppliers = AccountMaster.query.filter(
        AccountMaster.account_type == 'supplier',
        AccountMaster.is_active == True,
        or_(
            AccountMaster.account_code.ilike(f'%{query}%'),
            AccountMaster.account_name.ilike(f'%{query}%'),
            AccountMaster.mobile.ilike(f'%{query}%')
        )
    ).limit(20).all()
    
    results = []
    for s in suppliers:
        results.append({
            'id': s.id,
            'account_code': s.account_code,
            'account_name': s.account_name,
            'mobile': s.mobile,
            'balance': float(s.balance) if s.balance else 0,
            'credit_limit': float(s.credit_limit) if s.credit_limit else 0
        })
    
    return jsonify(results)

@suppliers_bp.route('/<int:id>/statement')
@login_required
def statement(id):
    supplier = AccountMaster.query.get_or_404(id)
    from_date = request.args.get('from_date')
    to_date = request.args.get('to_date')
    
    query = Purchase.query.filter_by(supplier_id=id)
    
    if from_date:
        query = query.filter(Purchase.purchase_date >= datetime.strptime(from_date, '%Y-%m-%d'))
    if to_date:
        query = query.filter(Purchase.purchase_date <= datetime.strptime(to_date, '%Y-%m-%d'))
    
    purchases = query.order_by(Purchase.purchase_date).all()
    
    return render_template('suppliers/statement.html', supplier=supplier, purchases=purchases)