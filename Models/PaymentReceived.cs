using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_3.Models
{
    public class PaymentReceived
    {
        public string Customer { get; set; } = "";
        public string Amount { get; set; } = "";
        public string Mode { get; set; } = "";
        public string Notes { get; set; } = "";
        public DateTime Date { get; set; }

        // Use for DataGrid display
        public string DateFormatted => Date.ToString("dd/MM/yyyy");
    }
}

