using System;
using System.ComponentModel;

namespace App_3.Models
{
    public class InvoiceItemModel : INotifyPropertyChanged
    {
        private int _quantity;
        private decimal _price;

        public string Name { get; set; }

        public int Quantity
        {
            get => _quantity;
            set
            {
                _quantity = value;
                OnPropertyChanged(nameof(Quantity));
                OnPropertyChanged(nameof(Total));
                OnPropertyChanged(nameof(TotalFormatted));
            }
        }

        public decimal Price
        {
            get => _price;
            set
            {
                _price = value;
                OnPropertyChanged(nameof(Price));
                OnPropertyChanged(nameof(Total));
                OnPropertyChanged(nameof(PriceFormatted));
                OnPropertyChanged(nameof(TotalFormatted));
            }
        }

        public decimal Total => Quantity * Price;

        // === Formatted Properties for XAML Binding ===
        public string PriceFormatted => $"₹ {Price:F2}";
        public string TotalFormatted => $"₹ {Total:F2}";

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
