using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using App_3.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace App_3.Views
{
    public sealed partial class QuotesPage : Page
    {
        public ObservableCollection<Quote> Quotes { get; set; } = new();
        public ObservableCollection<Quote> FilteredQuotes { get; set; } = new();
        private int nextId = 1;

        public QuotesPage()
        {
            this.InitializeComponent();
            QuotesListView.ItemsSource = FilteredQuotes;
            RefreshFiltered();
        }

        private void AddOrUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameBox.Text) || string.IsNullOrWhiteSpace(CustomerBox.Text))
                return;

            Quote selected = QuotesListView.SelectedItem as Quote;

            if (selected == null)
            {
                // Add new
                var quote = new Quote
                {
                    Id = nextId++,
                    Name = NameBox.Text,
                    Customer = CustomerBox.Text,
                    Amount = decimal.TryParse(AmountBox.Text, out var amt) ? amt : 0,
                    Status = (StatusBox.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "Pending",
                    Date = DateTime.Now
                };
                Quotes.Add(quote);
            }
            else
            {
                // Update existing
                selected.Name = NameBox.Text;
                selected.Customer = CustomerBox.Text;
                selected.Amount = decimal.TryParse(AmountBox.Text, out var amt) ? amt : 0;
                selected.Status = (StatusBox.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "Pending";
            }

            RefreshFiltered();
            ClearInputs();
        }

        private void EditQuote_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is Quote quote)
            {
                NameBox.Text = quote.Name;
                CustomerBox.Text = quote.Customer;
                AmountBox.Text = quote.Amount.ToString();
                StatusBox.SelectedItem = StatusBox.Items.Cast<ComboBoxItem>()
                                        .FirstOrDefault(x => x.Content.ToString() == quote.Status);
                QuotesListView.SelectedItem = quote;
            }
        }

        private void DeleteQuote_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is Quote quote)
            {
                Quotes.Remove(quote);
                RefreshFiltered();
                ClearInputs();
            }
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            RefreshFiltered(SearchBox.Text);
        }

        private void RefreshFiltered(string query = "")
        {
            FilteredQuotes.Clear();
            foreach (var q in Quotes.Where(x =>
                     string.IsNullOrWhiteSpace(query) || x.Name.Contains(query, StringComparison.OrdinalIgnoreCase)
                     || x.Customer.Contains(query, StringComparison.OrdinalIgnoreCase)))
            {
                FilteredQuotes.Add(q);
            }
        }

        private void ClearInputs()
        {
            NameBox.Text = "";
            CustomerBox.Text = "";
            AmountBox.Text = "";
            StatusBox.SelectedItem = null;
            QuotesListView.SelectedItem = null;
        }
    }
}
