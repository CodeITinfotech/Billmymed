from datetime import datetime
from app import db
from flask_login import UserMixin
from werkzeug.security import generate_password_hash, check_password_hash

class User(UserMixin, db.Model):
    __tablename__ = 'users'
    
    id = db.Column(db.Integer, primary_key=True)
    username = db.Column(db.String(64), unique=True, nullable=False, index=True)
    password_hash = db.Column(db.String(255), nullable=False)
    full_name = db.Column(db.String(100), nullable=False)
    email = db.Column(db.String(120), unique=True)
    phone = db.Column(db.String(20))
    user_type = db.Column(db.String(20), default='staff')  # admin, manager, staff
    is_active = db.Column(db.Boolean, default=True)
    is_admin = db.Column(db.Boolean, default=False)
    created_at = db.Column(db.DateTime, default=datetime.utcnow)
    last_login = db.Column(db.DateTime)
    
    # Relationships
    user_rights = db.relationship('UserRights', backref='user', lazy='dynamic', cascade='all, delete-orphan')
    audit_logs = db.relationship('AuditLog', backref='user', lazy='dynamic', cascade='all, delete-orphan')
    
    def set_password(self, password):
        self.password_hash = generate_password_hash(password)
    
    def check_password(self, password):
        return check_password_hash(self.password_hash, password)
    
    def has_right(self, module, action='view'):
        right = self.user_rights.filter_by(module=module, action=action).first()
        return right is not None or self.is_admin
    
    def __repr__(self):
        return f'<User {self.username}>'

class UserRights(db.Model):
    __tablename__ = 'user_rights'
    
    id = db.Column(db.Integer, primary_key=True)
    user_id = db.Column(db.Integer, db.ForeignKey('users.id'), nullable=False)
    module = db.Column(db.String(50), nullable=False)
    action = db.Column(db.String(20), nullable=False)  # view, add, edit, delete, print
    granted = db.Column(db.Boolean, default=True)
    
    __table_args__ = (db.UniqueConstraint('user_id', 'module', 'action'),)
    
    def __repr__(self):
        return f'<UserRights {self.user_id}:{self.module}:{self.action}>'

class AuditLog(db.Model):
    __tablename__ = 'audit_logs'
    
    id = db.Column(db.Integer, primary_key=True)
    user_id = db.Column(db.Integer, db.ForeignKey('users.id'))
    action = db.Column(db.String(50), nullable=False)
    module = db.Column(db.String(50))
    record_id = db.Column(db.Integer)
    details = db.Column(db.Text)
    ip_address = db.Column(db.String(45))
    created_at = db.Column(db.DateTime, default=datetime.utcnow, index=True)
    
    def __repr__(self):
        return f'<AuditLog {self.action} by {self.user_id}>'

class Company(db.Model):
    __tablename__ = 'companies'
    
    id = db.Column(db.Integer, primary_key=True)
    company_code = db.Column(db.String(10), unique=True, nullable=False)
    company_name = db.Column(db.String(200), nullable=False)
    address = db.Column(db.Text)
    city = db.Column(db.String(100))
    state = db.Column(db.String(100))
    pincode = db.Column(db.String(10))
    phone = db.Column(db.String(20))
    email = db.Column(db.String(120))
    gstin = db.Column(db.String(15))
    dl_no = db.Column(db.String(50))
    logo = db.Column(db.LargeBinary)
    is_active = db.Column(db.Boolean, default=True)
    created_at = db.Column(db.DateTime, default=datetime.utcnow)
    
    def __repr__(self):
        return f'<Company {self.company_name}>'

class Product(db.Model):
    __tablename__ = 'products'
    
    id = db.Column(db.Integer, primary_key=True)
    product_code = db.Column(db.String(20), unique=True, nullable=False, index=True)
    product_name = db.Column(db.String(200), nullable=False, index=True)
    generic_name = db.Column(db.String(200))
    manufacturer = db.Column(db.String(200))
    schedule = db.Column(db.String(10))  # H, Sch-H, Sch-X, OTC
    product_type = db.Column(db.String(20))  # Tablet, Syrup, Injection, etc.
    pack_type = db.Column(db.String(50))
    pack_qty = db.Column(db.Integer, default=1)
    mrp = db.Column(db.Numeric(12, 2))
    rate = db.Column(db.Numeric(12, 2))
    ptr = db.Column(db.Numeric(12, 2))
    pts = db.Column(db.Numeric(12, 2))
    discount_perc = db.Column(db.Numeric(5, 2), default=0)
    tax_perc = db.Column(db.Numeric(5, 2), default=0)
    min_stock = db.Column(db.Integer, default=0)
    max_stock = db.Column(db.Integer, default=0)
    reorder_level = db.Column(db.Integer, default=0)
    hsn_code = db.Column(db.String(10))
    location = db.Column(db.String(50))  # Rack/shelf location
    is_active = db.Column(db.Boolean, default=True)
    is_banned = db.Column(db.Boolean, default=False)
    created_at = db.Column(db.DateTime, default=datetime.utcnow)
    updated_at = db.Column(db.DateTime, default=datetime.utcnow, onupdate=datetime.utcnow)
    
    # Relationships
    batches = db.relationship('Batch', backref='product', lazy='dynamic', cascade='all, delete-orphan')
    barcodes = db.relationship('ProductBarcode', backref='product', lazy='dynamic', cascade='all, delete-orphan')
    category_id = db.Column(db.Integer, db.ForeignKey('categories.id'))
    category = db.relationship('Category', backref='products')
    
    def __repr__(self):
        return f'<Product {self.product_code}: {self.product_name}>'
    
    @property
    def current_stock(self):
        return sum(b.available_qty for b in self.batches if b.available_qty > 0)

class ProductBarcode(db.Model):
    """Multiple barcodes can be linked to one product"""
    __tablename__ = 'product_barcodes'
    
    id = db.Column(db.Integer, primary_key=True)
    product_id = db.Column(db.Integer, db.ForeignKey('products.id'), nullable=False)
    barcode = db.Column(db.String(50), nullable=False, index=True)
    is_primary = db.Column(db.Boolean, default=False)
    created_at = db.Column(db.DateTime, default=datetime.utcnow)
    
    __table_args__ = (db.UniqueConstraint('barcode', name='uq_barcode'),)
    
    def __repr__(self):
        return f'<ProductBarcode {self.barcode} -> {self.product_id}>'

class Category(db.Model):
    __tablename__ = 'categories'
    
    id = db.Column(db.Integer, primary_key=True)
    category_code = db.Column(db.String(10), unique=True, nullable=False)
    category_name = db.Column(db.String(100), nullable=False)
    parent_id = db.Column(db.Integer, db.ForeignKey('categories.id'))
    description = db.Column(db.Text)
    is_active = db.Column(db.Boolean, default=True)
    
    def __repr__(self):
        return f'<Category {self.category_name}>'

class Batch(db.Model):
    __tablename__ = 'batches'
    
    id = db.Column(db.Integer, primary_key=True)
    batch_no = db.Column(db.String(30), nullable=False)
    product_id = db.Column(db.Integer, db.ForeignKey('products.id'), nullable=False)
    expiry_date = db.Column(db.Date)
    purchase_rate = db.Column(db.Numeric(12, 2))
    mrp = db.Column(db.Numeric(12, 2))
    sale_rate = db.Column(db.Numeric(12, 2))
    quantity = db.Column(db.Integer, default=0)
    available_qty = db.Column(db.Integer, default=0)
    rack_id = db.Column(db.Integer, db.ForeignKey('racks.id'))
    supplier_id = db.Column(db.Integer, db.ForeignKey('account_masters.id'))
    purchase_id = db.Column(db.Integer, db.ForeignKey('purchases.id'))
    created_at = db.Column(db.DateTime, default=datetime.utcnow)
    
    def __repr__(self):
        return f'<Batch {self.batch_no} of {self.product_id}>'

class Rack(db.Model):
    __tablename__ = 'racks'
    
    id = db.Column(db.Integer, primary_key=True)
    rack_code = db.Column(db.String(10), unique=True, nullable=False)
    rack_name = db.Column(db.String(50), nullable=False)
    location = db.Column(db.String(100))
    is_active = db.Column(db.Boolean, default=True)
    
    def __repr__(self):
        return f'<Rack {self.rack_name}>'

class AccountMaster(db.Model):
    __tablename__ = 'account_masters'
    
    id = db.Column(db.Integer, primary_key=True)
    account_code = db.Column(db.String(20), unique=True, nullable=False, index=True)
    account_name = db.Column(db.String(200), nullable=False, index=True)
    account_type = db.Column(db.String(20), nullable=False)  # customer, supplier, doctor, etc.
    group_id = db.Column(db.Integer, db.ForeignKey('account_groups.id'))
    contact_person = db.Column(db.String(100))
    address = db.Column(db.Text)
    city = db.Column(db.String(100))
    state = db.Column(db.String(100))
    pincode = db.Column(db.String(10))
    phone = db.Column(db.String(20))
    mobile = db.Column(db.String(15))
    email = db.Column(db.String(120))
    gstin = db.Column(db.String(15))
    pan = db.Column(db.String(10))
    credit_limit = db.Column(db.Numeric(12, 2), default=0)
    credit_period = db.Column(db.Integer, default=0)  # days
    opening_balance = db.Column(db.Numeric(12, 2), default=0)
    balance = db.Column(db.Numeric(12, 2), default=0)
    discount_perc = db.Column(db.Numeric(5, 2), default=0)
    is_active = db.Column(db.Boolean, default=True)
    is_blacklisted = db.Column(db.Boolean, default=False)
    notes = db.Column(db.Text)
    created_at = db.Column(db.DateTime, default=datetime.utcnow)
    updated_at = db.Column(db.DateTime, default=datetime.utcnow, onupdate=datetime.utcnow)
    
    def __repr__(self):
        return f'<Account {self.account_code}: {self.account_name}>'

class AccountGroup(db.Model):
    __tablename__ = 'account_groups'
    
    id = db.Column(db.Integer, primary_key=True)
    group_code = db.Column(db.String(10), unique=True, nullable=False)
    group_name = db.Column(db.String(100), nullable=False)
    group_type = db.Column(db.String(20), nullable=False)  # customer, supplier, expense, income
    parent_id = db.Column(db.Integer, db.ForeignKey('account_groups.id'))
    is_active = db.Column(db.Boolean, default=True)
    
    def __repr__(self):
        return f'<AccountGroup {self.group_name}>'

class Tax(db.Model):
    __tablename__ = 'taxes'
    
    id = db.Column(db.Integer, primary_key=True)
    tax_name = db.Column(db.String(50), nullable=False)
    tax_perc = db.Column(db.Numeric(5, 2), nullable=False)
    tax_type = db.Column(db.String(10), default='GST')  # GST, VAT, etc.
    is_active = db.Column(db.Boolean, default=True)
    cgst_perc = db.Column(db.Numeric(5, 2), default=0)
    sgst_perc = db.Column(db.Numeric(5, 2), default=0)
    igst_perc = db.Column(db.Numeric(5, 2), default=0)
    
    def __repr__(self):
        return f'<Tax {self.tax_name}: {self.tax_perc}%>'

class Invoice(db.Model):
    __tablename__ = 'invoices'
    
    id = db.Column(db.Integer, primary_key=True)
    invoice_no = db.Column(db.String(20), unique=True, nullable=False, index=True)
    invoice_date = db.Column(db.DateTime, default=datetime.utcnow, index=True)
    invoice_type = db.Column(db.String(20), nullable=False)  # sale, purchase, sale_return, purchase_return
    customer_id = db.Column(db.Integer, db.ForeignKey('account_masters.id'))
    customer = db.relationship('AccountMaster', foreign_keys=[customer_id])
    supplier_id = db.Column(db.Integer, db.ForeignKey('account_masters.id'))
    supplier = db.relationship('AccountMaster', foreign_keys=[supplier_id])
    subtotal = db.Column(db.Numeric(12, 2), default=0)
    discount_perc = db.Column(db.Numeric(5, 2), default=0)
    discount_amt = db.Column(db.Numeric(12, 2), default=0)
    tax_amt = db.Column(db.Numeric(12, 2), default=0)
    round_off = db.Column(db.Numeric(8, 2), default=0)
    total_amount = db.Column(db.Numeric(12, 2), default=0)
    cash_amount = db.Column(db.Numeric(12, 2), default=0)
    card_amount = db.Column(db.Numeric(12, 2), default=0)
    credit_amount = db.Column(db.Numeric(12, 2), default=0)
    payment_status = db.Column(db.String(20), default='paid')  # paid, partial, credit
    due_date = db.Column(db.Date)
    sales_type = db.Column(db.String(10), default='cash')  # cash, credit, emergency
    doctor_id = db.Column(db.Integer, db.ForeignKey('account_masters.id'))
    doctor = db.relationship('AccountMaster', foreign_keys=[doctor_id])
    prescription_no = db.Column(db.String(50))
    remarks = db.Column(db.Text)
    user_id = db.Column(db.Integer, db.ForeignKey('users.id'))
    user = db.relationship('User', foreign_keys=[user_id], backref='invoices')
    is_cancelled = db.Column(db.Boolean, default=False)
    cancelled_by = db.Column(db.Integer, db.ForeignKey('users.id'))
    cancelled_at = db.Column(db.DateTime)
    created_at = db.Column(db.DateTime, default=datetime.utcnow)
    
    # Relationships
    items = db.relationship('InvoiceItem', backref='invoice', lazy='dynamic', cascade='all, delete-orphan')
    payments = db.relationship('Payment', backref='invoice', lazy='dynamic')
    
    def __repr__(self):
        return f'<Invoice {self.invoice_no}>'

class InvoiceItem(db.Model):
    __tablename__ = 'invoice_items'
    
    id = db.Column(db.Integer, primary_key=True)
    invoice_id = db.Column(db.Integer, db.ForeignKey('invoices.id'), nullable=False)
    product_id = db.Column(db.Integer, db.ForeignKey('products.id'), nullable=False)
    product = db.relationship('Product')
    batch_id = db.Column(db.Integer, db.ForeignKey('batches.id'))
    batch = db.relationship('Batch')
    batch_no = db.Column(db.String(30))
    expiry_date = db.Column(db.Date)
    quantity = db.Column(db.Integer, nullable=False)
    free_qty = db.Column(db.Integer, default=0)
    unit_rate = db.Column(db.Numeric(12, 2), nullable=False)
    mrp = db.Column(db.Numeric(12, 2))
    discount_perc = db.Column(db.Numeric(5, 2), default=0)
    discount_amt = db.Column(db.Numeric(12, 2), default=0)
    tax_perc = db.Column(db.Numeric(5, 2), default=0)
    tax_amt = db.Column(db.Numeric(12, 2), default=0)
    amount = db.Column(db.Numeric(12, 2), nullable=False)
    created_at = db.Column(db.DateTime, default=datetime.utcnow)
    
    def __repr__(self):
        return f'<InvoiceItem {self.product_id} x {self.quantity}>'

class Purchase(db.Model):
    __tablename__ = 'purchases'
    
    id = db.Column(db.Integer, primary_key=True)
    purchase_no = db.Column(db.String(20), unique=True, nullable=False, index=True)
    purchase_date = db.Column(db.DateTime, default=datetime.utcnow, index=True)
    supplier_id = db.Column(db.Integer, db.ForeignKey('account_masters.id'), nullable=False)
    supplier = db.relationship('AccountMaster', foreign_keys=[supplier_id], backref='purchases')
    invoice_no = db.Column(db.String(30))
    invoice_date = db.Column(db.Date)
    subtotal = db.Column(db.Numeric(12, 2), default=0)
    discount_perc = db.Column(db.Numeric(5, 2), default=0)
    discount_amt = db.Column(db.Numeric(12, 2), default=0)
    tax_amt = db.Column(db.Numeric(12, 2), default=0)
    round_off = db.Column(db.Numeric(8, 2), default=0)
    total_amount = db.Column(db.Numeric(12, 2), default=0)
    payment_status = db.Column(db.String(20), default='pending')
    due_date = db.Column(db.Date)
    remarks = db.Column(db.Text)
    user_id = db.Column(db.Integer, db.ForeignKey('users.id'))
    is_cancelled = db.Column(db.Boolean, default=False)
    created_at = db.Column(db.DateTime, default=datetime.utcnow)
    
    # Relationships
    items = db.relationship('PurchaseItem', backref='purchase', lazy='dynamic', cascade='all, delete-orphan')
    batches = db.relationship('Batch', backref='purchase', lazy='dynamic')
    
    def __repr__(self):
        return f'<Purchase {self.purchase_no}>'

class PurchaseItem(db.Model):
    __tablename__ = 'purchase_items'
    
    id = db.Column(db.Integer, primary_key=True)
    purchase_id = db.Column(db.Integer, db.ForeignKey('purchases.id'), nullable=False)
    product_id = db.Column(db.Integer, db.ForeignKey('products.id'), nullable=False)
    product = db.relationship('Product')
    batch_no = db.Column(db.String(30))
    expiry_date = db.Column(db.Date)
    quantity = db.Column(db.Integer, nullable=False)
    free_qty = db.Column(db.Integer, default=0)
    purchase_rate = db.Column(db.Numeric(12, 2), nullable=False)
    mrp = db.Column(db.Numeric(12, 2))
    sale_rate = db.Column(db.Numeric(12, 2))
    discount_perc = db.Column(db.Numeric(5, 2), default=0)
    discount_amt = db.Column(db.Numeric(12, 2), default=0)
    tax_perc = db.Column(db.Numeric(5, 2), default=0)
    tax_amt = db.Column(db.Numeric(12, 2), default=0)
    amount = db.Column(db.Numeric(12, 2), nullable=False)
    created_at = db.Column(db.DateTime, default=datetime.utcnow)
    
    def __repr__(self):
        return f'<PurchaseItem {self.product_id} x {self.quantity}>'

class Payment(db.Model):
    __tablename__ = 'payments'
    
    id = db.Column(db.Integer, primary_key=True)
    payment_no = db.Column(db.String(20), unique=True, nullable=False)
    payment_date = db.Column(db.DateTime, default=datetime.utcnow)
    invoice_id = db.Column(db.Integer, db.ForeignKey('invoices.id'))
    account_id = db.Column(db.Integer, db.ForeignKey('account_masters.id'), nullable=False)
    account = db.relationship('AccountMaster', foreign_keys=[account_id], backref='payments')
    amount = db.Column(db.Numeric(12, 2), nullable=False)
    payment_type = db.Column(db.String(20), nullable=False)  # receipt, payment
    payment_mode = db.Column(db.String(20))  # cash, card, cheque, online
    reference_no = db.Column(db.String(50))
    bank_name = db.Column(db.String(50))
    cheque_no = db.Column(db.String(30))
    cheque_date = db.Column(db.Date)
    remarks = db.Column(db.Text)
    user_id = db.Column(db.Integer, db.ForeignKey('users.id'))
    created_at = db.Column(db.DateTime, default=datetime.utcnow)
    
    def __repr__(self):
        return f'<Payment {self.payment_no}: {self.amount}>'

class StockAdjustment(db.Model):
    __tablename__ = 'stock_adjustments'
    
    id = db.Column(db.Integer, primary_key=True)
    adj_no = db.Column(db.String(20), unique=True, nullable=False)
    adj_date = db.Column(db.DateTime, default=datetime.utcnow)
    adj_type = db.Column(db.String(20), nullable=False)  # add, remove, damage, expired
    reason = db.Column(db.Text)
    total_items = db.Column(db.Integer, default=0)
    total_qty = db.Column(db.Integer, default=0)
    user_id = db.Column(db.Integer, db.ForeignKey('users.id'))
    status = db.Column(db.String(20), default='pending')  # pending, approved, rejected
    approved_by = db.Column(db.Integer, db.ForeignKey('users.id'))
    approved_at = db.Column(db.DateTime)
    remarks = db.Column(db.Text)
    created_at = db.Column(db.DateTime, default=datetime.utcnow)
    
    items = db.relationship('StockAdjustmentItem', backref='adjustment', lazy='dynamic', cascade='all, delete-orphan')
    
    def __repr__(self):
        return f'<StockAdjustment {self.adj_no}>'

class StockAdjustmentItem(db.Model):
    __tablename__ = 'stock_adjustment_items'
    
    id = db.Column(db.Integer, primary_key=True)
    adj_id = db.Column(db.Integer, db.ForeignKey('stock_adjustments.id'), nullable=False)
    product_id = db.Column(db.Integer, db.ForeignKey('products.id'), nullable=False)
    product = db.relationship('Product')
    batch_id = db.Column(db.Integer, db.ForeignKey('batches.id'))
    batch_no = db.Column(db.String(30))
    current_qty = db.Column(db.Integer, default=0)
    adj_qty = db.Column(db.Integer, nullable=False)  # positive for add, negative for remove
    new_qty = db.Column(db.Integer, nullable=False)
    reason = db.Column(db.String(200))
    
    def __repr__(self):
        return f'<StockAdjItem {self.product_id}: {self.adj_qty}>'

class PurchaseOrder(db.Model):
    """Purchase Order - Pending orders sent to suppliers"""
    __tablename__ = 'purchase_orders'
    
    id = db.Column(db.Integer, primary_key=True)
    order_no = db.Column(db.String(20), unique=True, nullable=False, index=True)
    order_date = db.Column(db.DateTime, default=datetime.utcnow, index=True)
    supplier_id = db.Column(db.Integer, db.ForeignKey('account_masters.id'), nullable=False)
    supplier = db.relationship('AccountMaster', foreign_keys=[supplier_id], backref='purchase_orders')
    expected_date = db.Column(db.Date)
    status = db.Column(db.String(20), default='pending')  # pending, sent, approved, partial, received, cancelled
    subtotal = db.Column(db.Numeric(12, 2), default=0)
    discount_perc = db.Column(db.Numeric(5, 2), default=0)
    discount_amt = db.Column(db.Numeric(12, 2), default=0)
    tax_amt = db.Column(db.Numeric(12, 2), default=0)
    total_amount = db.Column(db.Numeric(12, 2), default=0)
    remarks = db.Column(db.Text)
    user_id = db.Column(db.Integer, db.ForeignKey('users.id'))
    is_cancelled = db.Column(db.Boolean, default=False)
    created_at = db.Column(db.DateTime, default=datetime.utcnow)
    updated_at = db.Column(db.DateTime, default=datetime.utcnow, onupdate=datetime.utcnow)
    
    # Relationships
    items = db.relationship('PurchaseOrderItem', backref='order', lazy='dynamic', cascade='all, delete-orphan')
    
    def __repr__(self):
        return f'<PurchaseOrder {self.order_no}>'

class PurchaseOrderItem(db.Model):
    """Items in a Purchase Order"""
    __tablename__ = 'purchase_order_items'
    
    id = db.Column(db.Integer, primary_key=True)
    order_id = db.Column(db.Integer, db.ForeignKey('purchase_orders.id'), nullable=False)
    product_id = db.Column(db.Integer, db.ForeignKey('products.id'), nullable=False)
    product = db.relationship('Product')
    quantity = db.Column(db.Integer, nullable=False)
    received_qty = db.Column(db.Integer, default=0)  # quantity received so far
    pending_qty = db.Column(db.Integer)  # calculated field
    unit_rate = db.Column(db.Numeric(12, 2), nullable=False)
    mrp = db.Column(db.Numeric(12, 2))
    discount_perc = db.Column(db.Numeric(5, 2), default=0)
    discount_amt = db.Column(db.Numeric(12, 2), default=0)
    tax_perc = db.Column(db.Numeric(5, 2), default=0)
    tax_amt = db.Column(db.Numeric(12, 2), default=0)
    amount = db.Column(db.Numeric(12, 2), nullable=False)
    remarks = db.Column(db.String(200))
    created_at = db.Column(db.DateTime, default=datetime.utcnow)
    
    def __repr__(self):
        return f'<POItem {self.product_id} x {self.quantity}>'

class Ledger(db.Model):
    __tablename__ = 'ledgers'
    
    id = db.Column(db.Integer, primary_key=True)
    ledger_date = db.Column(db.DateTime, default=datetime.utcnow, index=True)
    voucher_no = db.Column(db.String(20), nullable=False)
    voucher_type = db.Column(db.String(20), nullable=False)  # sale, purchase, payment, receipt, contra, journal
    account_id = db.Column(db.Integer, db.ForeignKey('account_masters.id'), nullable=False)
    account = db.relationship('AccountMaster', foreign_keys=[account_id], backref='ledger_entries')
    debit = db.Column(db.Numeric(12, 2), default=0)
    credit = db.Column(db.Numeric(12, 2), default=0)
    narration = db.Column(db.Text)
    ref_invoice_id = db.Column(db.Integer)
    ref_payment_id = db.Column(db.Integer)
    user_id = db.Column(db.Integer, db.ForeignKey('users.id'))
    created_at = db.Column(db.DateTime, default=datetime.utcnow)
    
    def __repr__(self):
        return f'<Ledger {self.voucher_no}: Dr={self.debit} Cr={self.credit}>'

class CardDetail(db.Model):
    __tablename__ = 'card_details'
    
    id = db.Column(db.Integer, primary_key=True)
    card_no = db.Column(db.String(20), unique=True, nullable=False)
    card_type = db.Column(db.String(20), default='loyalty')  # loyalty, membership, gift
    customer_id = db.Column(db.Integer, db.ForeignKey('account_masters.id'), nullable=False)
    customer = db.relationship('AccountMaster', foreign_keys=[customer_id], backref='cards')
    issue_date = db.Column(db.Date, default=datetime.utcnow)
    expiry_date = db.Column(db.Date)
    points = db.Column(db.Integer, default=0)
    points_value = db.Column(db.Numeric(10, 2), default=0)  # monetary value of points
    is_active = db.Column(db.Boolean, default=True)
    created_at = db.Column(db.DateTime, default=datetime.utcnow)
    
    def __repr__(self):
        return f'<Card {self.card_no}>'

class Prescription(db.Model):
    __tablename__ = 'prescriptions'
    
    id = db.Column(db.Integer, primary_key=True)
    prescription_no = db.Column(db.String(20), unique=True, nullable=False)
    prescription_date = db.Column(db.DateTime, default=datetime.utcnow)
    customer_id = db.Column(db.Integer, db.ForeignKey('account_masters.id'))
    customer = db.relationship('AccountMaster', foreign_keys=[customer_id], backref='prescriptions')
    doctor_id = db.Column(db.Integer, db.ForeignKey('account_masters.id'))
    doctor = db.relationship('AccountMaster', foreign_keys=[doctor_id])
    doctor_name = db.Column(db.String(100))
    diagnosis = db.Column(db.Text)
    notes = db.Column(db.Text)
    image_path = db.Column(db.String(500))
    expiry_date = db.Column(db.Date)
    is_active = db.Column(db.Boolean, default=True)
    created_at = db.Column(db.DateTime, default=datetime.utcnow)
    
    def __repr__(self):
        return f'<Prescription {self.prescription_no}>'

class Doctor(db.Model):
    __tablename__ = 'doctors'
    
    id = db.Column(db.Integer, primary_key=True)
    doctor_code = db.Column(db.String(20), unique=True, nullable=False)
    doctor_name = db.Column(db.String(100), nullable=False)
    specialization = db.Column(db.String(100))
    degree = db.Column(db.String(100))
    address = db.Column(db.Text)
    phone = db.Column(db.String(20))
    mobile = db.Column(db.String(15))
    email = db.Column(db.String(120))
    hospital = db.Column(db.String(200))
    is_active = db.Column(db.Boolean, default=True)
    created_at = db.Column(db.DateTime, default=datetime.utcnow)
    
    def __repr__(self):
        return f'<Doctor {self.doctor_name}>'

class Settings(db.Model):
    __tablename__ = 'settings'
    
    id = db.Column(db.Integer, primary_key=True)
    setting_key = db.Column(db.String(50), unique=True, nullable=False, index=True)
    setting_value = db.Column(db.Text)
    setting_type = db.Column(db.String(20), default='string')
    description = db.Column(db.String(200))
    category = db.Column(db.String(50), default='general')
    is_active = db.Column(db.Boolean, default=True)
    updated_at = db.Column(db.DateTime, default=datetime.utcnow, onupdate=datetime.utcnow)
    
    def __repr__(self):
        return f'<Setting {self.setting_key}>'
    
    @classmethod
    def get_value(cls, key, default=None):
        setting = cls.query.filter_by(setting_key=key).first()
        return setting.setting_value if setting else default

class SMSLog(db.Model):
    __tablename__ = 'sms_logs'
    
    id = db.Column(db.Integer, primary_key=True)
    mobile_no = db.Column(db.String(15), nullable=False)
    message = db.Column(db.Text, nullable=False)
    template_id = db.Column(db.String(50))
    status = db.Column(db.String(20), default='pending')  # pending, sent, failed, delivered
    response = db.Column(db.Text)
    sent_by = db.Column(db.Integer, db.ForeignKey('users.id'))
    sent_at = db.Column(db.DateTime, default=datetime.utcnow)
    
    def __repr__(self):
        return f'<SMS to {self.mobile_no}: {self.status}>'

class Salesman(db.Model):
    __tablename__ = 'salesmen'
    
    id = db.Column(db.Integer, primary_key=True)
    salesman_code = db.Column(db.String(20), unique=True, nullable=False)
    salesman_name = db.Column(db.String(100), nullable=False)
    phone = db.Column(db.String(20))
    mobile = db.Column(db.String(15))
    address = db.Column(db.Text)
    commission_perc = db.Column(db.Numeric(5, 2), default=0)
    is_active = db.Column(db.Boolean, default=True)
    created_at = db.Column(db.DateTime, default=datetime.utcnow)
    
    def __repr__(self):
        return f'<Salesman {self.salesman_name}>'