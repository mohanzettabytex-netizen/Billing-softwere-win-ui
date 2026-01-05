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
            Items = new ObservableCollection<SaleItem>
            {
                new SaleItem { SlNo = 1 }
            };
        }

        public decimal Total => Items.Sum(i => i.Amount);

        public string TotalText => $"Total : ₹{Total:0.00}";


        public void AddRow()
        {
            Items.Add(new SaleItem
            {
                SlNo = Items.Count + 1
            });
            OnPropertyChanged(nameof(Total));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string prop)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
