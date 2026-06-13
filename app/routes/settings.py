from flask import Blueprint, render_template, request, redirect, url_for, flash, jsonify, send_file
from flask_login import login_required, current_user
from app import db
from app.models import Settings, User, UserRights, Company, AuditLog
from datetime import datetime
import os
import shutil
from io import BytesIO

settings_bp = Blueprint('settings', __name__)

@settings_bp.route('/')
@settings_bp.route('/general')
@login_required
def general():
    settings = {s.setting_key: s.setting_value for s in Settings.query.all()}
    return render_template('settings/general.html', settings=settings)

@settings_bp.route('/general/save', methods=['POST'])
@login_required
def save_general():
    settings_to_update = [
        'company_name', 'company_address', 'company_phone', 'company_email',
        'company_gstin', 'company_dl', 'invoice_prefix', 'print_after_sale',
        'default_discount', 'low_stock_alert', 'expiry_alert_days'
    ]
    
    for key in settings_to_update:
        value = request.form.get(key, '')
        setting = Settings.query.filter_by(setting_key=key).first()
        if setting:
            setting.setting_value = value
            setting.updated_at = datetime.utcnow()
        else:
            setting = Settings(setting_key=key, setting_value=value)
            db.session.add(setting)
    
    db.session.commit()
    flash('Settings saved successfully.', 'success')
    return redirect(url_for('settings.general'))

@settings_bp.route('/users')
@login_required
def users():
    if not current_user.is_admin:
        flash('Access denied. Admin privileges required.', 'error')
        return redirect(url_for('main.dashboard'))
    
    users = User.query.order_by(User.username).all()
    return render_template('settings/users.html', users=users)

@settings_bp.route('/users/add', methods=['POST'])
@login_required
def add_user():
    if not current_user.is_admin:
        return jsonify({'success': False, 'error': 'Access denied'}), 403
    
    username = request.form.get('username', '').strip()
    email = request.form.get('email', '').strip()
    password = request.form.get('password', '')
    full_name = request.form.get('full_name', '').strip()
    user_type = request.form.get('user_type', 'staff')
    
    if not all([username, email, password, full_name]):
        flash('All fields are required.', 'error')
        return redirect(url_for('settings.users'))
    
    if User.query.filter_by(username=username).first():
        flash('Username already exists.', 'error')
        return redirect(url_for('settings.users'))
    
    if User.query.filter_by(email=email).first():
        flash('Email already registered.', 'error')
        return redirect(url_for('settings.users'))
    
    user = User(
        username=username,
        email=email,
        full_name=full_name,
        user_type=user_type,
        is_admin=(user_type == 'admin')
    )
    user.set_password(password)
    
    db.session.add(user)
    db.session.commit()
    
    flash(f'User {username} created successfully.', 'success')
    return redirect(url_for('settings.users'))

@settings_bp.route('/users/<int:id>/edit', methods=['POST'])
@login_required
def edit_user(id):
    if not current_user.is_admin:
        return jsonify({'success': False, 'error': 'Access denied'}), 403
    
    user = User.query.get_or_404(id)
    
    user.full_name = request.form.get('full_name', '').strip()
    user.email = request.form.get('email', '').strip()
    user.user_type = request.form.get('user_type', 'staff')
    user.is_admin = (user.user_type == 'admin')
    user.is_active = request.form.get('is_active', '1') == '1'
    
    new_password = request.form.get('new_password', '')
    if new_password:
        user.set_password(new_password)
    
    db.session.commit()
    flash('User updated successfully.', 'success')
    return redirect(url_for('settings.users'))

@settings_bp.route('/users/<int:id>/rights')
@login_required
def user_rights(id):
    if not current_user.is_admin:
        flash('Access denied. Admin privileges required.', 'error')
        return redirect(url_for('main.dashboard'))
    
    user = User.query.get_or_404(id)
    
    modules = [
        ('products', 'Products'),
        ('customers', 'Customers'),
        ('suppliers', 'Suppliers'),
        ('sales', 'Sales'),
        ('purchase', 'Purchase'),
        ('inventory', 'Inventory'),
        ('reports', 'Reports'),
        ('settings', 'Settings')
    ]
    
    actions = ['view', 'add', 'edit', 'delete', 'print']
    
    return render_template('settings/user_rights.html', user=user, modules=modules, actions=actions)

@settings_bp.route('/users/<int:id>/rights/save', methods=['POST'])
@login_required
def save_user_rights(id):
    if not current_user.is_admin:
        return jsonify({'success': False, 'error': 'Access denied'}), 403
    
    user = User.query.get_or_404(id)
    
    # Clear existing rights
    UserRights.query.filter_by(user_id=id).delete()
    
    modules = ['products', 'customers', 'suppliers', 'sales', 'purchase', 'inventory', 'reports', 'settings']
    actions = ['view', 'add', 'edit', 'delete', 'print']
    
    for module in modules:
        for action in actions:
            if request.form.get(f'{module}_{action}'):
                right = UserRights(user_id=id, module=module, action=action)
                db.session.add(right)
    
    db.session.commit()
    flash('User rights updated successfully.', 'success')
    return redirect(url_for('settings.users'))

@settings_bp.route('/companies')
@login_required
def companies():
    companies = Company.query.order_by(Company.company_name).all()
    return render_template('settings/companies.html', companies=companies)

@settings_bp.route('/companies/add', methods=['POST'])
@login_required
def add_company():
    company = Company(
        company_code=request.form.get('company_code', '').strip(),
        company_name=request.form.get('company_name', '').strip(),
        address=request.form.get('address', ''),
        city=request.form.get('city', ''),
        state=request.form.get('state', ''),
        pincode=request.form.get('pincode', ''),
        phone=request.form.get('phone', ''),
        email=request.form.get('email', ''),
        gstin=request.form.get('gstin', ''),
        dl_no=request.form.get('dl_no', '')
    )
    
    db.session.add(company)
    db.session.commit()
    
    flash('Company added successfully.', 'success')
    return redirect(url_for('settings.companies'))

@settings_bp.route('/companies/<int:id>/edit', methods=['POST'])
@login_required
def edit_company(id):
    company = Company.query.get_or_404(id)
    
    company.company_name = request.form.get('company_name', '').strip()
    company.address = request.form.get('address', '')
    company.city = request.form.get('city', '')
    company.state = request.form.get('state', '')
    company.pincode = request.form.get('pincode', '')
    company.phone = request.form.get('phone', '')
    company.email = request.form.get('email', '')
    company.gstin = request.form.get('gstin', '')
    company.dl_no = request.form.get('dl_no', '')
    
    db.session.commit()
    flash('Company updated successfully.', 'success')
    return redirect(url_for('settings.companies'))

@settings_bp.route('/audit-log')
@login_required
def audit_log():
    if not current_user.is_admin:
        flash('Access denied. Admin privileges required.', 'error')
        return redirect(url_for('main.dashboard'))
    
    page = request.args.get('page', 1, type=int)
    per_page = request.args.get('per_page', 100, type=int)
    
    logs = AuditLog.query.order_by(AuditLog.created_at.desc()).paginate(page=page, per_page=per_page, error_out=False)
    
    return render_template('settings/audit_log.html', logs=logs)

@settings_bp.route('/backup')
@login_required
def backup():
    if not current_user.is_admin:
        flash('Access denied. Admin privileges required.', 'error')
        return redirect(url_for('main.dashboard'))
    
    return render_template('settings/backup.html')

@settings_bp.route('/backup/create', methods=['POST'])
@login_required
def create_backup():
    if not current_user.is_admin:
        return jsonify({'success': False, 'error': 'Access denied'}), 403
    
    try:
        from app import create_app
        app = create_app()
        
        # Create backup directory
        backup_dir = os.path.join(os.path.dirname(os.path.dirname(os.path.dirname(__file__))), 'backups')
        os.makedirs(backup_dir, exist_ok=True)
        
        timestamp = datetime.utcnow().strftime('%Y%m%d_%H%M%S')
        backup_file = os.path.join(backup_dir, f'billmymed_backup_{timestamp}.db')
        
        # Copy database
        db_path = os.path.join(os.path.dirname(os.path.dirname(os.path.dirname(__file__))), 'billmymed.db')
        if os.path.exists(db_path):
            shutil.copy2(db_path, backup_file)
        
        flash(f'Backup created: {os.path.basename(backup_file)}', 'success')
        return jsonify({'success': True, 'file': os.path.basename(backup_file)})
    
    except Exception as e:
        flash(f'Backup failed: {str(e)}', 'error')
        return jsonify({'success': False, 'error': str(e)}), 400

@settings_bp.route('/backup/download/')
@login_required
def download_backup(filename):
    if not current_user.is_admin:
        flash('Access denied.', 'error')
        return redirect(url_for('main.dashboard'))
    
    backup_dir = os.path.join(os.path.dirname(os.path.dirname(os.path.dirname(__file__))), 'backups')
    filepath = os.path.join(backup_dir, filename)
    
    if not os.path.exists(filepath):
        flash('Backup file not found.', 'error')
        return redirect(url_for('settings.backup'))
    
    return send_file(filepath, as_attachment=True)

@settings_bp.route('/sms')
@login_required
def sms():
    sms_settings = {
        'sms_enabled': Settings.get_value('sms_enabled', 'false'),
        'sms_api_key': Settings.get_value('sms_api_key', ''),
        'sms_sender_id': Settings.get_value('sms_sender_id', ''),
        'sms_template_id': Settings.get_value('sms_template_id', '')
    }
    
    return render_template('settings/sms.html', sms_settings=sms_settings)

@settings_bp.route('/sms/save', methods=['POST'])
@login_required
def save_sms():
    sms_settings = [
        ('sms_enabled', request.form.get('sms_enabled', 'false')),
        ('sms_api_key', request.form.get('sms_api_key', '')),
        ('sms_sender_id', request.form.get('sms_sender_id', '')),
        ('sms_template_id', request.form.get('sms_template_id', ''))
    ]
    
    for key, value in sms_settings:
        setting = Settings.query.filter_by(setting_key=key).first()
        if setting:
            setting.setting_value = value
        else:
            setting = Settings(setting_key=key, setting_value=value)
            db.session.add(setting)
    
    db.session.commit()
    flash('SMS settings saved successfully.', 'success')
    return redirect(url_for('settings.sms'))

@settings_bp.route('/tax-rates')
@login_required
def tax_rates():
    from app.models import Tax
    taxes = Tax.query.order_by(Tax.tax_perc).all()
    return render_template('settings/tax_rates.html', taxes=taxes)

@settings_bp.route('/tax-rates/add', methods=['POST'])
@login_required
def add_tax_rate():
    from app.models import Tax
    
    tax = Tax(
        tax_name=request.form.get('tax_name', '').strip(),
        tax_perc=request.form.get('tax_perc', 0, type=float),
        tax_type=request.form.get('tax_type', 'GST'),
        cgst_perc=request.form.get('cgst_perc', 0, type=float),
        sgst_perc=request.form.get('sgst_perc', 0, type=float),
        igst_perc=request.form.get('igst_perc', 0, type=float)
    )
    
    db.session.add(tax)
    db.session.commit()
    
    flash('Tax rate added successfully.', 'success')
    return redirect(url_for('settings.tax_rates'))