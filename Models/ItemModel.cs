using Microsoft.UI.Xaml.Media;
using System;

namespace App_3.Models
{
    public class ItemModel
    {
        public string Name { get; set; }
        public int StockQty { get; set; }
        public string ImagePath { get; set; }
    }

    public class ServiceModel
    {
        public string ServiceName { get; set; }
        public string Category { get; set; }
        public decimal Rate { get; set; }
        public string Code { get; set; }
        public double GST { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; } = true;
        public string Unit { get; set; } = "Service";
    }
}