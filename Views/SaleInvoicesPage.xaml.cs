using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;

namespace App_3.Views
{
    public sealed partial class SaleInvoicesPage : Page
    {
        public SaleInvoicesPage()
        {
            InitializeComponent();
        }

        // ================= BUSINESS NAME EDIT =================

        private void BusinessNameText_Tapped(object sender, TappedRoutedEventArgs e)
        {
            BusinessNameText.Visibility = Visibility.Collapsed;
            BusinessNameEditor.Visibility = Visibility.Visible;
            BusinessNameBox.Focus(FocusState.Programmatic);
        }

        private void SaveBusinessName_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(BusinessNameBox.Text))
            {
                BusinessNameText.Text = BusinessNameBox.Text;
                BusinessNameText.Foreground =
                    new SolidColorBrush(Microsoft.UI.Colors.Black);
            }

            BusinessNameEditor.Visibility = Visibility.Collapsed;
            BusinessNameText.Visibility = Visibility.Visible;
        }
    }
}
