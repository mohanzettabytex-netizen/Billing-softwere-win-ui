using System;

namespace App_3.Models
{
    public class SaleInvoiceModel
    {
        public DateTime Date { get; set; }
        public string InvoiceNo { get; set; }
        public string PartyName { get; set; }

        
        public string TransactionType { get; set; }

        public string PaymentType { get; set; }

    
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
    }
}
