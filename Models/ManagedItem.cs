using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_3.Models
{
    public class ManagedItem
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Category { get; set; }
        public string Price { get; set; }
        public int Stock { get; set; }

        // Helper properties
        public string Initial => string.IsNullOrEmpty(Name) ? "?" : Name[0].ToString();
        public bool IsLowStock => Stock <= 5;
    }
}
