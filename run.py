import os
from app import create_app, db
from app.models import User, Settings, Category, Tax

app = create_app(os.environ.get('FLASK_CONFIG', 'development'))

@app.shell_context_processor
def make_shell_context():
    return {
        'db': db, 
        'User': User, 
        'Settings': Settings,
        'Category': Category,
        'Tax': Tax
    }

@app.cli.command('init-db')
def init_db():
    """Initialize the database with default data."""
    db.create_all()
    
    # Create default admin user
    if not User.query.filter_by(username='admin').first():
        admin = User(
            username='admin',
            email='admin@billmymed.com',
            full_name='Administrator',
            user_type='admin',
            is_admin=True
        )
        admin.set_password('admin123')
        db.session.add(admin)
    
    # Create default staff user
    if not User.query.filter_by(username='staff').first():
        staff = User(
            username='staff',
            email='staff@billmymed.com',
            full_name='Store Staff',
            user_type='staff'
        )
        staff.set_password('staff123')
        db.session.add(staff)
    
    # Create default categories
    default_categories = [
        ('TABLETS', 'Tablets'),
        ('SYRUPS', 'Syrups'),
        ('CAPSULES', 'Capsules'),
        ('INJECTIONS', 'Injections'),
        ('CREAMS', 'Creams & Ointments'),
        ('DROPS', 'Eye/Ear Drops'),
        ('INHALERS', 'Inhalers'),
        ('SUPPLEMENTS', 'Health Supplements')
    ]
    
    for code, name in default_categories:
        if not Category.query.filter_by(category_code=code).first():
            category = Category(category_code=code, category_name=name)
            db.session.add(category)
    
    # Create default tax rates
    default_taxes = [
        ('GST 5%', 5, 'GST', 2.5, 2.5, 0),
        ('GST 12%', 12, 'GST', 6, 6, 0),
        ('GST 18%', 18, 'GST', 9, 9, 0),
        ('GST 28%', 28, 'GST', 14, 14, 0)
    ]
    
    for name, perc, tax_type, cgst, sgst, igst in default_taxes:
        if not Tax.query.filter_by(tax_name=name).first():
            tax = Tax(tax_name=name, tax_perc=perc, tax_type=tax_type, 
                     cgst_perc=cgst, sgst_perc=sgst, igst_perc=igst)
            db.session.add(tax)
    
    # Create default settings
    default_settings = [
        ('company_name', 'BillMyMed Pharma'),
        ('company_address', 'Your Pharmacy Address'),
        ('company_phone', ''),
        ('company_email', ''),
        ('company_gstin', ''),
        ('invoice_prefix', 'INV'),
        ('print_after_sale', 'true'),
        ('default_discount', '0'),
        ('low_stock_alert', '10'),
        ('expiry_alert_days', '30')
    ]
    
    for key, value in default_settings:
        if not Settings.query.filter_by(setting_key=key).first():
            setting = Settings(setting_key=key, setting_value=value)
            db.session.add(setting)
    
    db.session.commit()
    print('Database initialized with default data!')

@app.cli.command('reset-db')
def reset_db():
    """Reset the database."""
    db.drop_all()
    db.create_all()
    print('Database reset!')

if __name__ == '__main__':
    port = int(os.environ.get('PORT', 5000))
    app.run(host='0.0.0.0', port=port, debug=True)