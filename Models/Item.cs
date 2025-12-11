using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_3.Models
{
    public class Item
    {
        public string Name { get; set; } = "";
        public int Quantity { get; set; } = 1;
        public decimal Price { get; set; } = 0;
        public decimal Total => Quantity * Price;
    }
}