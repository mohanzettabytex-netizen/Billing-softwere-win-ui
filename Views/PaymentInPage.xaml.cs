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
    }
}
