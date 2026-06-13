from flask import Blueprint, render_template, request, redirect, url_for, flash, jsonify
from flask_login import login_required, current_user
from app import db
from app.models import Product, Invoice, Purchase, AccountMaster, Batch, StockAdjustment
from sqlalchemy import func, and_
from datetime import datetime, timedelta
import calendar

main_bp = Blueprint('main', __name__)

@main_bp.route('/')
def index():
    if current_user.is_authenticated:
        return redirect(url_for('main.dashboard'))
    return redirect(url_for('auth.login'))

@main_bp.route('/dashboard')
@login_required
def dashboard():
    today = datetime.utcnow().date()
    first_day_month = today.replace(day=1)
    last_day_month = today.replace(day=calendar.monthrange(today.year, today.month)[1])
    
    # Get counts
    total_products = Product.query.filter_by(is_active=True).count()
    total_customers = AccountMaster.query.filter_by(account_type='customer', is_active=True).count()
    total_suppliers = AccountMaster.query.filter_by(account_type='supplier', is_active=True).count()
    
    # Today's sales
    today_sales = db.session.query(func.sum(Invoice.total_amount)).filter(
        Invoice.invoice_type == 'sale',
        func.date(Invoice.invoice_date) == today,
        Invoice.is_cancelled == False
    ).scalar() or 0
    
    today_sales_count = Invoice.query.filter(
        Invoice.invoice_type == 'sale',
        func.date(Invoice.invoice_date) == today,
        Invoice.is_cancelled == False
    ).count()
    
    # Today's purchases
    today_purchases = db.session.query(func.sum(Purchase.total_amount)).filter(
        func.date(Purchase.purchase_date) == today
    ).scalar() or 0
    
    # Monthly sales
    monthly_sales = db.session.query(func.sum(Invoice.total_amount)).filter(
        Invoice.invoice_type == 'sale',
        Invoice.invoice_date >= first_day_month,
        Invoice.invoice_date <= last_day_month,
        Invoice.is_cancelled == False
    ).scalar() or 0
    
    # Low stock products
    low_stock_products = Product.query.filter(
        Product.is_active == True
    ).all()
    low_stock = []
    for p in low_stock_products:
        if p.current_stock <= p.reorder_level:
            low_stock.append({
                'id': p.id,
                'code': p.product_code,
                'name': p.product_name,
                'stock': p.current_stock,
                'reorder': p.reorder_level
            })
    
    # Recent sales
    recent_sales = Invoice.query.filter(
        Invoice.invoice_type == 'sale',
        Invoice.is_cancelled == False
    ).order_by(Invoice.invoice_date.desc()).limit(10).all()
    
    # Credit customers
    credit_customers = AccountMaster.query.filter(
        AccountMaster.account_type == 'customer',
        AccountMaster.is_active == True,
        AccountMaster.balance < 0
    ).order_by(AccountMaster.balance).limit(10).all()
    
    # Expiring batches (within 30 days)
    expiring_batches = Batch.query.filter(
        Batch.expiry_date != None,
        Batch.expiry_date <= today + timedelta(days=30),
        Batch.available_qty > 0
    ).order_by(Batch.expiry_date).limit(10).all()
    
    return render_template('main/dashboard.html',
                         total_products=total_products,
                         total_customers=total_customers,
                         total_suppliers=total_suppliers,
                         today_sales=today_sales,
                         today_sales_count=today_sales_count,
                         today_purchases=today_purchases,
                         monthly_sales=monthly_sales,
                         low_stock=low_stock,
                         recent_sales=recent_sales,
                         credit_customers=credit_customers,
                         expiring_batches=expiring_batches)

@main_bp.route('/quick-view')
@login_required
def quick_view():
    return render_template('main/quick_view.html')

@main_bp.route('/search')
@login_required
def search():
    query = request.args.get('q', '')
    search_type = request.args.get('type', 'all')
    
    results = {'products': [], 'customers': [], 'suppliers': [], 'invoices': []}
    
    if query:
        if search_type in ['all', 'products']:
            results['products'] = Product.query.filter(
                Product.is_active == True,
                (Product.product_code.ilike(f'%{query}%') | 
                 Product.product_name.ilike(f'%{query}%') |
                 Product.generic_name.ilike(f'%{query}%'))
            ).limit(20).all()
        
        if search_type in ['all', 'customers']:
            results['customers'] = AccountMaster.query.filter(
                AccountMaster.account_type == 'customer',
                AccountMaster.is_active == True,
                (AccountMaster.account_code.ilike(f'%{query}%') | 
                 AccountMaster.account_name.ilike(f'%{query}%'))
            ).limit(20).all()
        
        if search_type in ['all', 'suppliers']:
            results['suppliers'] = AccountMaster.query.filter(
                AccountMaster.account_type == 'supplier',
                AccountMaster.is_active == True,
                (AccountMaster.account_code.ilike(f'%{query}%') | 
                 AccountMaster.account_name.ilike(f'%{query}%'))
            ).limit(20).all()
        
        if search_type in ['all', 'invoices']:
            results['invoices'] = Invoice.query.filter(
                Invoice.invoice_no.ilike(f'%{query}%')
            ).limit(20).all()
    
    return jsonify(results)

@main_bp.route('/api/dashboard-stats')
@login_required
def dashboard_stats():
    today = datetime.utcnow().date()
    
    # Today's sales
    today_sales = db.session.query(func.sum(Invoice.total_amount)).filter(
        Invoice.invoice_type == 'sale',
        func.date(Invoice.invoice_date) == today,
        Invoice.is_cancelled == False
    ).scalar() or 0
    
    today_sales_count = Invoice.query.filter(
        Invoice.invoice_type == 'sale',
        func.date(Invoice.invoice_date) == today,
        Invoice.is_cancelled == False
    ).count()
    
    # Total stock value
    stock_value = db.session.query(func.sum(Batch.available_qty * Batch.purchase_rate)).filter(
        Batch.available_qty > 0
    ).scalar() or 0
    
    # Credit amount
    credit_amount = db.session.query(func.sum(AccountMaster.balance)).filter(
        AccountMaster.account_type == 'customer',
        AccountMaster.balance < 0
    ).scalar() or 0
    
    return jsonify({
        'today_sales': float(today_sales),
        'today_sales_count': today_sales_count,
        'stock_value': float(stock_value),
        'credit_amount': abs(float(credit_amount)) if credit_amount else 0
    })