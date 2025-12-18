using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App_3.Models
{
    public class QuoteModel
    {
        // Quote number / ID
        public string QuoteNo { get; set; }

        // Customer name
        public string CustomerName { get; set; }

        // Quote date
        public DateTime QuoteDate { get; set; }
        public string QuoteDateFormatted => QuoteDate.ToString("dd MMM yyyy");

        // Quote amount
        public decimal Amount { get; set; }
        public string AmountFormatted => $"₹ {Amount:N0}";

        // Validity
        public DateTime ValidTill { get; set; }
        public string ValidTillFormatted => ValidTill.ToString("dd MMM yyyy");

        // Status: Draft / Sent / Approved / Rejected
        public string Status { get; set; }
    }
}
