from flask import Blueprint, render_template, request, redirect, url_for, flash, jsonify
from flask_login import login_required, current_user
from app import db
from app.models import GenericMaster, CompanyMaster, ProductTypeMaster, HSNCodeMaster, Doctor

masters_bp = Blueprint('masters', __name__, url_prefix='/masters')

# ==================== GENERIC MASTER ====================
@masters_bp.route('/generics')
@login_required
def generics():
    items = GenericMaster.query.filter_by(is_active=True).order_by(GenericMaster.generic_name).all()
    return render_template('masters/generics.html', items=items, page_title='Generic Master')

@masters_bp.route('/generics/add', methods=['POST'])
@login_required
def add_generic():
    generic_name = request.form.get('generic_name', '').strip()
    description = request.form.get('description', '').strip()
    
    if not generic_name:
        flash('Generic name is required', 'danger')
        return redirect(url_for('masters.generics'))
    
    existing = GenericMaster.query.filter_by(generic_name=generic_name).first()
    if existing:
        flash('Generic name already exists', 'warning')
        return redirect(url_for('masters.generics'))
    
    item = GenericMaster(generic_name=generic_name, description=description)
    db.session.add(item)
    db.session.commit()
    flash('Generic added successfully', 'success')
    return redirect(url_for('masters.generics'))

@masters_bp.route('/generics/edit/<int:id>', methods=['POST'])
@login_required
def edit_generic(id):
    item = GenericMaster.query.get_or_404(id)
    generic_name = request.form.get('generic_name', '').strip()
    description = request.form.get('description', '').strip()
    
    if not generic_name:
        flash('Generic name is required', 'danger')
        return redirect(url_for('masters.generics'))
    
    existing = GenericMaster.query.filter(GenericMaster.generic_name == generic_name, GenericMaster.id != id).first()
    if existing:
        flash('Generic name already exists', 'warning')
        return redirect(url_for('masters.generics'))
    
    item.generic_name = generic_name
    item.description = description
    db.session.commit()
    flash('Generic updated successfully', 'success')
    return redirect(url_for('masters.generics'))

@masters_bp.route('/generics/delete/<int:id>', methods=['POST'])
@login_required
def delete_generic(id):
    item = GenericMaster.query.get_or_404(id)
    item.is_active = False
    db.session.commit()
    flash('Generic deleted successfully', 'success')
    return redirect(url_for('masters.generics'))

# ==================== COMPANY MASTER ====================
@masters_bp.route('/companies')
@login_required
def companies():
    items = CompanyMaster.query.filter_by(is_active=True).order_by(CompanyMaster.company_name).all()
    return render_template('masters/companies.html', items=items, page_title='Company Master')

@masters_bp.route('/companies/add', methods=['POST'])
@login_required
def add_company():
    company_name = request.form.get('company_name', '').strip()
    short_name = request.form.get('short_name', '').strip()
    contact_person = request.form.get('contact_person', '').strip()
    phone = request.form.get('phone', '').strip()
    email = request.form.get('email', '').strip()
    address = request.form.get('address', '').strip()
    
    if not company_name:
        flash('Company name is required', 'danger')
        return redirect(url_for('masters.companies'))
    
    existing = CompanyMaster.query.filter_by(company_name=company_name).first()
    if existing:
        flash('Company name already exists', 'warning')
        return redirect(url_for('masters.companies'))
    
    item = CompanyMaster(
        company_name=company_name,
        short_name=short_name,
        contact_person=contact_person,
        phone=phone,
        email=email,
        address=address
    )
    db.session.add(item)
    db.session.commit()
    flash('Company added successfully', 'success')
    return redirect(url_for('masters.companies'))

@masters_bp.route('/companies/edit/<int:id>', methods=['POST'])
@login_required
def edit_company(id):
    item = CompanyMaster.query.get_or_404(id)
    item.company_name = request.form.get('company_name', '').strip()
    item.short_name = request.form.get('short_name', '').strip()
    item.contact_person = request.form.get('contact_person', '').strip()
    item.phone = request.form.get('phone', '').strip()
    item.email = request.form.get('email', '').strip()
    item.address = request.form.get('address', '').strip()
    db.session.commit()
    flash('Company updated successfully', 'success')
    return redirect(url_for('masters.companies'))

@masters_bp.route('/companies/delete/<int:id>', methods=['POST'])
@login_required
def delete_company(id):
    item = CompanyMaster.query.get_or_404(id)
    item.is_active = False
    db.session.commit()
    flash('Company deleted successfully', 'success')
    return redirect(url_for('masters.companies'))

# Legacy routes for backward compatibility (point to companies)
@masters_bp.route('/manufacturers')
@login_required
def manufacturers():
    return companies()

@masters_bp.route('/manufacturers/add', methods=['POST'])
@login_required
def add_manufacturer():
    return add_company()

@masters_bp.route('/manufacturers/edit/<int:id>', methods=['POST'])
@login_required
def edit_manufacturer(id):
    return edit_company(id)

@masters_bp.route('/manufacturers/delete/<int:id>', methods=['POST'])
@login_required
def delete_manufacturer(id):
    return delete_company(id)

# ==================== PRODUCT TYPE MASTER ====================
@masters_bp.route('/product-types')
@login_required
def product_types():
    items = ProductTypeMaster.query.filter_by(is_active=True).order_by(ProductTypeMaster.type_name).all()
    return render_template('masters/product_types.html', items=items, page_title='Product Type')

@masters_bp.route('/product-types/add', methods=['POST'])
@login_required
def add_product_type():
    type_name = request.form.get('type_name', '').strip()
    description = request.form.get('description', '').strip()
    
    if not type_name:
        flash('Product type is required', 'danger')
        return redirect(url_for('masters.product_types'))
    
    existing = ProductTypeMaster.query.filter_by(type_name=type_name).first()
    if existing:
        flash('Product type already exists', 'warning')
        return redirect(url_for('masters.product_types'))
    
    item = ProductTypeMaster(type_name=type_name, description=description)
    db.session.add(item)
    db.session.commit()
    flash('Product type added successfully', 'success')
    return redirect(url_for('masters.product_types'))

@masters_bp.route('/product-types/edit/<int:id>', methods=['POST'])
@login_required
def edit_product_type(id):
    item = ProductTypeMaster.query.get_or_404(id)
    item.type_name = request.form.get('type_name', '').strip()
    item.description = request.form.get('description', '').strip()
    db.session.commit()
    flash('Product type updated successfully', 'success')
    return redirect(url_for('masters.product_types'))

@masters_bp.route('/product-types/delete/<int:id>', methods=['POST'])
@login_required
def delete_product_type(id):
    item = ProductTypeMaster.query.get_or_404(id)
    item.is_active = False
    db.session.commit()
    flash('Product type deleted successfully', 'success')
    return redirect(url_for('masters.product_types'))

# ==================== HSN CODE MASTER ====================
@masters_bp.route('/hsn-codes')
@login_required
def hsn_codes():
    items = HSNCodeMaster.query.filter_by(is_active=True).order_by(HSNCodeMaster.hsn_code).all()
    return render_template('masters/hsn_codes.html', items=items, page_title='HSN Code')

@masters_bp.route('/hsn-codes/add', methods=['POST'])
@login_required
def add_hsn_code():
    hsn_code = request.form.get('hsn_code', '').strip()
    gst_rate = request.form.get('gst_rate', 0, type=float)
    
    if not hsn_code:
        flash('HSN code is required', 'danger')
        return redirect(url_for('masters.hsn_codes'))
    
    existing = HSNCodeMaster.query.filter_by(hsn_code=hsn_code).first()
    if existing:
        flash('HSN code already exists', 'warning')
        return redirect(url_for('masters.hsn_codes'))
    
    item = HSNCodeMaster(hsn_code=hsn_code, gst_rate=gst_rate)
    db.session.add(item)
    db.session.commit()
    flash('HSN code added successfully', 'success')
    return redirect(url_for('masters.hsn_codes'))

@masters_bp.route('/hsn-codes/edit/<int:id>', methods=['POST'])
@login_required
def edit_hsn_code(id):
    item = HSNCodeMaster.query.get_or_404(id)
    item.hsn_code = request.form.get('hsn_code', '').strip()
    item.gst_rate = request.form.get('gst_rate', 0, type=float)
    db.session.commit()
    flash('HSN code updated successfully', 'success')
    return redirect(url_for('masters.hsn_codes'))

@masters_bp.route('/hsn-codes/delete/<int:id>', methods=['POST'])
@login_required
def delete_hsn_code(id):
    item = HSNCodeMaster.query.get_or_404(id)
    item.is_active = False
    db.session.commit()
    flash('HSN code deleted successfully', 'success')
    return redirect(url_for('masters.hsn_codes'))

# API routes for masters
@masters_bp.route('/api/companies/search')
@login_required
def search_companies():
    term = request.args.get('q', '').strip()
    if len(term) < 1:
        return jsonify([])
    
    companies = CompanyMaster.query.filter(
        CompanyMaster.company_name.ilike(f'%{term}%'),
        CompanyMaster.is_active == True
    ).order_by(CompanyMaster.company_name).limit(20).all()
    
    return jsonify([{'id': i.id, 'name': i.company_name, 'short_name': i.short_name} for i in companies])

@masters_bp.route('/api/hsn-codes', methods=['POST'])
@login_required
def api_add_hsn():
    data = request.get_json()
    hsn_code = data.get('hsn_code', '').strip()
    gst_rate = data.get('gst_rate', 0)
    
    existing = HSNCodeMaster.query.filter_by(hsn_code=hsn_code).first()
    if existing:
        return jsonify({'success': False, 'error': 'HSN code already exists'}), 400
    
    item = HSNCodeMaster(hsn_code=hsn_code, gst_rate=gst_rate)
    db.session.add(item)
    db.session.commit()
    return jsonify({'success': True, 'id': item.id, 'hsn_code': item.hsn_code})

# ==================== DOCTOR MASTER ====================
@masters_bp.route('/doctors')
@login_required
def doctors():
    items = Doctor.query.filter_by(is_active=True).order_by(Doctor.name).all()
    return render_template('masters/doctors.html', items=items, page_title='Doctor Master')

@masters_bp.route('/doctors/add', methods=['POST'])
@login_required
def add_doctor():
    name = request.form.get('name', '').strip()
    specialty = request.form.get('specialty', '').strip()
    phone = request.form.get('phone', '').strip()
    email = request.form.get('email', '').strip()
    address = request.form.get('address', '').strip()
    
    if not name:
        flash('Doctor name is required', 'danger')
        return redirect(url_for('masters.doctors'))
    
    item = Doctor(name=name, specialty=specialty, phone=phone, email=email, address=address)
    db.session.add(item)
    db.session.commit()
    flash('Doctor added successfully', 'success')
    return redirect(url_for('masters.doctors'))

@masters_bp.route('/doctors/edit/<int:id>', methods=['POST'])
@login_required
def edit_doctor(id):
    item = Doctor.query.get_or_404(id)
    item.name = request.form.get('name', '').strip()
    item.specialty = request.form.get('specialty', '').strip()
    item.phone = request.form.get('phone', '').strip()
    item.email = request.form.get('email', '').strip()
    item.address = request.form.get('address', '').strip()
    db.session.commit()
    flash('Doctor updated successfully', 'success')
    return redirect(url_for('masters.doctors'))

@masters_bp.route('/doctors/delete/<int:id>', methods=['POST'])
@login_required
def delete_doctor(id):
    item = Doctor.query.get_or_404(id)
    item.is_active = False
    db.session.commit()
    flash('Doctor deleted successfully', 'success')
    return redirect(url_for('masters.doctors'))
