using System;

namespace App_3.Models
{
    public class RecurringInvoice
    {
        public int TemplateID { get; set; }
        public string Customer { get; set; }
        public string TemplateName { get; set; }
        public decimal Amount { get; set; }
        public string Frequency { get; set; } // Daily, Weekly, Monthly, Quarterly
        public DateTime NextInvoiceDate { get; set; }
        public string Status { get; set; } // Active, Paused, Completed

        public string NextInvoiceDateFormatted => NextInvoiceDate.ToString("dd/MM/yyyy");
    }
}
