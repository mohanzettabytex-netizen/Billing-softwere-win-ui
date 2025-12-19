using App_3.Models;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace App_3.Views
{
    public sealed partial class PaymentReceivedPage : Page
    {
        private ObservableCollection<PaymentModel> Payments;

        public PaymentReceivedPage()
        {
            this.InitializeComponent();
            LoadDummyData();
            UpdateSummary();
        }

        // Load Dummy Data
        private void LoadDummyData()
        {
            Payments = new ObservableCollection<PaymentModel>
            {
                new PaymentModel{PaymentID=1, Customer="Alice", InvoiceNumber="INV001", Amount=5000, Mode="Cash", Status="Paid", Notes="Paid in full", Date=DateTime.Today},
                new PaymentModel{PaymentID=2, Customer="Bob", InvoiceNumber="INV002", Amount=2500, Mode="Card", Status="Pending", Notes="", Date=DateTime.Today.AddDays(-1)},
                new PaymentModel{PaymentID=3, Customer="Charlie", InvoiceNumber="INV003", Amount=3000, Mode="Online", Status="Paid", Notes="Advance", Date=DateTime.Today.AddDays(-2)}
            };

            PaymentsItemsControl.ItemsSource = Payments;
        }

        // Add New Payment
        private void AddPayment_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CustomerBox.Text) ||
                string.IsNullOrWhiteSpace(AmountBox.Text) ||
                ModeBox.SelectedItem == null)
            {
                return; // Optional: Show message
            }

            Payments.Add(new PaymentModel
            {
                PaymentID = Payments.Count + 1,
                Customer = CustomerBox.Text,
                InvoiceNumber = $"INV{Payments.Count + 1:000}",
                Amount = decimal.TryParse(AmountBox.Text, out var amt) ? amt : 0,
                Mode = ((ComboBoxItem)ModeBox.SelectedItem).Content.ToString(),
                Status = "Paid",
                Notes = NotesBox.Text,
                Date = DateTime.Today
            });

            // Clear input fields
            CustomerBox.Text = AmountBox.Text = NotesBox.Text = "";
            ModeBox.SelectedIndex = -1;

            UpdateSummary();
            ApplyFilters();
        }

        // Search / Filter events
        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e) => ApplyFilters();
        private void ModeFilter_SelectionChanged(object sender, SelectionChangedEventArgs e) => ApplyFilters();
        private void DateFilter_DateChanged(object sender, DatePickerValueChangedEventArgs e) => ApplyFilters();

        // Apply Filters
        private void ApplyFilters()
        {
            var filtered = Payments.AsEnumerable();

            // Search filter
            var query = SearchBox.Text?.ToLower() ?? "";
            if (!string.IsNullOrWhiteSpace(query))
            {
                filtered = filtered.Where(p =>
                    p.Customer.ToLower().Contains(query) ||
                    p.InvoiceNumber.ToLower().Contains(query));
            }

            // Mode filter
            if (ModeFilter.SelectedItem is ComboBoxItem modeItem && modeItem.Content.ToString() != "All")
            {
                var mode = modeItem.Content.ToString();
                filtered = filtered.Where(p => p.Mode == mode);
            }

            // Date filter
            if (DateFilter.Date != null)
            {
                var selectedDate = DateFilter.Date.DateTime;
                filtered = filtered.Where(p => p.Date.Date == selectedDate.Date);
            }

            PaymentsItemsControl.ItemsSource = filtered;
        }

        // Update summary cards
        private void UpdateSummary()
        {
            decimal totalReceived = Payments.Where(p => p.Status == "Paid").Sum(p => p.Amount);
            decimal pendingAmount = Payments.Where(p => p.Status == "Pending").Sum(p => p.Amount);

            TotalReceivedText.Text = $"Total Received: ₹{totalReceived}";
            PendingAmountText.Text = $"Pending: ₹{pendingAmount}";
        }
    }
}
