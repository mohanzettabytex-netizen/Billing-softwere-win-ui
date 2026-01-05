using System.Collections.ObjectModel;
using Microsoft.UI.Xaml;
using App_3.Models;

namespace App_3.ViewModels
{
    public class PaymentInViewModel
    {
        // List
        public ObservableCollection<PaymentInModel> Payments { get; }

        // Summary card
        public decimal TotalAmount { get; private set; }
        public decimal ReceivedAmount { get; private set; }
        public int GrowthPercentage { get; private set; }

        // Empty state
        public Visibility EmptyStateVisibility =>
            Payments.Count == 0 ? Visibility.Visible : Visibility.Collapsed;

        public Visibility ContentVisibility =>
            Payments.Count == 0 ? Visibility.Collapsed : Visibility.Visible;

        public PaymentInViewModel()
        {
            Payments = new ObservableCollection<PaymentInModel>();

            TotalAmount = 0;
            ReceivedAmount = 0;
            GrowthPercentage = 0;
        }
    }
}
