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
        public ObservableCollection<PaymentModel> Payments { get; set; }

        public PaymentReceivedPage()
        {
            this.InitializeComponent();
            LoadDummyData();
            UpdateSummary();
            ToggleEmptyState();
        }

        private void LoadDummyData()
        {
            Payments = new ObservableCollection<PaymentModel>
            {
                new PaymentModel { PaymentID=1, Customer="Alice", Amount=5000, Mode="Cash", Status="Paid", Date=DateTime.Today },
                new PaymentModel { PaymentID=2, Customer="Bob", Amount=2500, Mode="Card", Status="Pending", Date=DateTime.Today },
                new PaymentModel { PaymentID=3, Customer="Charlie", Amount=3000, Mode="Online", Status="Paid", Date=DateTime.Today }
            };
        }

        private void UpdateSummary()
        {
            var total = Payments.Where(p => p.Status == "Paid").Sum(p => p.Amount);
            var pending = Payments.Where(p => p.Status == "Pending").Sum(p => p.Amount);

            TotalReceivedText.Text = $"₹ {total:N0}";
            PendingAmountText.Text = $"₹ {pending:N0}";
        }

        private void ToggleEmptyState()
        {
            if (Payments.Count == 0)
            {
                EmptyStatePanel.Visibility = Visibility.Visible;
                TablePanel.Visibility = Visibility.Collapsed;
            }
            else
            {
                EmptyStatePanel.Visibility = Visibility.Collapsed;
                TablePanel.Visibility = Visibility.Visible;
            }
        }

        private void OpenAddPaymentModal(object sender, RoutedEventArgs e)
        {
            AddPaymentModal.Visibility = Visibility.Visible;
        }

        private void BtnCancelAddPayment_Click(object sender, RoutedEventArgs e)
        {
            AddPaymentModal.Visibility = Visibility.Collapsed;
        }

        private void BtnSavePayment_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void ClearFilters(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
