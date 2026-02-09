using System.Collections.ObjectModel;
using App_3.Models;

namespace App_3.ViewModels
{
    public class ProformaInvoiceViewModel
    {
        public ObservableCollection<ProformaInvoiceModel> ProformaInvoices { get; }

        public ProformaInvoiceViewModel()
        {
            ProformaInvoices = new ObservableCollection<ProformaInvoiceModel>();
        }

        public void AddDummyProforma()
        {
            ProformaInvoices.Add(new ProformaInvoiceModel
            {
                Date = "28/01/2026",
                EstimateNo = $"PI-{ProformaInvoices.Count + 1:000}",
                PartyName = "Demo Customer",
                Amount = 25000,
                Balance = 25000,
                Status = "Open"
            });
        }
    }
}
