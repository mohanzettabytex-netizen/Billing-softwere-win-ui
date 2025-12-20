using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_3.Models
{
    public class ExpenseModel
    {
        public string Vendor { get; set; }
        public string Category { get; set; }
        public string Amount { get; set; }
        public string PaymentMode { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
        public string Notes { get; set; }
    }
}

