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
        // Observable collection bound to XAML
        private ObservableCollection<PaymentLinkModel> _paymentLinks;
        public ObservableCollection<PaymentLinkModel> PaymentLinks
        {
            get => _paymentLinks;
            set
            {
                if (_paymentLinks != value)
                {
                    _paymentLinks = value;
                    OnPropertyChanged(nameof(PaymentLinks));
                }
            }
        }

        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public PaymentLinksPage()
        {
            this.InitializeComponent();

            // Initialize the collection
            PaymentLinks = new ObservableCollection<PaymentLinkModel>();

            // Load dummy data
            LoadDummyData();

            // Hook up modal buttons
            BtnCreatePaymentLink.Click += BtnCreatePaymentLink_Click;
            BtnCancelModal.Click += BtnCancelModal_Click;
        }

        // Load dummy payment links
        private void LoadDummyData()
        {
            PaymentLinks.Clear(); // Keep the same collection instance

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
                CustomerName = "Naveen ",
                Amount = 1800,
                Status = "Expired",
                ExpiryDate = DateTime.Now.AddDays(-10),
                PaymentMethod = "Bank Transfer"
            });

        }

        // Show the create payment link modal
        private void BtnCreatePaymentLink_Click(object sender, RoutedEventArgs e)
        {
            ModalBackground.Visibility = Visibility.Visible;
        }

        // Hide the create payment link modal
        private void BtnCancelModal_Click(object sender, RoutedEventArgs e)
        {
            ModalBackground.Visibility = Visibility.Collapsed;
        }

        // Optional: helper to add new payment link dynamically
        public void AddPaymentLink(PaymentLinkModel link)
        {
            PaymentLinks.Add(link);
        }
    }
}
