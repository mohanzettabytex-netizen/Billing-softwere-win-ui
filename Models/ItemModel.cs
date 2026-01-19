using Microsoft.UI.Xaml.Media;
using System;
using System.ComponentModel;

namespace App_3.Models
{
    public class ItemModel : INotifyPropertyChanged
    {
        private string _name;
        private int _stockQty;
        private decimal _salePrice;
        private decimal _purchasePrice;
        private string _imagePath;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public int StockQty
        {
            get => _stockQty;
            set
            {
                _stockQty = value;
                OnPropertyChanged(nameof(StockQty));
                OnPropertyChanged(nameof(StockValue));
                OnPropertyChanged(nameof(StockStatus));
            }
        }

        public decimal SalePrice
        {
            get => _salePrice;
            set
            {
                _salePrice = value;
                OnPropertyChanged(nameof(SalePrice));
            }
        }

        public decimal PurchasePrice
        {
            get => _purchasePrice;
            set
            {
                _purchasePrice = value;
                OnPropertyChanged(nameof(PurchasePrice));
                OnPropertyChanged(nameof(StockValue));
            }
        }

        public decimal StockValue => StockQty * PurchasePrice;

        public string ImagePath
        {
            get => _imagePath;
            set
            {
                _imagePath = value;
                OnPropertyChanged(nameof(ImagePath));
                OnPropertyChanged(nameof(ItemImage));
            }
        }

        // Additional properties for item management
        public string Code { get; set; }
        public string HSN { get; set; }
        public string Category { get; set; }
        public string Unit { get; set; } = "PCS";
        public int MinStockLevel { get; set; }
        public int MaxStockLevel { get; set; }
        public decimal TaxRate { get; set; } = 18.0m; // GST percentage
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime LastUpdated { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
        public string Supplier { get; set; }
        public string Brand { get; set; }
        public decimal Weight { get; set; }
        public string Dimensions { get; set; }
        public string Location { get; set; } // Warehouse location
        public string Barcode { get; set; }

        // Calculated properties
        public decimal ProfitMargin => SalePrice > 0 ? ((SalePrice - PurchasePrice) / SalePrice) * 100 : 0;
        public decimal ProfitPerUnit => SalePrice - PurchasePrice;
        public string StockStatus
        {
            get
            {
                if (StockQty <= MinStockLevel) return "Low Stock";
                if (StockQty >= MaxStockLevel && MaxStockLevel > 0) return "Over Stock";
                return "In Stock";
            }
        }

        // For UI binding
        public Brush StockStatusColor
        {
            get
            {
                if (StockQty <= MinStockLevel) return new SolidColorBrush(Windows.UI.Color.FromArgb(255, 220, 38, 38)); // Red
                if (StockQty >= MaxStockLevel && MaxStockLevel > 0) return new SolidColorBrush(Windows.UI.Color.FromArgb(255, 234, 179, 8)); // Yellow
                return new SolidColorBrush(Windows.UI.Color.FromArgb(255, 34, 197, 94)); // Green
            }
        }

        public Brush ItemColor
        {
            get
            {
                // Return different colors based on category or other criteria
                if (string.IsNullOrEmpty(Category))
                    return new SolidColorBrush(Windows.UI.Color.FromArgb(255, 219, 234, 254)); // Light blue default

                return Category.ToLower() switch
                {
                    "food" => new SolidColorBrush(Windows.UI.Color.FromArgb(255, 254, 243, 199)), // Amber
                    "electronics" => new SolidColorBrush(Windows.UI.Color.FromArgb(255, 224, 231, 255)), // Indigo
                    "clothing" => new SolidColorBrush(Windows.UI.Color.FromArgb(255, 254, 226, 226)), // Red
                    "furniture" => new SolidColorBrush(Windows.UI.Color.FromArgb(255, 220, 252, 231)), // Green
                    "stationery" => new SolidColorBrush(Windows.UI.Color.FromArgb(255, 254, 249, 195)), // Yellow
                    _ => new SolidColorBrush(Windows.UI.Color.FromArgb(255, 219, 234, 254)) // Light blue
                };
            }
        }

        // Default image if no image path
        public string ItemImage => string.IsNullOrEmpty(ImagePath) ? "ms-appx:///Assets/DefaultItem.png" : ImagePath;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class ServiceModel : INotifyPropertyChanged
    {
        private string _serviceName;
        private string _category;
        private decimal _rate;
        private string _description;

        public string ServiceName
        {
            get => _serviceName;
            set
            {
                _serviceName = value;
                OnPropertyChanged(nameof(ServiceName));
            }
        }

        public string Category
        {
            get => _category;
            set
            {
                _category = value;
                OnPropertyChanged(nameof(Category));
            }
        }

        public decimal Rate
        {
            get => _rate;
            set
            {
                _rate = value;
                OnPropertyChanged(nameof(Rate));
                OnPropertyChanged(nameof(RateWithTax));
            }
        }

        public string Code { get; set; }
        public double GST { get; set; } = 18.0; // Default GST rate
        public decimal TaxRate => (decimal)GST;

        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime LastUpdated { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
        public string Unit { get; set; } = "Service";
        public string Duration { get; set; } // e.g., "1 hour", "30 minutes"
        public string ServiceType { get; set; } // e.g., "Consultation", "Repair", "Maintenance"
        public string ServiceProvider { get; set; }
        public string TermsAndConditions { get; set; }

        // Additional properties for service management
        public decimal Cost { get; set; } // Cost to provide the service
        public decimal Profit => Rate - Cost;
        public decimal ProfitMargin => Rate > 0 ? ((Rate - Cost) / Rate) * 100 : 0;

        // Calculated properties
        public decimal RateWithTax => Rate * (1 + (TaxRate / 100));
        public decimal TaxAmount => Rate * (TaxRate / 100);

        // For UI binding
        public Brush ServiceColor
        {
            get
            {
                if (string.IsNullOrEmpty(Category))
                    return new SolidColorBrush(Windows.UI.Color.FromArgb(255, 219, 234, 254)); // Light blue

                return Category.ToLower() switch
                {
                    "consultation" => new SolidColorBrush(Windows.UI.Color.FromArgb(255, 219, 234, 254)), // Blue
                    "repair" => new SolidColorBrush(Windows.UI.Color.FromArgb(255, 254, 226, 226)), // Red
                    "maintenance" => new SolidColorBrush(Windows.UI.Color.FromArgb(255, 220, 252, 231)), // Green
                    "installation" => new SolidColorBrush(Windows.UI.Color.FromArgb(255, 254, 243, 199)), // Amber
                    "cleaning" => new SolidColorBrush(Windows.UI.Color.FromArgb(255, 237, 233, 254)), // Purple
                    "delivery" => new SolidColorBrush(Windows.UI.Color.FromArgb(255, 254, 249, 195)), // Yellow
                    _ => new SolidColorBrush(Windows.UI.Color.FromArgb(255, 219, 234, 254)) // Light blue
                };
            }
        }

        // Status properties
        public string Status => IsActive ? "Active" : "Inactive";
        public Brush StatusColor => IsActive ?
            new SolidColorBrush(Windows.UI.Color.FromArgb(255, 34, 197, 94)) : // Green
            new SolidColorBrush(Windows.UI.Color.FromArgb(255, 239, 68, 68)); // Red

        // Validation methods
        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(ServiceName) && Rate >= 0;
        }

        public string Validate()
        {
            if (string.IsNullOrWhiteSpace(ServiceName))
                return "Service name is required";
            if (Rate < 0)
                return "Rate cannot be negative";
            return null;
        }

        // Clone method for editing
        public ServiceModel Clone()
        {
            return new ServiceModel
            {
                ServiceName = this.ServiceName,
                Category = this.Category,
                Rate = this.Rate,
                Code = this.Code,
                GST = this.GST,
                Description = this.Description,
                CreatedDate = this.CreatedDate,
                IsActive = this.IsActive,
                Unit = this.Unit,
                Duration = this.Duration,
                ServiceType = this.ServiceType,
                ServiceProvider = this.ServiceProvider,
                TermsAndConditions = this.TermsAndConditions,
                Cost = this.Cost
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    // Additional model classes for other entities

    public class CategoryModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ItemsCount { get; set; }
        public decimal TotalStockValue { get; set; }
        public string ColorCode { get; set; } = "#DBEAFE";
        public bool IsDefault { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }

    public class UnitModel
    {
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
        public bool IsBaseUnit { get; set; }
        public decimal ConversionFactor { get; set; } = 1; // For conversion to base unit
        public string BaseUnit { get; set; }
    }

    public class TransactionModel
    {
        public string Type { get; set; } // "Sale", "Purchase", "Adjustment"
        public string InvoiceNumber { get; set; }
        public string CustomerName { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public string Reference { get; set; }
        public decimal Price { get; set; }
        public string Unit { get; set; }
        public string Status { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public string ItemName { get; set; }
        public string ItemCode { get; set; }
    }
}