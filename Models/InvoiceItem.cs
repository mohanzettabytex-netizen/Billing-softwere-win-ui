using System;
using System.ComponentModel;

namespace App_3.Models
{
    public class InvoiceItem : INotifyPropertyChanged
    {
        private string itemName;
        private int quantity;
        private double price;
        private double discount;

        public string PriceFormatted => $"₹ {Price:0.00}";
        public string DiscountFormatted => $"₹ {Discount:0.00}";
        public string TotalFormatted => $"₹ {Total:0.00}";

        public string ItemName
        {
            get => itemName;
            set { itemName = value; OnPropertyChanged(nameof(ItemName)); OnPropertyChanged(nameof(Total)); }
        }

        public int Quantity
        {
            get => quantity;
            set { quantity = value; OnPropertyChanged(nameof(Quantity)); OnPropertyChanged(nameof(Total)); }
        }

        public double Price
        {
            get => price;
            set { price = value; OnPropertyChanged(nameof(Price)); OnPropertyChanged(nameof(Total)); }
        }

        public double Discount
        {
            get => discount;
            set { discount = value; OnPropertyChanged(nameof(Discount)); OnPropertyChanged(nameof(Total)); }
        }

        public double Total => (Quantity * Price) - Discount;

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
