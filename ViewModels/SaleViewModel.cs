using App_3.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace App_3.ViewModels
{
    public class SaleViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<SaleItem> Items { get; set; }

        public SaleViewModel()
        {
            Items = new ObservableCollection<SaleItem>();

            // start with one row
            AddRow();
        }

        // ✅ METHOD MUST BE OUTSIDE CONSTRUCTOR
        public void AddRow()
        {
            Items.Add(new SaleItem
            {
                RowNumber = Items.Count + 1,
                ItemName = "Select item",
                Qty = 1,
                Unit = "NONE",
                Price = 0,
                Discount = 0,
                Tax = 0
            });
        }

        public decimal Total => Items.Sum(i => i.Amount);

        public string TotalText => $"Total : ₹{Total:0.00}";

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
