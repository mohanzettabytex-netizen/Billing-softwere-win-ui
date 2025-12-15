using App_3.Models;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System.Collections.Generic;
using Windows.UI;

namespace App_3.Views
{
    public sealed partial class ItemsPage : Page
    {
        private List<ItemModel> dummyItems;

        public ItemsPage()
        {
            this.InitializeComponent();
            LoadDummyItems();
        }

        private void LoadDummyItems()
        {
            dummyItems = new List<ItemModel>
            {
                new ItemModel
                {
                    Name = "Rice Bag",
                    SKU = "ITM-001",
                    SalePrice = "₹1200",
                    PurchasePrice = "₹1000",
                    StockQty = 3,
                    Unit = "Kg",
                    Status = "Low Stock",
                    StockColor = Colors.Orange,
                    StatusColor = Color.FromArgb(255, 254, 226, 226),
                    StatusTextColor = Colors.Orange,
                    ImagePath = "Assets/rice_bag.png"
                },
                new ItemModel
                {
                    Name = "Sugar",
                    SKU = "ITM-002",
                    SalePrice = "₹500",
                    PurchasePrice = "₹400",
                    StockQty = 12,
                    Unit = "Kg",
                    Status = "In Stock",
                    StockColor = Colors.Green,
                    StatusColor = Color.FromArgb(255, 220, 252, 231),
                    StatusTextColor = Colors.Green,
                    ImagePath = "Assets/sugar.png"
                },
                new ItemModel
                {
                    Name = "Oil Bottle",
                    SKU = "ITM-003",
                    SalePrice = "₹250",
                    PurchasePrice = "₹200",
                    StockQty = 0,
                    Unit = "ltr",
                    Status = "Out of Stock",
                    StockColor = Colors.Red,
                    StatusColor = Color.FromArgb(255, 254, 226, 226),
                    StatusTextColor = Colors.Red,
                    ImagePath = "Assets/oil_bottle.png"
                }
            };

            ItemsList.ItemsSource = dummyItems;
        }

        // ================= POPUPS =================
        private void OpenAddItemPopup(object sender, RoutedEventArgs e)
        {
            AddItemOverlay.Visibility = Visibility.Visible;
        }

        private void CloseAddItemPopup(object sender, RoutedEventArgs e)
        {
            AddItemOverlay.Visibility = Visibility.Collapsed;
        }

        private void SaveNewItem(object sender, RoutedEventArgs e)
        {
            // Dummy: Just close popup
            AddItemOverlay.Visibility = Visibility.Collapsed;
        }

        private void EditItem_Click(object sender, RoutedEventArgs e)
        {
            EditItemOverlay.Visibility = Visibility.Visible;
        }

        private void CloseEditItemPopup(object sender, RoutedEventArgs e)
        {
            EditItemOverlay.Visibility = Visibility.Collapsed;
        }

        private void UpdateItem(object sender, RoutedEventArgs e)
        {
            // Dummy: Just close popup
            EditItemOverlay.Visibility = Visibility.Collapsed;
        }

        // ================= BULK IMPORT / EXPORT =================
        private void ImportItems(object sender, RoutedEventArgs e)
        {
            // Dummy: just show message
            ContentDialog dialog = new ContentDialog
            {
                Title = "Import Items",
                Content = "Bulk import (CSV/Excel) is dummy for now.",
                CloseButtonText = "OK"
            };
            _ = dialog.ShowAsync();
        }

        private void ExportItems(object sender, RoutedEventArgs e)
        {
            // Dummy: just show message
            ContentDialog dialog = new ContentDialog
            {
                Title = "Export Items",
                Content = "Bulk export (CSV/Excel) is dummy for now.",
                CloseButtonText = "OK"
            };
            _ = dialog.ShowAsync();
        }
    }
}
