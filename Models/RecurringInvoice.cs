using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_3.Models
{
    public class RecurringInvoice
    {
        public string Customer { get; set; } = string.Empty;
        public string Amount { get; set; } = string.Empty;
        public string Frequency { get; set; } = "Monthly";
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }  // Nullable
        public string Notes { get; set; } = string.Empty;

        // Formatted properties for XAML binding
        public string StartDateFormatted => StartDate.ToString("MM/dd/yyyy");
        public string EndDateFormatted => EndDate.HasValue ? EndDate.Value.ToString("MM/dd/yyyy") : "";
    }
}