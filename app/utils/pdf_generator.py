"""
PDF Generation Utilities for BillMyMed
"""
from io import BytesIO
from datetime import datetime
from flask import make_response
from weasyprint import HTML, CSS

def get_company_config():
    """Get company configuration for PDF headers"""
    return {
        'name': 'BillMyMed Pharma',
        'address': 'Your Pharmacy Address',
        'phone': '+91 XXXXX XXXXX',
        'email': 'contact@billmymed.com',
        'gstin': 'XXXXXXXXXXXXXX'
    }

def get_pdf_css():
    """Get CSS styling for PDF generation"""
    return CSS(string='''
        @page {
            size: A4;
            margin: 1cm;
            @top-center {
                content: "BillMyMed Pharma";
                font-size: 10px;
                color: #666;
            }
            @bottom-center {
                content: "Page " counter(page) " of " counter(pages);
                font-size: 10px;
                color: #666;
            }
        }
        
        body {
            font-family: 'Helvetica', 'Arial', sans-serif;
            font-size: 12px;
            line-height: 1.4;
            color: #333;
        }
        
        .header {
            text-align: center;
            margin-bottom: 20px;
            padding-bottom: 15px;
            border-bottom: 2px solid #4f46e5;
        }
        
        .header h1 {
            font-size: 24px;
            margin: 0;
            color: #4f46e5;
        }
        
        .header p {
            margin: 5px 0;
            font-size: 11px;
            color: #666;
        }
        
        .report-title {
            font-size: 18px;
            font-weight: bold;
            margin: 20px 0 10px;
            color: #333;
        }
        
        .date-range {
            font-size: 12px;
            color: #666;
            margin-bottom: 15px;
        }
        
        .filters {
            background: #f5f5f5;
            padding: 10px 15px;
            border-radius: 5px;
            margin-bottom: 20px;
            font-size: 11px;
        }
        
        .summary-cards {
            display: flex;
            flex-wrap: wrap;
            gap: 15px;
            margin-bottom: 20px;
        }
        
        .summary-card {
            flex: 1;
            min-width: 150px;
            padding: 15px;
            background: #f8fafc;
            border-radius: 8px;
            border-left: 4px solid #4f46e5;
        }
        
        .summary-card.success {
            border-left-color: #10b981;
        }
        
        .summary-card.warning {
            border-left-color: #f59e0b;
        }
        
        .summary-card.danger {
            border-left-color: #ef4444;
        }
        
        .summary-card h5 {
            margin: 0 0 5px;
            font-size: 11px;
            text-transform: uppercase;
            color: #666;
        }
        
        .summary-card .value {
            font-size: 20px;
            font-weight: bold;
            color: #333;
        }
        
        table {
            width: 100%;
            border-collapse: collapse;
            margin-bottom: 20px;
        }
        
        th {
            background: #4f46e5;
            color: white;
            padding: 10px 8px;
            text-align: left;
            font-size: 11px;
            text-transform: uppercase;
        }
        
        td {
            padding: 8px;
            border-bottom: 1px solid #eee;
            font-size: 11px;
        }
        
        tr:nth-child(even) {
            background: #f9fafb;
        }
        
        tr:hover {
            background: #f1f5f9;
        }
        
        .text-right {
            text-align: right;
        }
        
        .text-center {
            text-align: center;
        }
        
        .text-bold {
            font-weight: bold;
        }
        
        .total-row {
            background: #f1f5f9 !important;
            font-weight: bold;
        }
        
        .footer {
            margin-top: 30px;
            padding-top: 15px;
            border-top: 1px solid #ddd;
            font-size: 10px;
            color: #666;
            text-align: center;
        }
        
        .badge {
            padding: 2px 8px;
            border-radius: 10px;
            font-size: 10px;
            font-weight: bold;
        }
        
        .badge-success {
            background: #d1fae5;
            color: #065f46;
        }
        
        .badge-warning {
            background: #fef3c7;
            color: #92400e;
        }
        
        .badge-danger {
            background: #fee2e2;
            color: #991b1b;
        }
        
        @media print {
            body {
                -webkit-print-color-adjust: exact;
                print-color-adjust: exact;
            }
        }
    ''')

def generate_pdf_report(title, filters_html, summary_html, table_html, report_name):
    """Generate a PDF report from HTML components"""
    company = get_company_config()
    
    html_content = f'''
    <!DOCTYPE html>
    <html>
    <head>
        <meta charset="UTF-8">
        <title>{title}</title>
    </head>
    <body>
        <div class="header">
            <h1>{company['name']}</h1>
            <p>{company['address']} | Phone: {company['phone']} | Email: {company['email']}</p>
            <p>GSTIN: {company['gstin']}</p>
        </div>
        
        <h2 class="report-title">{title}</h2>
        
        {filters_html}
        
        {summary_html}
        
        {table_html}
        
        <div class="footer">
            <p>Generated on {datetime.now().strftime('%d-%m-%Y %H:%M:%S')} | {company['name']} - Pharmacy Billing Software</p>
        </div>
    </body>
    </html>
    '''
    
    buffer = BytesIO()
    HTML(string=html_content).write_pdf(buffer, stylesheets=[get_pdf_css()])
    buffer.seek(0)
    
    response = make_response(buffer.getvalue())
    response.headers['Content-Type'] = 'application/pdf'
    response.headers['Content-Disposition'] = f'attachment; filename={report_name}.pdf'
    
    return response
