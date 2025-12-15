using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;

namespace App_3.Views
{
    public sealed partial class PartiesPage : Page
    {
        public PartiesPage()
        {
            this.InitializeComponent();
        }

        #region Toggle Buttons (UI only)
        private void CustomerToggle_Click(object sender, RoutedEventArgs e)
        {
            // Customer active
            CustomerToggle.Background = new SolidColorBrush(Microsoft.UI.Colors.Blue);
            CustomerToggle.Foreground = new SolidColorBrush(Microsoft.UI.Colors.White);

            // Supplier inactive
            SupplierToggle.Background = new SolidColorBrush(Microsoft.UI.Colors.LightGray);
            SupplierToggle.Foreground = new SolidColorBrush(Microsoft.UI.Colors.Black);

            BankSection.Visibility = Visibility.Collapsed; // Hide bank section for Customer
        }

        private void SupplierToggle_Click(object sender, RoutedEventArgs e)
        {
            // Supplier active
            SupplierToggle.Background = new SolidColorBrush(Microsoft.UI.Colors.Blue);
            SupplierToggle.Foreground = new SolidColorBrush(Microsoft.UI.Colors.White);

            // Customer inactive
            CustomerToggle.Background = new SolidColorBrush(Microsoft.UI.Colors.LightGray);
            CustomerToggle.Foreground = new SolidColorBrush(Microsoft.UI.Colors.Black);

            BankSection.Visibility = Visibility.Visible; // Show bank details for Supplier
        }
        #endregion

        #region Add Party Popup
        private void OpenCustomerPopup_Click(object sender, RoutedEventArgs e)
        {
            AddPartyOverlay.Visibility = Visibility.Visible;
            PopupTitle.Text = "Add Customer";
            BankSection.Visibility = Visibility.Collapsed;
        }

        private void OpenSupplierPopup_Click(object sender, RoutedEventArgs e)
        {
            AddPartyOverlay.Visibility = Visibility.Visible;
            PopupTitle.Text = "Add Supplier";
            BankSection.Visibility = Visibility.Visible;
        }

        private void CloseAddParty_Click(object sender, RoutedEventArgs e)
        {
            AddPartyOverlay.Visibility = Visibility.Collapsed;
        }

        private void SaveParty_Click(object sender, RoutedEventArgs e)
        {
            // Dummy save - UI only
            CloseAddParty_Click(sender, e);
        }
        #endregion

        #region Edit/Delete Dummy
        private void EditParty_Click(object sender, RoutedEventArgs e)
        {
            // Open popup for demo
            OpenCustomerPopup_Click(sender, e);
        }

        private void DeleteParty_Click(object sender, RoutedEventArgs e)
        {
            // UI-only, no action
        }
        #endregion
    }
}
