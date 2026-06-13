# BillMyMed - Pharmacy Billing Software (Web Edition)

A modern, responsive web-based pharmacy billing and inventory management system. This is a complete rewrite of the original Visual Basic desktop application into a full-featured web application.

## Features

### Core Features
- **Dashboard** - Real-time overview of sales, stock, and alerts
- **Point of Sale (POS)** - Fast, intuitive billing interface with barcode support
- **Product Management** - Complete product catalog with batch tracking and expiry management
- **Customer Management** - Customer database with credit tracking and loyalty cards
- **Supplier Management** - Supplier database with purchase tracking
- **Inventory Management** - Real-time stock tracking with low stock alerts
- **Sales Management** - Invoice generation with multiple payment modes
- **Purchase Management** - Purchase receipts with batch creation
- **Stock Adjustments** - Stock in/out tracking with audit trail
- **Reports** - Comprehensive sales, purchase, stock, and financial reports

### Additional Features
- **User Management** - Role-based access control
- **GST Compliance** - Tax calculations and GST reports
- **Prescription Tracking** - Customer prescriptions management
- **SMS/Email Notifications** - Low stock and expiry alerts
- **Barcode Support** - Product lookup by barcode scan
- **Responsive Design** - Works on Desktop, Tablet, and Mobile devices

## Technology Stack

- **Backend**: Python Flask 3.0
- **Database**: SQLite (Development) / PostgreSQL/MySQL (Production)
- **Frontend**: HTML5, CSS3, Bootstrap 5
- **JavaScript**: Vanilla JS with jQuery
- **DataTables**: Server-side pagination and filtering
- **Authentication**: Flask-Login with session-based auth

## Installation

### Prerequisites
- Python 3.10+
- pip

### Setup

1. **Clone the repository**
```bash
git clone https://github.com/CodeITinfotech/Billmymed.git
cd Billmymed/Billmymed-Web
```

2. **Create virtual environment**
```bash
python -m venv venv
source venv/bin/activate  # On Windows: venv\Scripts\activate
```

3. **Install dependencies**
```bash
pip install -r requirements.txt
```

4. **Initialize database**
```bash
flask init-db
```

5. **Run the application**
```bash
python run.py
```

The application will be available at `http://localhost:5000`

### Default Credentials
- **Admin**: `admin` / `admin123`
- **Staff**: `staff` / `staff123`

## Project Structure

```
Billmymed-Web/
├── app/
│   ├── __init__.py          # App factory
│   ├── models.py            # Database models
│   ├── routes/              # Route handlers
│   │   ├── auth.py          # Authentication
│   │   ├── main.py          # Dashboard
│   │   ├── products.py      # Product management
│   │   ├── customers.py     # Customer management
│   │   ├── suppliers.py     # Supplier management
│   │   ├── sales.py         # Sales/Billing
│   │   ├── purchase.py      # Purchase management
│   │   ├── inventory.py     # Stock/Inventory
│   │   ├── reports.py       # Reports
│   │   ├── settings.py      # Settings
│   │   └── api.py           # REST API
│   ├── static/
│   │   ├── css/             # Stylesheets
│   │   └── js/              # JavaScript
│   └── templates/           # Jinja2 templates
├── migrations/              # Database migrations
├── tests/                   # Unit tests
├── config.py               # Configuration
├── requirements.txt        # Dependencies
└── run.py                  # Entry point
```

## Configuration

Configuration is managed through environment variables and the Settings model in the database.

### Environment Variables
- `FLASK_CONFIG`: `development`, `production`, or `testing`
- `SECRET_KEY`: Application secret key
- `DATABASE_URL`: Database connection string

### Database Settings
Access via Settings > General in the application:
- Company Name & Address
- GSTIN & Drug License
- Invoice Prefix
- Default Discount %
- Low Stock Alert Level
- Expiry Alert Days

## API Documentation

The application provides a RESTful API for integrations:

### Products
- `GET /api/products` - List products (with pagination and search)
- `GET /api/products/<id>` - Get product details
- `GET /api/products/barcode/<barcode>` - Get product by barcode

### Customers
- `GET /api/customers` - List customers
- `GET /api/customers/<id>` - Get customer details

### Invoices
- `GET /api/invoices` - List invoices
- `GET /api/invoices/<id>` - Get invoice details

### Dashboard
- `GET /api/dashboard/stats` - Get dashboard statistics

### Search
- `GET /api/search?q=<query>` - Global search across products, customers, invoices

## Keyboard Shortcuts

### POS/Billing
- `F1` - Focus product search
- `F5` - Complete sale
- `Ctrl+Enter` - Complete sale
- `Esc` - Clear cart

### General
- `Ctrl+K` - Focus search
- `Esc` - Close modals

## Responsive Design

The application is designed to work seamlessly across:

### Desktop (1200px+)
- Full navigation sidebar
- All features visible
- Multi-column layouts

### Tablet (768px - 1199px)
- Collapsible sidebar
- Tabbed navigation
- Optimized spacing

### Mobile (< 768px)
- Bottom navigation bar
- Offcanvas menu
- Single column layouts
- Touch-optimized controls

## Deployment

### Using Gunicorn (Production)

```bash
gunicorn -w 4 -b 0.0.0.0:8000 "app:create_app('production')"
```

### Using Docker

```dockerfile
FROM python:3.11-slim
WORKDIR /app
COPY requirements.txt .
RUN pip install --no-cache-dir -r requirements.txt
COPY . .
EXPOSE 8000
CMD ["gunicorn", "-w", "4", "-b", "0.0.0.0:8000", "run:app"]
```

### Database Migration for Production

For PostgreSQL:
```bash
export DATABASE_URL="postgresql://user:pass@localhost/billmymed"
flask db upgrade
```

## Screenshots

The application features:
- Modern, clean UI with Bootstrap 5
- Tabbed interfaces for organized content
- Card-based layouts for information
- Responsive tables with DataTables
- Mobile-first bottom navigation

## Contributing

1. Fork the repository
2. Create a feature branch
3. Commit your changes
4. Push to the branch
5. Create a Pull Request

## License

This project is proprietary software. All rights reserved.

## Support

For issues and feature requests, please contact the development team.

---

**Original VB.NET Application**: [BillMyMed VB.NET](https://github.com/CodeITinfotech/Billmymed)

**Database Schema**: [Database SQL](/Database/DataBase.sql)