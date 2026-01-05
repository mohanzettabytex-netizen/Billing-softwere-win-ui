using System.Collections.ObjectModel;
using Microsoft.UI.Xaml;
using App_3.Models;

namespace App_3.ViewModels
{
    public class ProformaInvoiceViewModel
    {
        // ================= TRANSACTIONS =================
        public ObservableCollection<ProformaInvoiceModel> Invoices { get; }

        // ================= SUMMARY CARD =================
        public decimal TotalAmount { get; private set; }
        public decimal ConvertedAmount { get; private set; }
        public decimal OpenAmount { get; private set; }
        public int GrowthPercentage { get; private set; }

        // ================= EMPTY STATE =================
        public Visibility EmptyStateVisibility =>
            Invoices.Count == 0 ? Visibility.Visible : Visibility.Collapsed;

        public Visibility ContentVisibility =>
            Invoices.Count == 0 ? Visibility.Collapsed : Visibility.Visible;

        public ProformaInvoiceViewModel()
        {
            // Start with empty state (Vyapar behaviour)
            Invoices = new ObservableCollection<ProformaInvoiceModel>();

            TotalAmount = 0;
            ConvertedAmount = 0;
            OpenAmount = 0;
            GrowthPercentage = 0;
        }
    }
}
