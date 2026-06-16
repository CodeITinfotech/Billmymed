from flask import Blueprint, render_template, request, redirect, url_for, flash, jsonify
from flask_login import login_required, current_user
from app import db
from app.models import GenericMaster, CompanyMaster, ProductTypeMaster, HSNCodeMaster, Doctor, Patient

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

@masters_bp.route('/api/generics/search')
@login_required
def search_generics():
    term = request.args.get('q', '').strip()
    if len(term) < 1:
        return jsonify([])
    
    generics = GenericMaster.query.filter(
        GenericMaster.generic_name.ilike(f'%{term}%'),
        GenericMaster.is_active == True
    ).order_by(GenericMaster.generic_name).limit(20).all()
    
    return jsonify([{'id': i.id, 'name': i.generic_name} for i in generics])

@masters_bp.route('/api/generics', methods=['POST'])
@login_required
def api_add_generic():
    data = request.get_json()
    generic_name = data.get('generic_name', '').strip()
    
    if not generic_name:
        return jsonify({'success': False, 'error': 'Generic name is required'}), 400
    
    existing = GenericMaster.query.filter_by(generic_name=generic_name).first()
    if existing:
        return jsonify({'success': False, 'error': 'Generic name already exists'}), 400
    
    item = GenericMaster(generic_name=generic_name)
    db.session.add(item)
    db.session.commit()
    
    return jsonify({'success': True, 'id': item.id, 'name': item.generic_name})

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
    items = Doctor.query.filter_by(is_active=True).order_by(Doctor.doctor_name).all()
    return render_template('masters/doctors.html', items=items, page_title='Doctor Master')

@masters_bp.route('/api/doctors/search')
@login_required
def search_doctors():
    query = request.args.get('q', '')
    doctors = Doctor.query.filter(
        Doctor.is_active == True,
        Doctor.doctor_name.ilike(f'%{query}%')
    ).order_by(Doctor.doctor_name).limit(10).all()
    return jsonify([{
        'id': d.id,
        'name': d.doctor_name,
        'specialty': d.specialization or '',
        'degree': d.degree or '',
        'phone': d.phone or '',
        'address': d.address or ''
    } for d in doctors])

# Alias for backward compatibility
@masters_bp.route('/masters/api/doctors/search')
@login_required
def search_doctors_compat():
    query = request.args.get('q', '')
    doctors = Doctor.query.filter(
        Doctor.is_active == True,
        Doctor.doctor_name.ilike(f'%{query}%')
    ).order_by(Doctor.doctor_name).limit(10).all()
    return jsonify([{
        'id': d.id,
        'name': d.doctor_name,
        'specialty': d.specialization or '',
        'degree': d.degree or '',
        'phone': d.phone or '',
        'address': d.address or ''
    } for d in doctors])

@masters_bp.route('/doctors/add', methods=['POST'])
@login_required
def add_doctor():
    doctor_name = request.form.get('name', '').strip()
    specialization = request.form.get('specialty', '').strip()
    degree = request.form.get('degree', '').strip()
    phone = request.form.get('phone', '').strip()
    address = request.form.get('address', '').strip()
    
    if not doctor_name:
        flash('Doctor name is required', 'danger')
        return redirect(url_for('masters.doctors'))
    
    # Generate doctor code
    from datetime import datetime
    doctor_code = f'DOC{datetime.utcnow().strftime("%Y%m%d%H%M%S")}'
    
    item = Doctor(
        doctor_code=doctor_code,
        doctor_name=doctor_name,
        specialization=specialization,
        degree=degree,
        phone=phone,
        address=address
    )
    db.session.add(item)
    db.session.commit()
    flash('Doctor added successfully', 'success')
    return redirect(url_for('masters.doctors'))

@masters_bp.route('/doctors/edit/<int:id>', methods=['POST'])
@login_required
def edit_doctor(id):
    item = Doctor.query.get_or_404(id)
    item.doctor_name = request.form.get('name', '').strip()
    item.specialization = request.form.get('specialty', '').strip()
    item.degree = request.form.get('degree', '').strip()
    item.phone = request.form.get('phone', '').strip()
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

# ==================== PATIENT MASTER ====================
@masters_bp.route('/patients')
@login_required
def patients():
    items = Patient.query.filter_by(is_active=True).order_by(Patient.patient_name).all()
    return render_template('masters/patients.html', items=items, page_title='Patient Master')

@masters_bp.route('/patients/add', methods=['POST'])
@login_required
def add_patient():
    patient_name = request.form.get('patient_name', '').strip()
    phone = request.form.get('phone', '').strip()
    mobile = request.form.get('mobile', '').strip()
    email = request.form.get('email', '').strip()
    address = request.form.get('address', '').strip()
    city = request.form.get('city', '').strip()
    state = request.form.get('state', '').strip()
    pincode = request.form.get('pincode', '').strip()
    gender = request.form.get('gender', '').strip()
    date_of_birth = request.form.get('date_of_birth', '').strip()
    blood_group = request.form.get('blood_group', '').strip()
    allergies = request.form.get('allergies', '').strip()
    notes = request.form.get('notes', '').strip()
    
    if not patient_name:
        flash('Patient name is required', 'danger')
        return redirect(url_for('masters.patients'))
    
    # Generate patient code
    last_patient = Patient.query.order_by(Patient.id.desc()).first()
    next_num = int(last_patient.patient_code[2:]) + 1 if last_patient and last_patient.patient_code.startswith('P') else 1
    patient_code = f'P{next_num:04d}'
    
    item = Patient(
        patient_code=patient_code,
        patient_name=patient_name,
        phone=phone,
        mobile=mobile,
        email=email,
        address=address,
        city=city,
        state=state,
        pincode=pincode,
        gender=gender,
        blood_group=blood_group,
        allergies=allergies,
        notes=notes
    )
    db.session.add(item)
    db.session.commit()
    flash('Patient added successfully', 'success')
    return redirect(url_for('masters.patients'))

@masters_bp.route('/patients/edit/<int:id>', methods=['POST'])
@login_required
def edit_patient(id):
    item = Patient.query.get_or_404(id)
    item.patient_name = request.form.get('patient_name', '').strip()
    item.phone = request.form.get('phone', '').strip()
    item.mobile = request.form.get('mobile', '').strip()
    item.email = request.form.get('email', '').strip()
    item.address = request.form.get('address', '').strip()
    item.city = request.form.get('city', '').strip()
    item.state = request.form.get('state', '').strip()
    item.pincode = request.form.get('pincode', '').strip()
    item.gender = request.form.get('gender', '').strip()
    item.blood_group = request.form.get('blood_group', '').strip()
    item.allergies = request.form.get('allergies', '').strip()
    item.notes = request.form.get('notes', '').strip()
    db.session.commit()
    flash('Patient updated successfully', 'success')
    return redirect(url_for('masters.patients'))

@masters_bp.route('/patients/delete/<int:id>', methods=['POST'])
@login_required
def delete_patient(id):
    item = Patient.query.get_or_404(id)
    item.is_active = False
    db.session.commit()
    flash('Patient deleted successfully', 'success')
    return redirect(url_for('masters.patients'))

@masters_bp.route('/api/patients/search')
@login_required
def search_patients():
    query = request.args.get('q', '')
    # Search by name, phone, or mobile
    patients = Patient.query.filter(
        Patient.is_active == True
    ).filter(
        db.or_(
            Patient.patient_name.ilike(f'%{query}%'),
            Patient.phone.ilike(f'%{query}%'),
            Patient.mobile.ilike(f'%{query}%')
        )
    ).order_by(Patient.patient_name).limit(10).all()
    return jsonify([{
        'id': p.id,
        'name': p.patient_name,
        'phone': p.phone or p.mobile or '',
        'mobile': p.mobile or '',
        'address': p.address or '',
        'city': p.city or ''
    } for p in patients])

@masters_bp.route('/api/patients/quick_add', methods=['POST'])
@login_required
def quick_add_patient():
    data = request.get_json()
    patient_name = data.get('patient_name', '').strip()
    phone = data.get('phone', '').strip()
    address = data.get('address', '').strip()
    
    if not patient_name:
        return jsonify({'success': False, 'error': 'Patient name is required'})
    
    # Generate patient code
    last_patient = Patient.query.order_by(Patient.id.desc()).first()
    next_num = int(last_patient.patient_code[2:]) + 1 if last_patient and last_patient.patient_code.startswith('P') else 1
    patient_code = f'P{next_num:04d}'
    
    patient = Patient(
        patient_code=patient_code,
        patient_name=patient_name,
        phone=phone,
        address=address
    )
    db.session.add(patient)
    db.session.commit()
    
    return jsonify({'success': True, 'id': patient.id, 'patient_code': patient.patient_code})
