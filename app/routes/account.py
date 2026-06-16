from flask import Blueprint, render_template, request, redirect, url_for, flash, jsonify
from flask_login import login_required, current_user
from app import db
from app.models import AccountMaster

account_bp = Blueprint('account', __name__, url_prefix='/account')

@account_bp.route('/account-masters')
@login_required
def account_masters():
    """List all account masters"""
    page = request.args.get('page', 1, type=int)
    per_page = 50
    search = request.args.get('search', '')
    
    query = AccountMaster.query
    
    if search:
        query = query.filter(
            db.or_(
                AccountMaster.account_name.ilike(f'%{search}%'),
                AccountMaster.account_code.ilike(f'%{search}%')
            )
        )
    
    accounts = query.order_by(AccountMaster.account_name).paginate(
        page=page, per_page=per_page, error_out=False
    )
    
    return render_template('account/account_masters.html', accounts=accounts, search=search)

@account_bp.route('/payable')
@login_required
def payable():
    """Show amount payable to suppliers"""
    return render_template('account/payable.html')

@account_bp.route('/receivable')
@login_required
def receivable():
    """Show account receivable from customers"""
    return render_template('account/receivable.html')

@account_bp.route('/voucher')
@login_required
def voucher():
    """General voucher entry"""
    return render_template('account/voucher.html')

@account_bp.route('/bank-reconciliation')
@login_required
def bank_reconciliation():
    """Bank reconciliation"""
    return render_template('account/bank_reconciliation.html')
