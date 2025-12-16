using App_3.Models;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.Linq;

namespace App_3.Views
{
    public sealed partial class InvoicePage : Page
    {
        private ObservableCollection<InvoiceItemModel> InvoiceItems = new();

        public InvoicePage()
        {
            InitializeComponent();

            InvoiceItemsList.ItemsSource = InvoiceItems;

            InvoiceItems.CollectionChanged += (_, __) => UpdateSummary();

            InvoiceNoBox.Text = $"INV-{DateTime.Now.Ticks.ToString()[^6..]}";
            InvoiceDatePicker.Date = DateTimeOffset.Now;

            UpdateSummary();
        }


        private void AddItem_Click(object sender, RoutedEventArgs e)
        {
            if (ItemSelect.SelectedItem == null) return;

            string name = ItemSelect.SelectedItem.ToString();
            int qty = QtyBox.Value <= 0 ? 1 : (int)QtyBox.Value;
            decimal price = (decimal)PriceBox.Value;

            var existingItem = InvoiceItems.FirstOrDefault(i => i.Name == name);

            if (existingItem != null)
            {
                existingItem.Quantity += qty;
            }
            else
            {
                InvoiceItems.Add(new InvoiceItemModel
                {
                    Name = name,
                    Quantity = qty,
                    Price = price
                });
            }

            UpdateSummary();
            ClearItemInputs();
        }


        private void RemoveItem_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.DataContext is InvoiceItemModel item)
            {
                InvoiceItems.Remove(item);
                UpdateSummary();
            }
        }

        private void UpdateSummary()
        {
            decimal subTotal = InvoiceItems.Sum(i => i.Total);
            decimal paid = (decimal)(PaidAmountBox?.Value ?? 0);
            decimal due = subTotal - paid;

            SubTotalText.Text = $"₹ {subTotal:F2}";
            DiscountText.Text = "₹ 0";
            TaxText.Text = "₹ 0";
            GrandTotalText.Text = $"₹ {subTotal:F2}";
        }


        private void ClearItemInputs()
        {
            ItemSelect.SelectedIndex = -1;
            QtyBox.Value = 1;
            PriceBox.Value = 0;
        }
    }
}
