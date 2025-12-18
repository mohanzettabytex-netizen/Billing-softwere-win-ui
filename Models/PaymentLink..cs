
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App_3.Models
{
    public class PaymentLinkModel
    {
        public string CustomerName { get; set; }
        public decimal Amount { get; set; }
        public string AmountFormatted => $"₹ {Amount}";

        public string Status { get; set; }   // Paid / Pending / Expired
        public DateTime ExpiryDate { get; set; }
        public string ExpiryFormatted => ExpiryDate.ToString("dd MMM yyyy");

        public string PaymentMethod { get; set; }

    }
}



