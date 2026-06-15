from flask import Blueprint, render_template, request, redirect, url_for, flash, jsonify
from flask_login import login_required, current_user
from app import db
from app.models import GenericMaster, ManufacturerMaster, ProductTypeMaster, HSNCodeMaster, Doctor

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
    
    # Check for duplicate
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

# ==================== MANUFACTURER MASTER ====================
@masters_bp.route('/manufacturers')
@login_required
def manufacturers():
    items = ManufacturerMaster.query.filter_by(is_active=True).order_by(ManufacturerMaster.manufacturer_name).all()
    return render_template('masters/manufacturers.html', items=items, page_title='Manufacturer Master')

@masters_bp.route('/manufacturers/add', methods=['POST'])
@login_required
def add_manufacturer():
    manufacturer_name = request.form.get('manufacturer_name', '').strip()
    short_name = request.form.get('short_name', '').strip()
    contact_person = request.form.get('contact_person', '').strip()
    phone = request.form.get('phone', '').strip()
    email = request.form.get('email', '').strip()
    address = request.form.get('address', '').strip()
    
    if not manufacturer_name:
        flash('Manufacturer name is required', 'danger')
        return redirect(url_for('masters.manufacturers'))
    
    existing = ManufacturerMaster.query.filter_by(manufacturer_name=manufacturer_name).first()
    if existing:
        flash('Manufacturer name already exists', 'warning')
        return redirect(url_for('masters.manufacturers'))
    
    item = ManufacturerMaster(
        manufacturer_name=manufacturer_name,
        short_name=short_name,
        contact_person=contact_person,
        phone=phone,
        email=email,
        address=address
    )
    db.session.add(item)
    db.session.commit()
    flash('Manufacturer added successfully', 'success')
    return redirect(url_for('masters.manufacturers'))

@masters_bp.route('/manufacturers/edit/<int:id>', methods=['POST'])
@login_required
def edit_manufacturer(id):
    item = ManufacturerMaster.query.get_or_404(id)
    item.manufacturer_name = request.form.get('manufacturer_name', '').strip()
    item.short_name = request.form.get('short_name', '').strip()
    item.contact_person = request.form.get('contact_person', '').strip()
    item.phone = request.form.get('phone', '').strip()
    item.email = request.form.get('email', '').strip()
    item.address = request.form.get('address', '').strip()
    db.session.commit()
    flash('Manufacturer updated successfully', 'success')
    return redirect(url_for('masters.manufacturers'))

@masters_bp.route('/manufacturers/delete/<int:id>', methods=['POST'])
@login_required
def delete_manufacturer(id):
    item = ManufacturerMaster.query.get_or_404(id)
    item.is_active = False
    db.session.commit()
    flash('Manufacturer deleted successfully', 'success')
    return redirect(url_for('masters.manufacturers'))

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
        flash('Product type name is required', 'danger')
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
    return render_template('masters/hsn_codes.html', items=items, page_title='HSN Code Master')

@masters_bp.route('/hsn-codes/add', methods=['POST'])
@login_required
def add_hsn_code():
    hsn_code = request.form.get('hsn_code', '').strip()
    description = request.form.get('description', '').strip()
    gst_rate = request.form.get('gst_rate', '0').strip()
    
    if not hsn_code:
        flash('HSN Code is required', 'danger')
        return redirect(url_for('masters.hsn_codes'))
    
    existing = HSNCodeMaster.query.filter_by(hsn_code=hsn_code).first()
    if existing:
        flash('HSN Code already exists', 'warning')
        return redirect(url_for('masters.hsn_codes'))
    
    try:
        gst_rate = float(gst_rate) if gst_rate else 0
    except:
        gst_rate = 0
    
    item = HSNCodeMaster(hsn_code=hsn_code, description=description, gst_rate=gst_rate)
    db.session.add(item)
    db.session.commit()
    flash('HSN Code added successfully', 'success')
    return redirect(url_for('masters.hsn_codes'))

@masters_bp.route('/hsn-codes/edit/<int:id>', methods=['POST'])
@login_required
def edit_hsn_code(id):
    item = HSNCodeMaster.query.get_or_404(id)
    item.hsn_code = request.form.get('hsn_code', '').strip()
    item.description = request.form.get('description', '').strip()
    gst_rate = request.form.get('gst_rate', '0').strip()
    try:
        item.gst_rate = float(gst_rate) if gst_rate else 0
    except:
        item.gst_rate = 0
    db.session.commit()
    flash('HSN Code updated successfully', 'success')
    return redirect(url_for('masters.hsn_codes'))

@masters_bp.route('/hsn-codes/delete/<int:id>', methods=['POST'])
@login_required
def delete_hsn_code(id):
    item = HSNCodeMaster.query.get_or_404(id)
    item.is_active = False
    db.session.commit()
    flash('HSN Code deleted successfully', 'success')
    return redirect(url_for('masters.hsn_codes'))

# ==================== API ENDPOINTS ====================
@masters_bp.route('/api/generics/search')
@login_required
def search_generics():
    term = request.args.get('q', '').strip()
    if len(term) < 1:
        return jsonify([])
    
    items = GenericMaster.query.filter(
        GenericMaster.is_active == True,
        GenericMaster.generic_name.ilike(f'%{term}%')
    ).order_by(GenericMaster.generic_name).limit(20).all()
    
    return jsonify([{'id': i.id, 'name': i.generic_name} for i in items])

@masters_bp.route('/api/manufacturers/search')
@login_required
def search_manufacturers():
    term = request.args.get('q', '').strip()
    if len(term) < 1:
        return jsonify([])
    
    items = ManufacturerMaster.query.filter(
        ManufacturerMaster.is_active == True,
        ManufacturerMaster.manufacturer_name.ilike(f'%{term}%')
    ).order_by(ManufacturerMaster.manufacturer_name).limit(20).all()
    
    return jsonify([{'id': i.id, 'name': i.manufacturer_name, 'short_name': i.short_name} for i in items])

@masters_bp.route('/api/product-types/search')
@login_required
def search_product_types():
    term = request.args.get('q', '').strip()
    if len(term) < 1:
        return jsonify([])
    
    items = ProductTypeMaster.query.filter(
        ProductTypeMaster.is_active == True,
        ProductTypeMaster.type_name.ilike(f'%{term}%')
    ).order_by(ProductTypeMaster.type_name).limit(20).all()
    
    return jsonify([{'id': i.id, 'name': i.type_name} for i in items])

@masters_bp.route('/api/hsn-codes/search')
@login_required
def search_hsn_codes():
    term = request.args.get('q', '').strip()
    if len(term) < 1:
        return jsonify([])
    
    items = HSNCodeMaster.query.filter(
        HSNCodeMaster.is_active == True,
        HSNCodeMaster.hsn_code.ilike(f'%{term}%')
    ).order_by(HSNCodeMaster.hsn_code).limit(20).all()
    
    return jsonify([{'id': i.id, 'hsn_code': i.hsn_code, 'gst_rate': float(i.gst_rate) if i.gst_rate else 0} for i in items])

# ==================== DOCTOR MASTER ====================
@masters_bp.route('/doctors')
@login_required
def doctors():
    items = Doctor.query.filter_by(is_active=True).order_by(Doctor.doctor_name).all()
    return render_template('masters/doctors.html', items=items, page_title='Doctor Master')

@masters_bp.route('/doctors/add', methods=['POST'])
@login_required
def add_doctor():
    doctor_name = request.form.get('doctor_name', '').strip()
    doctor_code = request.form.get('doctor_code', '').strip()
    specialization = request.form.get('specialization', '').strip()
    degree = request.form.get('degree', '').strip()
    phone = request.form.get('phone', '').strip()
    mobile = request.form.get('mobile', '').strip()
    address = request.form.get('address', '').strip()
    
    if not doctor_name:
        flash('Doctor name is required', 'danger')
        return redirect(url_for('masters.doctors'))
    
    if not doctor_code:
        # Auto-generate code
        last_doctor = Doctor.query.order_by(Doctor.id.desc()).first()
        doctor_code = f"DOC{str(int(last_doctor.id) + 1).zfill(4)}" if last_doctor else "DOC0001"
    
    existing = Doctor.query.filter_by(doctor_name=doctor_name).first()
    if existing:
        flash('Doctor name already exists', 'warning')
        return redirect(url_for('masters.doctors'))
    
    item = Doctor(
        doctor_name=doctor_name,
        doctor_code=doctor_code,
        specialization=specialization,
        degree=degree,
        phone=phone,
        mobile=mobile,
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
    item.doctor_name = request.form.get('doctor_name', '').strip()
    item.doctor_code = request.form.get('doctor_code', '').strip()
    item.specialization = request.form.get('specialization', '').strip()
    item.degree = request.form.get('degree', '').strip()
    item.phone = request.form.get('phone', '').strip()
    item.mobile = request.form.get('mobile', '').strip()
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

@masters_bp.route('/api/doctors/search')
@login_required
def search_doctors():
    term = request.args.get('q', '').strip()
    if len(term) < 1:
        return jsonify([])
    
    items = Doctor.query.filter(
        Doctor.is_active == True,
        Doctor.doctor_name.ilike(f'%{term}%')
    ).order_by(Doctor.doctor_name).limit(20).all()
    
    return jsonify([{'id': i.id, 'name': i.doctor_name, 'specialization': i.specialization or '', 'degree': i.degree or ''} for i in items])