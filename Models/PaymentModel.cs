using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_3.Models
{
    public class PaymentModel
    {
        public string PaymentId { get; set; }
        public string Customer { get; set; }
        public string InvoiceNumber { get; set; }
        public decimal Amount { get; set; }
        public string Mode { get; set; } // Cash, Card, Online
        public string Status { get; set; } // Paid, Pending, Failed
        public string Notes { get; set; }
        public DateTime Date { get; set; }



        // For XAML binding (WinUI 3)
        public string FormattedAmount => $"₹ {Amount:N0}";
        public string FormattedDate => Date.ToString("dd MMM yyyy");
    }

}
