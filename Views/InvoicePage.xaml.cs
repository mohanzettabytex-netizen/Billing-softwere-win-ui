using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System.Collections.ObjectModel;
using App_3.Models;

namespace App_3.Views
{
    public sealed partial class InvoicePage : Page
    {
        public ObservableCollection<Item> Items { get; set; } = new();

        public InvoicePage()
        {
            this.InitializeComponent();
            ItemList.ItemsSource = Items;
        }

        private void AddItem_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ItemNameInput.Text) &&
                int.TryParse(QuantityInput.Text, out int qty) &&
                decimal.TryParse(PriceInput.Text, out decimal price))
            {
                Items.Add(new Item
                {
                    Name = ItemNameInput.Text,
                    Quantity = qty,
                    Price = price
                });

                ItemNameInput.Text = "";
                QuantityInput.Text = "";
                PriceInput.Text = "";

                UpdateGrandTotal();
            }
        }

        private void UpdateGrandTotal()
        {
            decimal total = 0;
            foreach (var item in Items)
                total += item.Total;

            GrandTotalText.Text = $"Grand Total: {total:C}";
        }
    }
}
