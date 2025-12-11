using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_3.Models
{
    public class Quote
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Customer { get; set; } = "";
        public decimal Amount { get; set; } = 0;
        public string Status { get; set; } = "Pending"; // Pending, Approved, Rejected
        public DateTime Date { get; set; } = DateTime.Now;
        public string Notes { get; set; } = "";
    }
}