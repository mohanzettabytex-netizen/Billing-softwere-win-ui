using System.ComponentModel;

namespace App_3.Models
{
    public class SaleItem : INotifyPropertyChanged
    {
        private int _qty = 1;
        private decimal _price;
        private decimal _discount;
        private decimal _tax;
        private string _unit = "NONE";

        public int RowNumber { get; set; }

        public string ItemName { get; set; } = "Select item";

        public string Unit
        {
            get => _unit;
            set
            {
                _unit = value;
                OnChanged(nameof(Unit));
            }
        }

        public int Qty
        {
            get => _qty;
            set
            {
                _qty = value;
                OnChanged(nameof(Qty));
                OnChanged(nameof(Amount));
            }
        }

        public decimal Price
        {
            get => _price;
            set
            {
                _price = value;
                OnChanged(nameof(Price));
                OnChanged(nameof(Amount));
            }
        }

        public decimal Discount
        {
            get => _discount;
            set
            {
                _discount = value;
                OnChanged(nameof(Discount));
                OnChanged(nameof(Amount));
            }
        }

        public decimal Tax
        {
            get => _tax;
            set
            {
                _tax = value;
                OnChanged(nameof(Tax));
                OnChanged(nameof(Amount));
            }
        }

        public decimal Amount => (Qty * Price) - Discount + Tax;

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
