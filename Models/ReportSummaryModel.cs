using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_3.Models
{
    public class ReportSummaryModel
    {
        public string Title { get; set; }        // Total Sales, Expenses etc
        public string Amount { get; set; }       // ₹ 1,25,000
        public string ColorHex { get; set; }     // UI color usage later
    }
}
