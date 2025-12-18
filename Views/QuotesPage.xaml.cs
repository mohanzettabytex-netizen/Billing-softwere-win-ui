using App_3.Models;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace App_3.Views
{
    public sealed partial class QuotesPage : Page
    {
        public ObservableCollection<QuoteModel> Quotes { get; set; } = new ObservableCollection<QuoteModel>();

        public QuotesPage()
        {
            this.InitializeComponent();
            LoadDummyData();

            // Modal handlers
            BtnCreateQuote.Click += (s, e) => ModalBackground.Visibility = Visibility.Visible;
            BtnCancelModal.Click += (s, e) => ModalBackground.Visibility = Visibility.Collapsed;

            // Search / Status filter
            TxtSearch.TextChanged += (s, e) => ApplyFilters();
            CmbStatus.SelectionChanged += (s, e) => ApplyFilters();
        }

        private void LoadDummyData()
        {
            Quotes.Add(new QuoteModel { QuoteNo = "QT-1001", CustomerName = "Ramesh Traders", QuoteDate = DateTime.Now.AddDays(-5), Amount = 25000, ValidTill = DateTime.Now.AddDays(10), Status = "Approved" });
            Quotes.Add(new QuoteModel { QuoteNo = "QT-1003", CustomerName = "Sri Murugan Agencies", QuoteDate = DateTime.Now, Amount = 42000, ValidTill = DateTime.Now.AddDays(20), Status = "Draft" });

            QuotesList.ItemsSource = Quotes;
        }

        private void ApplyFilters()
        {
        }
    }
}
