using Microsoft.UI.Xaml.Controls;
using App_3.ViewModels;

namespace App_3.Views
{
    public sealed partial class ProformaInvoicePage : Page
    {
        public ProformaInvoiceViewModel ViewModel { get; }

        public ProformaInvoicePage()
        {
            InitializeComponent();
            ViewModel = new ProformaInvoiceViewModel();
            DataContext = ViewModel;
        }
    }
}
