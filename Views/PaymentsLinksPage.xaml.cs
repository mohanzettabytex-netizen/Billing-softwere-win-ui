using App_3.Models;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace App_3.Views
{
    public sealed partial class PaymentLinksPage : Page, INotifyPropertyChanged
    {
        private ObservableCollection<PaymentLinkModel> _paymentLinks;
        public ObservableCollection<PaymentLinkModel> PaymentLinks
        {
            get => _paymentLinks;
            set
            {
                _paymentLinks = value;
                OnPropertyChanged(nameof(PaymentLinks));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public PaymentLinksPage()
        {
            InitializeComponent();
            PaymentLinks = new ObservableCollection<PaymentLinkModel>();
            LoadDummyData();
        }

        private void LoadDummyData()
        {
            PaymentLinks.Add(new PaymentLinkModel
            {
                CustomerName = "Arun Kumar",
                Amount = 2500,
                Status = "Pending",
                ExpiryDate = DateTime.Now.AddDays(5),
                PaymentMethod = "UPI"
            });

            PaymentLinks.Add(new PaymentLinkModel
            {
                CustomerName = "Priya Sharma",
                Amount = 1800,
                Status = "Paid",
                ExpiryDate = DateTime.Now.AddDays(-1),
                PaymentMethod = "Card"
            });

            PaymentLinks.Add(new PaymentLinkModel
            {
                CustomerName = "Priya",
                Amount = 18000,
                Status = "Expired",
                ExpiryDate = DateTime.Now.AddDays(-30),
                PaymentMethod = "Card"
            });
        }

        // ================= MODAL =================

        private void BtnCreatePaymentLink_Click(object sender, RoutedEventArgs e)
        {
            ModalBackground.Visibility = Visibility.Visible;
        }

        private void BtnCancelModal_Click(object sender, RoutedEventArgs e)
        {
            ModalBackground.Visibility = Visibility.Collapsed;
        }

        private void BtnGenerateLink_Click(object sender, RoutedEventArgs e)
        {
           

            ModalBackground.Visibility = Visibility.Collapsed;
        }
    }
}
