from flask import Blueprint, request, jsonify, redirect, url_for, flash
from flask_login import login_required, current_user
from app import db, csrf
from app.models import Payment, Invoice, AccountMaster
from datetime import datetime
from decimal import Decimal

payments_bp = Blueprint('payments', __name__)

def generate_payment_no():
    last_payment = Payment.query.order_by(Payment.id.desc()).first()
    if last_payment and last_payment.payment_no:
        try:
            num = int(last_payment.payment_no.split('-')[-1]) + 1
            return f'REC-{datetime.now().strftime("%d%m%y")}-{num:05d}'
        except:
            pass
    return f'REC-{datetime.now().strftime("%d%m%y")}-00001'


@payments_bp.route('/create', methods=['POST'])
@login_required
@csrf.exempt
def create():
    try:
        invoice_id = request.form.get('invoice_id', type=int)
        amount = Decimal(str(request.form.get('amount', 0)))  # Convert to Decimal
        payment_mode = request.form.get('payment_mode', 'cash')
        reference_no = request.form.get('reference_no', '')
        remarks = request.form.get('remarks', '')
        
        if not invoice_id:
            return jsonify({'success': False, 'error': 'Invoice ID is required'})
        
        invoice = Invoice.query.get(invoice_id)
        if not invoice:
            return jsonify({'success': False, 'error': 'Invoice not found'})
        
        if not amount or amount <= 0:
            return jsonify({'success': False, 'error': 'Invalid payment amount'})
        
        # Create payment record
        payment = Payment(
            payment_no=generate_payment_no(),
            payment_date=datetime.utcnow(),
            invoice_id=invoice_id,
            account_id=invoice.customer_id,
            amount=amount,
            payment_type='receipt',
            payment_mode=payment_mode,
            reference_no=reference_no,
            remarks=remarks,
            user_id=current_user.id
        )
        db.session.add(payment)
        
        # Update invoice payment (using Decimal arithmetic)
        if payment_mode == 'cash':
            invoice.cash_amount = (invoice.cash_amount or Decimal('0')) + amount
        elif payment_mode == 'card':
            invoice.card_amount = (invoice.card_amount or Decimal('0')) + amount
        elif payment_mode == 'upi':
            invoice.gpay_amount = (invoice.gpay_amount or Decimal('0')) + amount
        elif payment_mode == 'online':
            invoice.online_amount = (invoice.online_amount or Decimal('0')) + amount
        elif payment_mode == 'cheque':
            invoice.card_amount = (invoice.card_amount or Decimal('0')) + amount
        
        # Calculate total received (all Decimal)
        total_received = (
            (invoice.cash_amount or Decimal('0')) + 
            (invoice.card_amount or Decimal('0')) + 
            (invoice.gpay_amount or Decimal('0')) + 
            (invoice.online_amount or Decimal('0'))
        )
        total_amount = invoice.total_amount or Decimal('0')
        
        # Update payment status
        if total_received >= total_amount:
            invoice.payment_status = 'paid'
            invoice.credit_amount = Decimal('0')
        else:
            invoice.payment_status = 'partial'
            invoice.credit_amount = total_amount - total_received
        
        db.session.commit()
        
        return jsonify({'success': True, 'payment_id': payment.id})
    
    except Exception as e:
        db.session.rollback()
        return jsonify({'success': False, 'error': str(e)})


@payments_bp.route('/payments')
@login_required
def list():
    page = request.args.get('page', 1, type=int)
    per_page = request.args.get('per_page', 50, type=int)
    
    payments = Payment.query.filter_by(payment_type='receipt').order_by(Payment.payment_date.desc()).paginate(
        page=page, per_page=per_page, error_out=False
    )
    
    return payments
