using Microsoft.UI.Xaml;
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

            EstimateList.ItemsSource = ViewModel.ProformaInvoices;
            UpdateUIState();
        }

        private void AddProforma_Click(object sender, RoutedEventArgs e)
        {
            // 1️⃣ Add dummy transaction
            ViewModel.AddDummyProforma();

            // 2️⃣ Update UI
            UpdateUIState();
        }

        private void UpdateUIState()
        {
            if (ViewModel.ProformaInvoices.Count == 0)
            {
                EmptyState.Visibility = Visibility.Visible;
                EstimateList.Visibility = Visibility.Collapsed;
            }
            else
            {
                EmptyState.Visibility = Visibility.Collapsed;
                EstimateList.Visibility = Visibility.Visible;
            }
        }
    }
}
