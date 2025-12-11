using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using App_3.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace App_3.Views
{
    public sealed partial class PaymentReceivedPage : Page
    {
        public ObservableCollection<PaymentReceived> Payments { get; set; } = new ObservableCollection<PaymentReceived>();

        public PaymentReceivedPage()
        {
            this.InitializeComponent();

            // Sample data
            Payments.Add(new PaymentReceived { Customer = "John Doe", Amount = "1000", Mode = "Cash", Notes = "Test Payment", Date = DateTime.Now });
            Payments.Add(new PaymentReceived { Customer = "Alice", Amount = "500", Mode = "Card", Notes = "Online payment", Date = DateTime.Now });
            Payments.Add(new PaymentReceived { Customer = "Bob", Amount = "750", Mode = "Online", Notes = "Invoice Paid", Date = DateTime.Now });

            PaymentsGrid.ItemsSource = Payments;

            // Set default Mode filter
            ModeFilter.SelectedIndex = 0;
        }

        private void AddPayment_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CustomerBox.Text) ||
                string.IsNullOrWhiteSpace(AmountBox.Text) ||
                ModeBox.SelectedItem == null)
                return;

            Payments.Add(new PaymentReceived
            {
                Customer = CustomerBox.Text,
                Amount = AmountBox.Text,
                Mode = (ModeBox.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "Unknown",
                Notes = NotesBox.Text,
                Date = DateTime.Now
            });

            CustomerBox.Text = "";
            AmountBox.Text = "";
            NotesBox.Text = "";
            ModeBox.SelectedItem = null;

            RefreshGrid();
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            RefreshGrid();
        }

        private void DateFilter_DateChanged(object sender, DatePickerValueChangedEventArgs e)
        {
            RefreshGrid();
        }

        private void ModeFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            string search = SearchBox.Text?.ToLower() ?? "";
            string mode = (ModeFilter.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "All";

            DateTime selectedDate = DateFilter.Date.Date;
            bool dateSelected = DateFilter.Date != default;

            var filtered = Payments.Where(p =>
                (string.IsNullOrWhiteSpace(search) || p.Customer.ToLower().Contains(search)) &&
                (mode == "All" || p.Mode == mode) &&
                (!dateSelected || p.Date.Date == selectedDate)
            );

            PaymentsGrid.ItemsSource = new ObservableCollection<PaymentReceived>(filtered);
        }
    }
}
