using Microsoft.UI.Xaml.Media;

namespace App_3.Models
{
    public class ItemModel
    {
        public string Name { get; set; }
        public string SKU { get; set; }
        public string Type { get; set; }

        public string SalePrice { get; set; }
        public string PurchasePrice { get; set; }

        public int StockQty { get; set; }
        public string Unit { get; set; }

        public string Status { get; set; }

        // ===== UI helpers (FOR BADGES) =====
        public Brush StatusColor { get; set; }
        public Brush StatusTextColor { get; set; }

        public string ImagePath { get; set; }
    }
}
