using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using App_3.ViewModels;

namespace App_3.Views
{
    public sealed partial class PaymentInPage : Page
    {
        public PaymentInViewModel ViewModel { get; }

        public PaymentInPage()
        {
            InitializeComponent();
            ViewModel = new PaymentInViewModel();
            DataContext = ViewModel;
        }

        // 👇 REQUIRED because XAML refers to them
        private void OpenPaymentOverlay_Click(object sender, RoutedEventArgs e)
        {
            PaymentOverlay.Visibility = Visibility.Visible;
        }

        private void ClosePaymentOverlay_Click(object sender, RoutedEventArgs e)
        {
            PaymentOverlay.Visibility = Visibility.Collapsed;
        }

        private void SavePayment_Click(object sender, RoutedEventArgs e)
        {
            // dummy save
            PaymentOverlay.Visibility = Visibility.Collapsed;
        }
    }
}
