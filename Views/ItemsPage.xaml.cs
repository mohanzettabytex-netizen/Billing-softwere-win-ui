using App_3.Models;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
                    Type = "Product",
                    SKU = "ITM-001",
                    SalePrice = "1200",
                    PurchasePrice = "1000",
                    StockQty = 3,
                    Unit = "Kg",
                    Status = "Low Stock",
                    StatusColor = new SolidColorBrush(Colors.Orange),
                    StatusTextColor = new SolidColorBrush(Colors.Black),
                    ImagePath = "Assets/rice_bag.png"
                },
                new ItemModel
                {
                    Name = "Sugar",
                    Type = "Service",
                    SKU = "ITM-002",
                    SalePrice = "500",
                    PurchasePrice = "400",
                    StockQty = 12,
                    Unit = "Kg",
                    Status = "In Stock",
                    StatusColor = new SolidColorBrush(Colors.LightGreen),
                    StatusTextColor = new SolidColorBrush(Colors.Black),
                    ImagePath = "Assets/sugar.png"
                },
                new ItemModel
                {
                    Name = "Oil Bottle",
                    Type = "Product",
                    SKU = "ITM-003",
                    SalePrice = "250",
                    PurchasePrice = "200",
                    StockQty = 0,
                    Unit = "Ltr",
                    Status = "Out of Stock",
                    StatusColor = new SolidColorBrush(Colors.LightCoral),
                    StatusTextColor = new SolidColorBrush(Colors.Black),
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
            EditItemOverlay.Visibility = Visibility.Collapsed;
        }

        // ================= ADD ITEM TYPE =================
        private void AddItemType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox comboBox &&
                comboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                bool isProduct = selectedItem.Content.ToString() == "Product";

                AddItemStock.Visibility = isProduct ? Visibility.Visible : Visibility.Collapsed;
                AddItemUnit.Visibility = isProduct ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        // ================= BULK IMPORT / EXPORT =================
        private async void ImportItems(object sender, RoutedEventArgs e)
        {
            ContentDialog dialog = new ContentDialog
            {
                Title = "Import Items",
                Content = "Bulk import (CSV / Excel) – dummy for now.",
                CloseButtonText = "OK",
                XamlRoot = this.XamlRoot
            };

            await dialog.ShowAsync();
        }

        private async void ExportItems(object sender, RoutedEventArgs e)
        {
            ContentDialog dialog = new ContentDialog
            {
                Title = "Export Items",
                Content = "Bulk export (CSV / Excel) – dummy for now.",
                CloseButtonText = "OK",
                XamlRoot = this.XamlRoot
            };

            await dialog.ShowAsync();
        }
    }
}
