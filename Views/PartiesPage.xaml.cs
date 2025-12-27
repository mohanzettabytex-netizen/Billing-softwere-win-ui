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
        public ObservableCollection<Party> Parties { get; set; }

        public PartiesPage()
        {
            this.InitializeComponent();

            Parties = new ObservableCollection<Party>();

            //  Uncomment this ONLY if you want dummy data
            LoadDummyData();

            PartiesList.ItemsSource = Parties;

            UpdatePageState();
        }

        // ================= PAGE STATE =================
        private void UpdatePageState()
        {
            if (Parties.Count == 0)
            {
                EmptyState.Visibility = Visibility.Visible;
                MainContent.Visibility = Visibility.Collapsed;
            }
            else
            {
                EmptyState.Visibility = Visibility.Collapsed;
                MainContent.Visibility = Visibility.Visible;
            }
        }

        // ================= DUMMY DATA =================
        private void LoadDummyData()
        {
            /*
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
            */
        }

        // ================= EMPTY STATE BUTTON =================
        private void EmptyStateAddParty_Click(object sender, RoutedEventArgs e)
        {
            EmptyState.Visibility = Visibility.Collapsed;
            MainContent.Visibility = Visibility.Visible;
            AddPartyOverlay.Visibility = Visibility.Visible;
        }

        // ================= TOGGLES =================
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

        // ================= ADD PARTY =================
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
            // Dummy save
            Parties.Add(new Party
            {
                Name = "New Party",
                Phone = "9000000000",
                Balance = "₹0",
                Status = "Active",
                StatusColor = new SolidColorBrush(Colors.Green),
                Type = "Customer",
                Outstanding = "₹0",
                TotalSales = "₹0",
                BalanceColor = new SolidColorBrush(Colors.Green)
            });

            CloseAddParty_Click(sender, e);
            UpdatePageState();
        }

        // ================= EDIT / DELETE =================
        private void EditParty_Click(object sender, RoutedEventArgs e)
        {
            OpenCustomerPopup_Click(sender, e);
        }

        private void DeleteParty_Click(object sender, RoutedEventArgs e)
        {
            if (Parties.Count > 0)
                Parties.RemoveAt(0);

            UpdatePageState();
        }
    }
}
