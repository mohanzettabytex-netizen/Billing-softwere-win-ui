using App_3.Models;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace App_3.Views
{
    public sealed partial class InvoicePage : Page
    {
        public ObservableCollection<InvoiceItem> Items { get; set; }

        public InvoicePage()
        {
            this.InitializeComponent();

            Items = new ObservableCollection<InvoiceItem>();
            InvoiceItemsList.ItemsSource = Items;

            // Dummy invoice no & date
            InvoiceNoBox.Text = "INV-001";
            InvoiceDatePicker.Date = DateTimeOffset.Now;
        }

        private void AddItem_Click(object sender, RoutedEventArgs e)
        {
            if (ItemSelect.SelectedItem == null)
                return;

            var item = new InvoiceItem
            {
                ItemName = (ItemSelect.SelectedItem as ComboBoxItem)?.Content.ToString(),
                Quantity = (int)QtyBox.Value,
                Price = PriceBox.Value,
                Discount = 0
            };

            Items.Add(item);
            CalculateTotals();
        }


        private void CalculateTotals()
        {
            double subtotal = Items.Sum(i => i.Total);

            double cgst = subtotal * 0.09;
            double sgst = subtotal * 0.09;

            double grandTotal = subtotal + cgst + sgst;

            SubTotalText.Text = $"₹ {subtotal:0.00}";
            CGSTText.Text = $"₹ {cgst:0.00}";
            SGSTText.Text = $"₹ {sgst:0.00}";
            GrandTotalText.Text = $"₹ {grandTotal:0.00}";

            UpdateDueAmount(grandTotal);
        }

        private void UpdateDueAmount(double grandTotal)
        {
            double paid = PaidAmountBox.Value;
            double due = grandTotal - paid;

            DueAmountText.Text = $"₹ {due:0.00}";
        }
    }
}
