using Microsoft.UI.Xaml.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_3.Models
{
    public class Party
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Balance { get; set; }
        public string Status { get; set; }
        public SolidColorBrush StatusColor { get; set; }

        // Details
        public string Type { get; set; } // Customer / Supplier
        public string Outstanding { get; set; }
        public string TotalSales { get; set; }
        public SolidColorBrush BalanceColor { get; set; }
    }
}
