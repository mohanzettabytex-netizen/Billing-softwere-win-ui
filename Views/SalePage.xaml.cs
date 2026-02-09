using App_3.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace App_3.Views
{
    public sealed partial class SalePage : Page
    {
        public SalePage()
        {
            InitializeComponent();
        }

        private void AddRow_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as SaleViewModel)?.AddRow();
        }



    }
}
