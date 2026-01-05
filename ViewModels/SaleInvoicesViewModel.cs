using App_3.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace App_3.ViewModels
{
    public class SaleInvoicesViewModel
    {
        public ObservableCollection<SaleInvoiceModel> AllInvoices { get; set; }
        public ObservableCollection<SaleInvoiceModel> FilteredInvoices { get; set; }

        public SaleInvoicesViewModel()
        {
            // Dummy data (replace with DB later)
            AllInvoices = new ObservableCollection<SaleInvoiceModel>
            {
                new SaleInvoiceModel
                {
                    Date = new DateTime(2025,12,31),
                    InvoiceNo = 1,
                    PartyName = "Nav",
                    Transaction = "Sale",
                    PaymentType = "Cash",
                    Amount = 0,
                    Balance = 0
                }
            };

            FilteredInvoices = new ObservableCollection<SaleInvoiceModel>(AllInvoices);
        }

        // ===== FILTER BY MONTH =====
        public void FilterThisMonth()
        {
            var now = DateTime.Now;
            ApplyFilter(i => i.Date.Month == now.Month && i.Date.Year == now.Year);
        }

        // ===== FILTER BY DATE RANGE =====
        public void FilterByDateRange(DateTime from, DateTime to)
        {
            ApplyFilter(i => i.Date >= from && i.Date <= to);
        }

        private void ApplyFilter(Func<SaleInvoiceModel, bool> predicate)
        {
            FilteredInvoices.Clear();
            foreach (var item in AllInvoices.Where(predicate))
                FilteredInvoices.Add(item);
        }
    }
}
