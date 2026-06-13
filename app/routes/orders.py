from flask import Blueprint, render_template, request, redirect, url_for, flash, jsonify
from flask_login import login_required, current_user
from app import db
from app.models import PurchaseOrder, PurchaseOrderItem, Product, AccountMaster, Batch
from sqlalchemy import or_
from datetime import datetime
import uuid

orders_bp = Blueprint('orders', __name__, url_prefix='/orders')

def generate_order_no():
    today = datetime.utcnow()
    prefix = f"PO{today.strftime('%y%m%d')}"
    last_order = PurchaseOrder.query.filter(
        PurchaseOrder.order_no.like(f'{prefix}%')
    ).order_by(PurchaseOrder.id.desc()).first()
    
    if last_order:
        try:
            num = int(last_order.order_no[-4:]) + 1
            return f"{prefix}{num:04d}"
        except:
            return f"{prefix}0001"
    return f"{prefix}0001"

@orders_bp.route('/')
@login_required
def list():
    page = request.args.get('page', 1, type=int)
    per_page = request.args.get('per_page', 50, type=int)
    search = request.args.get('search', '')
    status = request.args.get('status', '')
    supplier = request.args.get('supplier', '')
    
    query = PurchaseOrder.query
    
    if search:
        query = query.filter(
            or_(
                PurchaseOrder.order_no.ilike(f'%{search}%'),
                PurchaseOrder.remarks.ilike(f'%{search}%')
            )
        )
    
    if status:
        query = query.filter_by(status=status)
    
    if supplier:
        query = query.filter_by(supplier_id=supplier)
    
    orders = query.order_by(PurchaseOrder.order_date.desc()).paginate(
        page=page, per_page=per_page, error_out=False
    )
    
    suppliers = AccountMaster.query.filter_by(account_type='supplier', is_active=True).order_by(AccountMaster.account_name).all()
    
    return render_template('orders/list.html',
                         orders=orders,
                         suppliers=suppliers,
                         search=search,
                         selected_status=status,
                         selected_supplier=supplier)

@orders_bp.route('/new', methods=['GET', 'POST'])
@login_required
def new():
    if request.method == 'POST':
        supplier_id = request.form.get('supplier_id', type=int)
        expected_date = request.form.get('expected_date')
        remarks = request.form.get('remarks', '')
        
        if not supplier_id:
            flash('Please select a supplier.', 'error')
            return redirect(url_for('orders.new'))
        
        # Create order
        order = PurchaseOrder(
            order_no=generate_order_no(),
            supplier_id=supplier_id,
            expected_date=datetime.strptime(expected_date, '%Y-%m-%d').date() if expected_date else None,
            remarks=remarks,
            user_id=current_user.id
        )
        db.session.add(order)
        db.session.flush()  # Get order ID
        
        # Add items
        product_ids = request.form.getlist('product_id')
        quantities = request.form.getlist('quantity')
        rates = request.form.getlist('rate')
        mrps = request.form.getlist('mrp')
        
        subtotal = 0
        for i, product_id in enumerate(product_ids):
            if not product_id or not quantities[i]:
                continue
            
            product = Product.query.get(int(product_id))
            if not product:
                continue
            
            qty = int(quantities[i])
            rate = float(rates[i]) if rates[i] else 0
            mrp = float(mrps[i]) if mrps[i] else 0
            tax_perc = float(product.tax_perc) if product.tax_perc else 0
            
            discount_amt = 0
            tax_amt = (qty * rate) * (tax_perc / 100)
            amount = (qty * rate) + tax_amt - discount_amt
            
            item = PurchaseOrderItem(
                order_id=order.id,
                product_id=int(product_id),
                quantity=qty,
                unit_rate=rate,
                mrp=mrp,
                discount_perc=0,
                discount_amt=discount_amt,
                tax_perc=tax_perc,
                tax_amt=tax_amt,
                amount=amount
            )
            db.session.add(item)
            subtotal += amount
        
        order.subtotal = subtotal
        order.tax_amt = sum([(float(quantities[i]) * float(rates[i]) if rates[i] else 0) * (float(Product.query.get(int(product_ids[i]).tax_perc) if product_ids[i] else 0) / 100) for i in range(len(product_ids))])
        order.total_amount = subtotal
        
        db.session.commit()
        flash(f'Purchase Order {order.order_no} created successfully.', 'success')
        return redirect(url_for('orders.view', order_id=order.id))
    
    suppliers = AccountMaster.query.filter_by(account_type='supplier', is_active=True).order_by(AccountMaster.account_name).all()
    return render_template('orders/new.html', suppliers=suppliers)

@orders_bp.route('/<int:order_id>')
@login_required
def view(order_id):
    order = PurchaseOrder.query.get_or_404(order_id)
    return render_template('orders/view.html', order=order)

@orders_bp.route('/<int:order_id>/edit', methods=['GET', 'POST'])
@login_required
def edit(order_id):
    order = PurchaseOrder.query.get_or_404(order_id)
    
    if order.status not in ['pending']:
        flash('Only pending orders can be edited.', 'error')
        return redirect(url_for('orders.view', order_id=order.id))
    
    if request.method == 'POST':
        order.supplier_id = request.form.get('supplier_id', type=int, default=order.supplier_id)
        order.expected_date = datetime.strptime(request.form.get('expected_date'), '%Y-%m-%d') if request.form.get('expected_date') else order.expected_date
        order.remarks = request.form.get('remarks', '')
        
        # Update items
        PurchaseOrderItem.query.filter_by(order_id=order.id).delete()
        
        product_ids = request.form.getlist('product_id')
        quantities = request.form.getlist('quantity')
        rates = request.form.getlist('rate')
        
        subtotal = 0
        for i, product_id in enumerate(product_ids):
            if not product_id or not quantities[i]:
                continue
            
            product = Product.query.get(int(product_id))
            if not product:
                continue
            
            qty = int(quantities[i])
            rate = float(rates[i]) if rates[i] else 0
            tax_perc = float(product.tax_perc) if product.tax_perc else 0
            tax_amt = (qty * rate) * (tax_perc / 100)
            amount = (qty * rate) + tax_amt
            
            item = PurchaseOrderItem(
                order_id=order.id,
                product_id=int(product_id),
                quantity=qty,
                unit_rate=rate,
                tax_perc=tax_perc,
                tax_amt=tax_amt,
                amount=amount
            )
            db.session.add(item)
            subtotal += amount
        
        order.subtotal = subtotal
        order.total_amount = subtotal
        
        db.session.commit()
        flash(f'Purchase Order {order.order_no} updated successfully.', 'success')
        return redirect(url_for('orders.view', order_id=order.id))
    
    suppliers = AccountMaster.query.filter_by(account_type='supplier', is_active=True).order_by(AccountMaster.account_name).all()
    return render_template('orders/edit.html', order=order, suppliers=suppliers)

@orders_bp.route('/<int:order_id>/delete', methods=['POST'])
@login_required
def delete(order_id):
    order = PurchaseOrder.query.get_or_404(order_id)
    
    if order.status not in ['pending']:
        flash('Only pending orders can be deleted.', 'error')
        return redirect(url_for('orders.list'))
    
    order_no = order.order_no
    order.is_cancelled = True
    db.session.commit()
    
    flash(f'Purchase Order {order_no} cancelled.', 'success')
    return redirect(url_for('orders.list'))

@orders_bp.route('/<int:order_id>/receive', methods=['GET', 'POST'])
@login_required
def receive(order_id):
    """Receive purchase order items as stock"""
    order = PurchaseOrder.query.get_or_404(order_id)
    
    if order.status == 'received':
        flash('Order already fully received.', 'error')
        return redirect(url_for('orders.view', order_id=order.id))
    
    if request.method == 'POST':
        # Create purchase from order
        from app.models import Purchase, PurchaseItem
        from flask import current_app
        
        purchase_no = f"PO{order.order_no}"
        
        purchase = Purchase(
            purchase_no=purchase_no,
            supplier_id=order.supplier_id,
            invoice_no=order.order_no,
            invoice_date=order.order_date.date(),
            subtotal=order.subtotal,
            discount_amt=order.discount_amt,
            tax_amt=order.tax_amt,
            total_amount=order.total_amount,
            remarks=f"Created from PO {order.order_no}",
            user_id=current_user.id
        )
        db.session.add(purchase)
        db.session.flush()
        
        # Add purchase items and update stock
        for item in order.items:
            product = Product.query.get(item.product_id)
            
            # Create purchase item
            purchase_item = PurchaseItem(
                purchase_id=purchase.id,
                product_id=item.product_id,
                quantity=item.quantity,
                purchase_rate=item.unit_rate,
                mrp=item.mrp,
                discount_perc=item.discount_perc,
                discount_amt=item.discount_amt,
                tax_perc=item.tax_perc,
                tax_amt=item.tax_amt,
                amount=item.amount
            )
            db.session.add(purchase_item)
            
            # Update stock
            product.current_stock += item.quantity
            product.save()
            
            # Create/update batch
            batch = Batch.query.filter_by(
                product_id=item.product_id,
                batch_no=f"PO-{item.id}"
            ).first()
            
            if not batch:
                batch = Batch(
                    product_id=item.product_id,
                    batch_no=f"PO-{item.id}",
                    purchase_rate=item.unit_rate,
                    mrp=item.mrp,
                    sale_rate=product.rate if product.rate else 0,
                    available_qty=item.quantity,
                    purchase_id=purchase.id
                )
                db.session.add(batch)
        
        # Update order status
        order.status = 'received'
        db.session.commit()
        
        flash(f'Purchase Order {order.order_no} received and stock updated.', 'success')
        return redirect(url_for('orders.view', order_id=order.id))
    
    return render_template('orders/receive.html', order=order)

@orders_bp.route('/<int:order_id>/print')
@login_required
def print_order(order_id):
    order = PurchaseOrder.query.get_or_404(order_id)
    return render_template('orders/print.html', order=order)

@orders_bp.route('/api/supplier-products')
@login_required
def supplier_products():
    """Get products for a supplier (based on previous purchases)"""
    supplier_id = request.args.get('supplier_id', type=int)
    
    if not supplier_id:
        return jsonify([])
    
    # Get products previously purchased from this supplier
    products = db.session.query(Product).join(
        PurchaseItem, PurchaseItem.product_id == Product.id
    ).join(
        Purchase, Purchase.id == PurchaseItem.purchase_id
    ).filter(
        Purchase.supplier_id == supplier_id
    ).group_by(Product.id).limit(50).all()
    
    return jsonify([{
        'id': p.id,
        'product_code': p.product_code,
        'product_name': p.product_name,
        'mrp': float(p.mrp) if p.mrp else 0,
        'rate': float(p.rate) if p.rate else 0,
        'stock': p.current_stock
    } for p in products])

@orders_bp.route('/api/all-products')
@login_required
def all_products():
    """Get all products for PO creation"""
    search = request.args.get('q', '')
    query = Product.query.filter_by(is_active=True)
    
    if search:
        query = query.filter(
            or_(
                Product.product_code.ilike(f'%{search}%'),
                Product.product_name.ilike(f'%{search}%'),
                Product.generic_name.ilike(f'%{search}%')
            )
        )
    
    products = query.order_by(Product.product_name).limit(50).all()
    
    return jsonify([{
        'id': p.id,
        'product_code': p.product_code,
        'product_name': p.product_name,
        'generic_name': p.generic_name,
        'mrp': float(p.mrp) if p.mrp else 0,
        'rate': float(p.rate) if p.rate else 0,
        'stock': p.current_stock
    } for p in products])