using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using App_3.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace App_3.Views
{
    public sealed partial class RecurringInvoicesPage : Page
    {
        public ObservableCollection<RecurringInvoice> Invoices { get; set; } = new();
        public ObservableCollection<RecurringInvoice> FilteredInvoices { get; set; } = new();

        public RecurringInvoicesPage()
        {
            this.InitializeComponent();
            InvoicesListView.ItemsSource = FilteredInvoices;

            // Example customers
            CustomerBox.Items.Add(new ComboBoxItem { Content = "Customer 1" });
            CustomerBox.Items.Add(new ComboBoxItem { Content = "Customer 2" });
            CustomerBox.Items.Add(new ComboBoxItem { Content = "Customer 3" });

            RefreshFiltered();
        }

        private void AddInvoice_Click(object sender, RoutedEventArgs e)
        {
            if (CustomerBox.SelectedItem == null || string.IsNullOrWhiteSpace(AmountBox.Text) ||
                FrequencyBox.SelectedItem == null || StartDatePicker.Date == default)
                return;

            var invoice = new RecurringInvoice
            {
                Customer = (CustomerBox.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "Unknown",
                Amount = AmountBox.Text,
                Frequency = (FrequencyBox.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "Monthly",
                StartDate = StartDatePicker.Date.DateTime,
                EndDate = EndDatePicker.Date != default ? EndDatePicker.Date.DateTime : (DateTime?)null,
                Notes = NotesBox.Text
            };

            Invoices.Add(invoice);
            RefreshFiltered();
            ClearInputs();
        }

        private void EditInvoice_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is RecurringInvoice invoice)
            {
                CustomerBox.Text = invoice.Customer;
                AmountBox.Text = invoice.Amount;
                NotesBox.Text = invoice.Notes;
                FrequencyBox.SelectedItem = FrequencyBox.Items.Cast<ComboBoxItem>()
                                        .FirstOrDefault(x => x.Content.ToString() == invoice.Frequency);
                StartDatePicker.Date = invoice.StartDate;
                EndDatePicker.Date = invoice.EndDate ?? default;
            }
        }

        private void DeleteInvoice_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is RecurringInvoice invoice)
            {
                Invoices.Remove(invoice);
                RefreshFiltered();
            }
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            RefreshFiltered(SearchBox.Text);
        }

        private void Filter_Changed(object sender, DatePickerValueChangedEventArgs e)
        {
            RefreshFiltered(SearchBox.Text);
        }

        private void ClearInputs_Click(object sender, RoutedEventArgs e)
        {
            ClearInputs();
        }

        private void ClearInputs()
        {
            CustomerBox.SelectedItem = null;
            AmountBox.Text = "";
            NotesBox.Text = "";
            FrequencyBox.SelectedItem = null;
            StartDatePicker.Date = default;
            EndDatePicker.Date = default;
        }

        private void RefreshFiltered(string query = "")
        {
            FilteredInvoices.Clear();

            DateTime? startFilter = StartFilter.Date != default ? StartFilter.Date.DateTime : (DateTime?)null;
            DateTime? endFilter = EndFilter.Date != default ? EndFilter.Date.DateTime : (DateTime?)null;

            foreach (var inv in Invoices.Where(x =>
                (string.IsNullOrWhiteSpace(query) || x.Customer.ToLower().Contains(query.ToLower())) &&
                (!startFilter.HasValue || x.StartDate >= startFilter.Value) &&
                (!endFilter.HasValue || (x.EndDate.HasValue && x.EndDate.Value <= endFilter.Value))
            ))
            {
                FilteredInvoices.Add(inv);
            }
        }
    }
}
