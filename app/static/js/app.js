// BillMyMed - Main JavaScript

// Initialize on document ready
document.addEventListener('DOMContentLoaded', function() {
    // Initialize tooltips
    initTooltips();
    
    // Initialize data tables
    initDataTables();
    
    // Initialize select2
    initSelect2();
    
    // Initialize date pickers
    initDatePickers();
});

// Tooltips
function initTooltips() {
    const tooltipTriggerList = document.querySelectorAll('[data-bs-toggle="tooltip"]');
    [...tooltipTriggerList].map(el => new bootstrap.Tooltip(el));
}

// DataTables initialization
function initDataTables() {
    if (typeof $.fn.DataTable !== 'undefined') {
        // Default DataTable settings
        $.extend(true, $.fn.dataTable.defaults, {
            responsive: true,
            autoWidth: false,
            language: {
                search: "",
                searchPlaceholder: "Search...",
                lengthMenu: "Show _MENU_ entries",
                info: "Showing _START_ to _END_ of _TOTAL_ entries",
                infoEmpty: "No entries found",
                emptyTable: "No data available",
                zeroRecords: "No matching records found",
                paginate: {
                    first: "First",
                    last: "Last",
                    next: "Next",
                    previous: "Previous"
                }
            },
            dom: "<'row'<'col-sm-12 col-md-6'l><'col-sm-12 col-md-6'f>>" +
                 "<'row'<'col-sm-12'tr>>" +
                 "<'row'<'col-sm-12 col-md-5'i><'col-sm-12 col-md-7'p>>"
        });
        
        // Initialize tables with class 'datatable'
        document.querySelectorAll('.datatable').forEach(table => {
            if (!$.fn.DataTable.isDataTable(table)) {
                $(table).DataTable();
            }
        });
    }
}

// Select2 initialization
function initSelect2() {
    if (typeof $.fn.select2 !== 'undefined') {
        $.extend(true, $.fn.select2.defaults.defaults, {
            theme: 'bootstrap-5',
            width: '100%',
            placeholder: 'Select an option',
            allowClear: true
        });
    }
}

// Date picker initialization
function initDatePickers() {
    const datePickers = document.querySelectorAll('.datepicker');
    datePickers.forEach(picker => {
        if (typeof flatpickr !== 'undefined') {
            flatpickr(picker, {
                dateFormat: 'Y-m-d',
                allowInput: true
            });
        }
    });
}

// Utility functions
const App = {
    // Format currency
    formatCurrency: function(amount, symbol = '₹') {
        return symbol + parseFloat(amount || 0).toFixed(2).replace(/\B(?=(\d{3})+(?!\d))/g, ',');
    },
    
    // Format date
    formatDate: function(date, format = 'dd/mm/yyyy') {
        const d = new Date(date);
        const day = String(d.getDate()).padStart(2, '0');
        const month = String(d.getMonth() + 1).padStart(2, '0');
        const year = d.getFullYear();
        
        if (format === 'dd/mm/yyyy') {
            return `${day}/${month}/${year}`;
        } else if (format === 'yyyy-mm-dd') {
            return `${year}-${month}-${day}`;
        }
        return d.toLocaleDateString();
    },
    
    // Show notification
    showNotification: function(message, type = 'info') {
        const alertClass = `alert-${type}`;
        const iconClass = {
            'success': 'bi-check-circle-fill',
            'error': 'bi-exclamation-triangle-fill',
            'warning': 'bi-exclamation-circle-fill',
            'info': 'bi-info-circle-fill'
        };
        
        const notification = document.createElement('div');
        notification.className = `alert ${alertClass} alert-dismissible fade show d-flex align-items-center`;
        notification.setAttribute('role', 'alert');
        notification.innerHTML = `
            <i class="bi ${iconClass[type] || 'bi-info-circle-fill'} me-2"></i>
            <div>${message}</div>
            <button type="button" class="btn-close" data-bs-dismiss="alert"></button>
        `;
        
        const container = document.querySelector('main');
        container.insertBefore(notification, container.firstChild);
        
        setTimeout(() => {
            notification.remove();
        }, 5000);
    },
    
    // Confirm dialog
    confirm: function(message, callback) {
        if (confirm(message)) {
            callback();
        }
    },
    
    // Show loading
    showLoading: function() {
        const overlay = document.createElement('div');
        overlay.className = 'spinner-overlay';
        overlay.id = 'loadingOverlay';
        overlay.innerHTML = `
            <div class="spinner-border text-primary" role="status">
                <span class="visually-hidden">Loading...</span>
            </div>
        `;
        document.body.appendChild(overlay);
    },
    
    // Hide loading
    hideLoading: function() {
        const overlay = document.getElementById('loadingOverlay');
        if (overlay) {
            overlay.remove();
        }
    },
    
    // API request
    async request(url, options = {}) {
        try {
            this.showLoading();
            const response = await fetch(url, {
                headers: {
                    'Content-Type': 'application/json',
                    ...options.headers
                },
                ...options
            });
            
            const data = await response.json();
            
            if (!response.ok) {
                throw new Error(data.error || 'Request failed');
            }
            
            return data;
        } catch (error) {
            this.showNotification(error.message, 'error');
            throw error;
        } finally {
            this.hideLoading();
        }
    },
    
    // Debounce function
    debounce: function(func, wait) {
        let timeout;
        return function executedFunction(...args) {
            const later = () => {
                clearTimeout(timeout);
                func(...args);
            };
            clearTimeout(timeout);
            timeout = setTimeout(later, wait);
        };
    },
    
    // Print function
    print: function(elementId) {
        const printContent = document.getElementById(elementId).innerHTML;
        const originalContent = document.body.innerHTML;
        
        document.body.innerHTML = printContent;
        window.print();
        document.body.innerHTML = originalContent;
        location.reload();
    },
    
    // Export to CSV
    exportToCSV: function(tableId, filename) {
        const table = document.getElementById(tableId);
        if (!table) return;
        
        const rows = table.querySelectorAll('tr');
        const csv = [];
        
        rows.forEach(row => {
            const cols = row.querySelectorAll('td, th');
            const rowData = [];
            cols.forEach(col => {
                // Skip action columns
                if (!col.classList.contains('no-export')) {
                    rowData.push(col.innerText.trim().replace(/"/g, '""'));
                }
            });
            csv.push(rowData.join(','));
        });
        
        const csvContent = csv.join('\n');
        const blob = new Blob([csvContent], { type: 'text/csv;charset=utf-8;' });
        const link = document.createElement('a');
        link.href = URL.createObjectURL(blob);
        link.download = filename + '.csv';
        link.click();
    },
    
    // Barcode generator
    generateBarcode: function(text, elementId) {
        // Using JsBarcode library
        if (typeof JsBarcode !== 'undefined') {
            JsBarcode('#' + elementId, text, {
                format: 'CODE128',
                width: 2,
                height: 50,
                displayValue: true
            });
        }
    }
};

// Number to words conversion
function numberToWords(num) {
    const ones = ['', 'One', 'Two', 'Three', 'Four', 'Five', 'Six', 'Seven', 'Eight', 'Nine', 'Ten', 
                  'Eleven', 'Twelve', 'Thirteen', 'Fourteen', 'Fifteen', 'Sixteen', 'Seventeen', 'Eighteen', 'Nineteen'];
    const tens = ['', '', 'Twenty', 'Thirty', 'Forty', 'Fifty', 'Sixty', 'Seventy', 'Eighty', 'Ninety'];
    
    if (num === 0) return 'Zero';
    
    if (num < 20) return ones[num];
    if (num < 100) return tens[Math.floor(num / 10)] + (num % 10 ? ' ' + ones[num % 10] : '');
    if (num < 1000) return ones[Math.floor(num / 100)] + ' Hundred' + (num % 100 ? ' ' + numberToWords(num % 100) : '');
    if (num < 100000) return numberToWords(Math.floor(num / 1000)) + ' Thousand' + (num % 1000 ? ' ' + numberToWords(num % 1000) : '');
    if (num < 10000000) return numberToWords(Math.floor(num / 100000)) + ' Lakh' + (num % 100000 ? ' ' + numberToWords(num % 100000) : '');
    return numberToWords(Math.floor(num / 10000000)) + ' Crore' + (num % 10000000 ? ' ' + numberToWords(num % 10000000) : '');
}

// Keyboard shortcuts
document.addEventListener('keydown', function(e) {
    // Ctrl/Cmd + K for search
    if ((e.ctrlKey || e.metaKey) && e.key === 'k') {
        e.preventDefault();
        const searchInput = document.querySelector('input[type="search"]');
        if (searchInput) searchInput.focus();
    }
    
    // Escape to close modals
    if (e.key === 'Escape') {
        const modals = document.querySelectorAll('.modal.show');
        modals.forEach(modal => {
            const bsModal = bootstrap.Modal.getInstance(modal);
            if (bsModal) bsModal.hide();
        });
    }
});

// Auto-dismiss alerts after 5 seconds
document.querySelectorAll('.alert:not(.alert-permanent)').forEach(alert => {
    setTimeout(() => {
        const bsAlert = new bootstrap.Alert(alert);
        bsAlert.close();
    }, 5000);
});