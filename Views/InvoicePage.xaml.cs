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
        // ================= DATA =================
        public ObservableCollection<InvoiceItem> Items { get; set; }

        // ================= CONSTRUCTOR =================
        public InvoicePage()
        {
            this.InitializeComponent();

            Items = new ObservableCollection<InvoiceItem>();

            // Bind once
            InvoiceItemsList.ItemsSource = Items;

            // Initial UI setup
            SetupInvoiceDefaults();
            UpdateViewState();
        }

        // ================= INITIAL SETUP =================
        private void SetupInvoiceDefaults()
        {
            InvoiceNoBox.Text = "INV-001";
            InvoiceDatePicker.Date = DateTimeOffset.Now;

            SubTotalText.Text = "₹ 0.00";
            CGSTText.Text = "₹ 0.00";
            SGSTText.Text = "₹ 0.00";
            GrandTotalText.Text = "₹ 0.00";
            DueAmountText.Text = "DUE : ₹ 0.00";

            PaidAmountBox.Value = 0;
        }

        // ================= EMPTY STATE HANDLER =================
        private void EmptyStateAdd_Click(object sender, RoutedEventArgs e)
        {
            EmptyState.Visibility = Visibility.Collapsed;
            MainContent.Visibility = Visibility.Visible;
        }

        // ================= VIEW STATE =================
        private void UpdateViewState()
        {
            if (Items.Count == 0)
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

        // ================= ADD ITEM =================
        private void AddItem_Click(object sender, RoutedEventArgs e)
        {
            if (ItemSelect.SelectedItem == null)
                return;

            string itemName = (ItemSelect.SelectedItem as ComboBoxItem)?.Content?.ToString();
            int qty = (int)QtyBox.Value;
            double price = PriceBox.Value;
            double discount = DiscountBox.Value;

            if (string.IsNullOrWhiteSpace(itemName))
                return;

            Items.Add(new InvoiceItem
            {
                ItemName = itemName,
                Quantity = qty,
                Price = price,
                Discount = discount
            });

            CalculateTotals();
            UpdateViewState();
            ResetItemInputs();
        }

        // ================= REMOVE ITEM =================
        private void RemoveItem_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.DataContext is InvoiceItem item)
            {
                Items.Remove(item);
                CalculateTotals();
                UpdateViewState();
            }
        }

        // ================= TOTAL CALCULATION =================
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

        // ================= DUE AMOUNT =================
        private void UpdateDueAmount(double grandTotal)
        {
            double paid = PaidAmountBox.Value;
            double due = grandTotal - paid;

            DueAmountText.Text = $"DUE : ₹ {due:0.00}";
        }

        // ================= RESET ITEM INPUT =================
        private void ResetItemInputs()
        {
            ItemSelect.SelectedIndex = -1;
            QtyBox.Value = 1;
            PriceBox.Value = 0;
            DiscountBox.Value = 0;
        }
    }
}
