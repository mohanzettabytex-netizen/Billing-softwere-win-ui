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
        // Dummy observable collection for items
        public ObservableCollection<InvoiceItem> Items { get; set; }

        public InvoicePage()
        {
            this.InitializeComponent();

            // Initialize dummy items list
            Items = new ObservableCollection<InvoiceItem>();

            // Try-catch safe binding (avoid null errors)
            try
            {
                if (InvoiceItemsList != null)
                    InvoiceItemsList.ItemsSource = Items;

                if (InvoiceNoBox != null)
                    InvoiceNoBox.Text = "INV-001";

                if (InvoiceDatePicker != null)
                    InvoiceDatePicker.Date = DateTimeOffset.Now;

                // Dummy totals
                if (SubTotalText != null) SubTotalText.Text = "₹ 0.00";
                if (CGSTText != null) CGSTText.Text = "₹ 0.00";
                if (SGSTText != null) SGSTText.Text = "₹ 0.00";
                if (GrandTotalText != null) GrandTotalText.Text = "₹ 0.00";
                if (DueAmountText != null) DueAmountText.Text = "₹ 0.00";
                if (PaidAmountBox != null) PaidAmountBox.Value = 0;
            }
            catch { /* ignore for dummy UI */ }
        }

        private void AddItem_Click(object sender, RoutedEventArgs e)
        {
            if (ItemSelect.SelectedItem == null)
                return;

            var itemName = (ItemSelect.SelectedItem as ComboBoxItem)?.Content.ToString();
            var qty = (int)QtyBox.Value;
            var price = PriceBox.Value;
            var discount = DiscountBox.Value;

            Items.Add(new InvoiceItem
            {
                ItemName = itemName,
                Quantity = qty,
                Price = price,
                Discount = discount
            });

            CalculateTotals();
        }

        // ================= REMOVE ITEM =================
        private void RemoveItem_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as Button)?.DataContext as InvoiceItem;
            if (item != null)
            {
                Items.Remove(item);
                CalculateTotals();
            }
        }

        private void CalculateTotals()
        {
            // Simple dummy calculation
            double subtotal = Items.Sum(i => i.Total);
            double cgst = subtotal * 0.09;
            double sgst = subtotal * 0.09;
            double grandTotal = subtotal + cgst + sgst;

            if (SubTotalText != null) SubTotalText.Text = $"₹ {subtotal:0.00}";
            if (CGSTText != null) CGSTText.Text = $"₹ {cgst:0.00}";
            if (SGSTText != null) SGSTText.Text = $"₹ {sgst:0.00}";
            if (GrandTotalText != null) GrandTotalText.Text = $"₹ {grandTotal:0.00}";

            UpdateDueAmount(grandTotal);
        }

        private void UpdateDueAmount(double grandTotal)
        {
            double paid = PaidAmountBox != null ? PaidAmountBox.Value : 0;
            double due = grandTotal - paid;

            if (DueAmountText != null)
                DueAmountText.Text = $"₹ {due:0.00}";
        }
    }
}
