using System;

namespace App_3.Models
{
    public class ProformaInvoiceModel
    {
        public string ProformaNo { get; set; }
        public string PartyName { get; set; }
        public DateTime Date { get; set; }

        public decimal Amount { get; set; }
        public decimal Balance { get; set; }

        // Open / Converted
        public string Status { get; set; }
    }
}
