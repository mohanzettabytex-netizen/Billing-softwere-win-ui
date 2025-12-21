using App_3.Models;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using System;
using System.Collections.ObjectModel;

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
            BtnCreateQuote.Click += BtnCreateQuote_Click;
            BtnCancelModal.Click += BtnCancelModal_Click;

            // Search / Status filter
            TxtSearch.TextChanged += (s, e) => ApplyFilters();
    
        }

        private void LoadDummyData()
        {
            Quotes.Add(new QuoteModel { QuoteNo = "QT-1001", CustomerName = "Ramesh Traders", QuoteDate = DateTime.Now.AddDays(-5), Amount = 25000, ValidTill = DateTime.Now.AddDays(10), Status = "Approved" , Description = "Traders With Multi-International" });
            Quotes.Add(new QuoteModel { QuoteNo = "QT-1003", CustomerName = "Sri Murugan Agencies", QuoteDate = DateTime.Now, Amount = 42000, ValidTill = DateTime.Now.AddDays(20), Status = "Draft", Description = "Supply of electrical components" });

            QuotesList.ItemsSource = Quotes;
        }


        private void BtnCreateQuote_Click(object sender, RoutedEventArgs e)
        {
            ModalBackground.Visibility = Visibility.Visible;
        }

        private void BtnCancelModal_Click(object sender, RoutedEventArgs e)
        {
            ModalBackground.Visibility = Visibility.Collapsed;
        }

        private void ApplyFilters()
        {
            // Implement filter logic based on TxtSearch.Text & CmbQuoteStatus.SelectedItem
        }
    }
}
