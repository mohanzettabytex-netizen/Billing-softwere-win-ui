using Windows.UI;

namespace App_3.Models
{
    public class ItemModel
    {
        public string Name { get; set; }
        public string SKU { get; set; }
        public string SalePrice { get; set; }
        public string PurchasePrice { get; set; }
        public int StockQty { get; set; }
        public string Unit { get; set; }
        public string Status { get; set; }

        // UI helpers
        public Color StockColor { get; set; }
        public Color StatusColor { get; set; }
        public Color StatusTextColor { get; set; }

        // Optional: Image for item
        public string ImagePath { get; set; }
    }
}
