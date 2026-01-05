using System.ComponentModel;

namespace App_3.Models
{
    public class SaleItem : INotifyPropertyChanged
    {
        private string itemName;
        private decimal qty = 1;
        private decimal price;


        public int SlNo { get; set; }

        public string ItemName
        {
            get => itemName;
            set { itemName = value; OnPropertyChanged(nameof(ItemName)); }
        }

        public decimal Qty
        {
            get => qty;
            set { qty = value; OnPropertyChanged(nameof(Qty)); OnPropertyChanged(nameof(Amount)); }
        }

        public decimal Price
        {
            get => price;
            set { price = value; OnPropertyChanged(nameof(Price)); OnPropertyChanged(nameof(Amount)); }
        }

        public decimal Amount => Qty * Price;

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string prop)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
