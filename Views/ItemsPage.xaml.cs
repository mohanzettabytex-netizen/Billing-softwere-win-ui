using App_3.Models;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using System;
using System.Collections.Generic;

namespace App_3.Views
{
    public sealed partial class ItemsPage : Page
    {
        private List<ItemModel> items;

        public ItemsPage()
        {
            this.InitializeComponent();
            LoadItems();
            UpdatePageState();
        }

        // ================= LOAD ITEMS =================
        private void LoadItems()
        {
            // 👉 FIRST TIME : EMPTY LIST (Vyapar behaviour)
            items = new List<ItemModel>();

            // 👉 Uncomment this later to test "data exists" state
            /*
            items = new List<ItemModel>
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
                }
            };
            */

            ItemsList.ItemsSource = items;
            
        }

        // ================= PAGE STATE (IMPORTANT) =================
        private void UpdatePageState()
        {
            if (items == null || items.Count == 0)
            {
                EmptyState.Visibility = Visibility.Visible;
                MainContent.Visibility = Visibility.Collapsed;
            }
            else
            {
                EmptyState.Visibility = Visibility.Collapsed;
                MainContent.Visibility = Visibility.Visible;
            }
        }


        // ================= EMPTY STATE BUTTON =================
        private void EmptyStateAddItem_Click(object sender, RoutedEventArgs e)
        {
            EmptyState.Visibility = Visibility.Collapsed;
            MainContent.Visibility = Visibility.Visible;
            AddItemOverlay.Visibility = Visibility.Visible;
        }


        // ================= ADD ITEM =================
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
            // Dummy add (simulate save)
            items.Add(new ItemModel
            {
                Name = AddItemName.Text,
                Type = "Product",
                SKU = "NEW-001",
                SalePrice = "0",
                PurchasePrice = "0",
                StockQty = 0,
                Unit = "pcs",
                Status = "In Stock",
                StatusColor = new SolidColorBrush(Colors.LightGreen),
                StatusTextColor = new SolidColorBrush(Colors.Black)
            });

            ItemsList.ItemsSource = null;
            ItemsList.ItemsSource = items;

            AddItemOverlay.Visibility = Visibility.Collapsed;

            // 🔥 MOST IMPORTANT
            UpdatePageState();
        }

        // ================= EDIT ITEM =================
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

        // ================= TYPE SELECTION =================
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

        // ================= IMPORT / EXPORT =================
        private async void ImportItems(object sender, RoutedEventArgs e)
        {
            ContentDialog dialog = new ContentDialog
            {
                Title = "Import Items",
                Content = "Bulk import coming soon.",
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
                Content = "Bulk export coming soon.",
                CloseButtonText = "OK",
                XamlRoot = this.XamlRoot
            };

            await dialog.ShowAsync();
        }
    }
}
