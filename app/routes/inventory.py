from flask import Blueprint, render_template, request, redirect, url_for, flash, jsonify
from flask_login import login_required, current_user
from app import db
from app.models import Product, Batch, StockAdjustment, StockAdjustmentItem, Rack, Category
from sqlalchemy import func, and_, or_
from datetime import datetime, timedelta
from io import BytesIO
import uuid

inventory_bp = Blueprint('inventory', __name__)

@inventory_bp.route('/')
@login_required
def index():
    return redirect(url_for('inventory.stock'))

@inventory_bp.route('/stock')
@login_required
def stock():
    page = request.args.get('page', 1, type=int)
    per_page = request.args.get('per_page', 50, type=int)
    search = request.args.get('search', '')
    category = request.args.get('category', '')
    stock_filter = request.args.get('stock_filter', '')
    
    query = db.session.query(
        Product,
        func.coalesce(func.sum(Batch.available_qty), 0).label('total_stock')
    ).outerjoin(Batch, and_(Batch.product_id == Product.id, Batch.available_qty > 0)).filter(
        Product.is_active == True
    ).group_by(Product.id)
    
    if search:
        query = query.filter(
            or_(
                Product.product_code.ilike(f'%{search}%'),
                Product.product_name.ilike(f'%{search}%'),
                Product.generic_name.ilike(f'%{search}%')
            )
        )
    
    if category:
        query = query.filter(Product.category_id == category)
    
    if stock_filter == 'low':
        query = query.having(func.coalesce(func.sum(Batch.available_qty), 0) <= Product.reorder_level)
    elif stock_filter == 'out':
        query = query.having(func.coalesce(func.sum(Batch.available_qty), 0) == 0)
    
    stock_data = query.order_by(Product.product_name).paginate(page=page, per_page=per_page, error_out=False)
    
    categories = Category.query.filter_by(is_active=True).order_by(Category.category_name).all()
    
    return render_template('inventory/stock.html',
                         stock_data=stock_data,
                         categories=categories,
                         search=search,
                         selected_category=category,
                         stock_filter=stock_filter)

@inventory_bp.route('/batch-stock/<int:product_id>')
@login_required
def batch_stock(product_id):
    product = Product.query.get_or_404(product_id)
    batches = Batch.query.filter_by(product_id=product_id).filter(Batch.available_qty > 0).order_by(Batch.expiry_date).all()
    
    return render_template('inventory/batch_stock.html', product=product, batches=batches)

@inventory_bp.route('/adjustments')
@login_required
def adjustments():
    page = request.args.get('page', 1, type=int)
    per_page = request.args.get('per_page', 50, type=int)
    
    adjustments = StockAdjustment.query.order_by(StockAdjustment.adj_date.desc()).paginate(page=page, per_page=per_page, error_out=False)
    
    return render_template('inventory/adjustments.html', adjustments=adjustments)

@inventory_bp.route('/adjustments/new')
@login_required
def new_adjustment():
    return render_template('inventory/adjustment_new.html')

@inventory_bp.route('/adjustments/create', methods=['POST'])
@login_required
def create_adjustment():
    try:
        adj_no = f'SADJ{datetime.utcnow().strftime("%Y%m%d%H%M%S")}'
        
        adjustment = StockAdjustment(
            adj_no=adj_no,
            adj_date=datetime.utcnow(),
            adj_type=request.form.get('adj_type', 'remove'),
            reason=request.form.get('reason', ''),
            user_id=current_user.id,
            status='approved'
        )
        
        db.session.add(adjustment)
        db.session.flush()
        
        product_ids = request.form.getlist('product_id', type=int)
        batch_ids = request.form.getlist('batch_id', type=int)
        current_qtys = request.form.getlist('current_qty', type=int)
        adj_qtys = request.form.getlist('adj_qty', type=int)
        reasons = request.form.getlist('item_reason')
        
        total_qty = 0
        for i, product_id in enumerate(product_ids):
            if not product_id:
                continue
            
            new_qty = current_qtys[i] + adj_qtys[i] if adjustment.adj_type == 'add' else current_qtys[i] - abs(adj_qtys[i])
            
            item = StockAdjustmentItem(
                adj_id=adjustment.id,
                product_id=product_id,
                batch_id=batch_ids[i] if i < len(batch_ids) and batch_ids[i] else None,
                current_qty=current_qtys[i],
                adj_qty=adj_qtys[i],
                new_qty=new_qty,
                reason=reasons[i] if i < len(reasons) else ''
            )
            db.session.add(item)
            total_qty += abs(adj_qtys[i])
            
            # Update batch
            if batch_ids[i] and i < len(batch_ids) and batch_ids[i]:
                batch = Batch.query.get(batch_ids[i])
                if batch:
                    batch.available_qty = new_qty
        
        adjustment.total_items = len(product_ids)
        adjustment.total_qty = total_qty
        adjustment.approved_by = current_user.id
        adjustment.approved_at = datetime.utcnow()
        
        db.session.commit()
        
        flash(f'Stock adjustment {adj_no} created successfully.', 'success')
        return jsonify({'success': True, 'adj_no': adj_no})
    
    except Exception as e:
        db.session.rollback()
        flash(f'Error creating adjustment: {str(e)}', 'error')
        return jsonify({'success': False, 'error': str(e)}), 400

@inventory_bp.route('/adjustments/<int:id>')
@login_required
def view_adjustment(id):
    adjustment = StockAdjustment.query.get_or_404(id)
    return render_template('inventory/adjustment_view.html', adjustment=adjustment)

@inventory_bp.route('/expiry-report')
@login_required
def expiry_report():
    days = request.args.get('days', 30, type=int)
    cutoff_date = datetime.utcnow().date() + timedelta(days=days)
    today = datetime.utcnow().date()
    
    batches = Batch.query.filter(
        Batch.expiry_date != None,
        Batch.expiry_date <= cutoff_date,
        Batch.available_qty > 0
    ).order_by(Batch.expiry_date).all()
    
    # Calculate summary
    expired = sum(1 for b in batches if b.expiry_date < today)
    expiring_30 = sum(1 for b in batches if b.expiry_date and (b.expiry_date - today).days <= 30)
    expiring_60 = sum(1 for b in batches if b.expiry_date and 30 < (b.expiry_date - today).days <= 60)
    expiring_90 = sum(1 for b in batches if b.expiry_date and 60 < (b.expiry_date - today).days <= 90)
    
    summary = {
        'total': len(batches),
        'expired': expired,
        'expiring_30': expiring_30,
        'expiring_60': expiring_60,
        'expiring_90': expiring_90
    }
    
    return render_template('inventory/expiry_report.html', batches=batches, days=days, summary=summary, expiry_days=days, today=today)

@inventory_bp.route('/stock-transfer')
@login_required
def stock_transfer():
    racks = Rack.query.filter_by(is_active=True).order_by(Rack.rack_name).all()
    return render_template('inventory/stock_transfer.html', racks=racks)

@inventory_bp.route('/transfer/create', methods=['POST'])
@login_required
def create_transfer():
    try:
        from_rack_id = request.form.get('from_rack_id', type=int)
        to_rack_id = request.form.get('to_rack_id', type=int)
        product_id = request.form.get('product_id', type=int)
        quantity = request.form.get('quantity', 0, type=int)
        
        if not all([from_rack_id, to_rack_id, product_id, quantity]):
            return jsonify({'success': False, 'error': 'All fields are required'}), 400
        
        # Find batch in source rack
        batch = Batch.query.filter_by(
            product_id=product_id,
            rack_id=from_rack_id
        ).filter(Batch.available_qty >= quantity).first()
        
        if not batch:
            return jsonify({'success': False, 'error': 'Insufficient stock or batch not found'}), 400
        
        # Create new batch in destination rack
        new_batch = Batch(
            batch_no=batch.batch_no,
            product_id=product_id,
            expiry_date=batch.expiry_date,
            purchase_rate=batch.purchase_rate,
            mrp=batch.mrp,
            sale_rate=batch.sale_rate,
            quantity=quantity,
            available_qty=quantity,
            rack_id=to_rack_id
        )
        db.session.add(new_batch)
        
        # Reduce from source
        batch.available_qty -= quantity
        
        db.session.commit()
        
        flash(f'Transferred {quantity} units successfully.', 'success')
        return jsonify({'success': True})
    
    except Exception as e:
        db.session.rollback()
        return jsonify({'success': False, 'error': str(e)}), 400

# Rack management
@inventory_bp.route('/racks')
@login_required
def racks():
    racks = Rack.query.order_by(Rack.rack_name).all()
    return render_template('inventory/racks.html', racks=racks)

@inventory_bp.route('/racks/add', methods=['POST'])
@login_required
def add_rack():
    rack_code = request.form.get('rack_code', '').strip()
    rack_name = request.form.get('rack_name', '').strip()
    
    if Rack.query.filter_by(rack_code=rack_code).first():
        flash('Rack code already exists.', 'error')
        return redirect(url_for('inventory.racks'))
    
    rack = Rack(
        rack_code=rack_code,
        rack_name=rack_name,
        location=request.form.get('location', '')
    )
    
    db.session.add(rack)
    db.session.commit()
    
    flash('Rack added successfully.', 'success')
    return redirect(url_for('inventory.racks'))

# Barcode generation
@inventory_bp.route('/barcode/<barcode>')
@login_required
def get_by_barcode(barcode):
    product = Product.query.filter_by(barcode=barcode, is_active=True).first()
    if not product:
        return jsonify({'error': 'Product not found'}), 404
    
    batch = Batch.query.filter_by(product_id=product.id).filter(Batch.available_qty > 0).order_by(Batch.expiry_date).first()
    
    return jsonify({
        'id': product.id,
        'product_code': product.product_code,
        'product_name': product.product_name,
        'mrp': float(product.mrp) if product.mrp else 0,
        'batch_id': batch.id if batch else None,
        'batch_no': batch.batch_no if batch else None,
        'expiry_date': batch.expiry_date.isoformat() if batch and batch.expiry_date else None,
        'available_qty': batch.available_qty if batch else 0,
        'sale_rate': float(batch.sale_rate) if batch and batch.sale_rate else float(product.rate)
    })