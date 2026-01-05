using System;

namespace App_3.Models
{
    public class PaymentInModel
    {
        public string ReceiptNo { get; set; }
        public string PartyName { get; set; }
        public DateTime Date { get; set; }

        public decimal Amount { get; set; }
        public string Mode { get; set; } // Cash / Bank / UPI
    }
}
