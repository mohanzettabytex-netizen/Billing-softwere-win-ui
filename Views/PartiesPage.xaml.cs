using App_3.Models;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using System.Collections.ObjectModel;

namespace App_3.Views
{
    public sealed partial class PartiesPage : Page
    {
        public ObservableCollection<Party> Parties { get; set; } = new ObservableCollection<Party>();

        public PartiesPage()
        {
            this.InitializeComponent();

            // Dummy Data
            Parties.Add(new Party
            {
                Name = "John Doe",
                Phone = "9876543210",
                Balance = "₹12,500",
                Status = "Active",
                StatusColor = new SolidColorBrush(Colors.Green),
                Type = "Customer",
                Outstanding = "₹12,500",
                TotalSales = "₹50,000",
                BalanceColor = new SolidColorBrush(Colors.Red)
            });

            Parties.Add(new Party
            {
                Name = "Acme Supplies",
                Phone = "8765432109",
                Balance = "₹5,000",
                Status = "Inactive",
                StatusColor = new SolidColorBrush(Colors.Gray),
                Type = "Supplier",
                Outstanding = "₹5,000",
                TotalSales = "₹20,000",
                BalanceColor = new SolidColorBrush(Colors.Red)
            });

            Parties.Add(new Party
            {
                Name = "Jane Smith",
                Phone = "9123456780",
                Balance = "₹8,750",
                Status = "Active",
                StatusColor = new SolidColorBrush(Colors.Green),
                Type = "Customer",
                Outstanding = "₹8,750",
                TotalSales = "₹35,000",
                BalanceColor = new SolidColorBrush(Colors.Red)
            });

            // Bind dummy data to ListView
            PartiesList.ItemsSource = Parties;
        }

        #region Toggle Buttons (UI only)
        private void CustomerToggle_Click(object sender, RoutedEventArgs e)
        {
            CustomerToggle.Background = new SolidColorBrush(Colors.Blue);
            CustomerToggle.Foreground = new SolidColorBrush(Colors.White);

            SupplierToggle.Background = new SolidColorBrush(Colors.LightGray);
            SupplierToggle.Foreground = new SolidColorBrush(Colors.Black);

            BankSection.Visibility = Visibility.Collapsed;
        }

        private void SupplierToggle_Click(object sender, RoutedEventArgs e)
        {
            SupplierToggle.Background = new SolidColorBrush(Colors.Blue);
            SupplierToggle.Foreground = new SolidColorBrush(Colors.White);

            CustomerToggle.Background = new SolidColorBrush(Colors.LightGray);
            CustomerToggle.Foreground = new SolidColorBrush(Colors.Black);

            BankSection.Visibility = Visibility.Visible;
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
            // Dummy save - just close popup
            CloseAddParty_Click(sender, e);
        }
        #endregion

        #region ListView Selection Dummy Binding
        private void PartiesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }
        #endregion

        #region Edit/Delete Dummy
        private void EditParty_Click(object sender, RoutedEventArgs e)
        {
            OpenCustomerPopup_Click(sender, e);
        }

        private void DeleteParty_Click(object sender, RoutedEventArgs e)
        {
            // Dummy delete - UI only
        }
        #endregion
        public bool IsPartiesEmpty => Parties == null || Parties.Count == 0;

        // Whenever Parties list changes
        private void UpdateEmptyState()
        {
            EmptyStatePanel.Visibility = IsPartiesEmpty ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}

