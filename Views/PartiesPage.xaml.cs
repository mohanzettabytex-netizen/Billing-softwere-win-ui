using App_3.Models;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using System.Collections.ObjectModel;
using Windows.UI;

namespace App_3.Views    
{
    public sealed partial class PartiesPage : Page
    {
        public ObservableCollection<Party> Parties { get; set; }

        private SolidColorBrush _activeBrush = new SolidColorBrush(Color.FromArgb(255, 37, 99, 235));
        private SolidColorBrush _inactiveBrush = new SolidColorBrush(Color.FromArgb(255, 156, 163, 175));

        public PartiesPage()
        {
            InitializeComponent();

            Parties = new ObservableCollection<Party>();

            // Ensure initial tab visuals are consistent with XAML (GST active)
            SetActiveTab("GST");

            UpdateUI();
        }

        private void UpdateUI()
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

                PartiesList.ItemsSource = Parties;
                PartiesList.SelectedIndex = 0;
            }
        }

        private void OpenAddParty_Click(object sender, RoutedEventArgs e)
        {
            AddPartyOverlay.Visibility = Visibility.Visible;
        }

        private void CloseAddParty_Click(object sender, RoutedEventArgs e)
        {
            AddPartyOverlay.Visibility = Visibility.Collapsed;
        }

        private void GSTTab_Tapped(object sender, Microsoft.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            SetActiveTab("GST");
        }

        private void CreditTab_Tapped(object sender, Microsoft.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            SetActiveTab("Credit");
        }

        private void AdditionalTab_Tapped(object sender, Microsoft.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            SetActiveTab("Additional");
        }

        private void SetActiveTab(string tab)
        {
            // Reset all content
            GSTContent.Visibility = Visibility.Collapsed;
            CreditContent.Visibility = Visibility.Collapsed;
            AdditionalContent.Visibility = Visibility.Collapsed;

            // Reset visuals
            GSTTab.BorderBrush = null;
            CreditTab.BorderBrush = null;
            AdditionalTab.BorderBrush = null;

            GSTTabText.Foreground = _inactiveBrush;
            CreditTabText.Foreground = _inactiveBrush;
            AdditionalTabText.Foreground = _inactiveBrush;

            // Activate selected
            switch (tab)
            {
                case "GST":
                    GSTContent.Visibility = Visibility.Visible;
                    GSTTab.BorderBrush = _activeBrush;
                    GSTTabText.Foreground = _activeBrush;
                    break;

                case "Credit":
                    CreditContent.Visibility = Visibility.Visible;
                    CreditTab.BorderBrush = _activeBrush;
                    CreditTabText.Foreground = _activeBrush;
                    break;

                case "Additional":
                    AdditionalContent.Visibility = Visibility.Visible;
                    AdditionalTab.BorderBrush = _activeBrush;
                    AdditionalTabText.Foreground = _activeBrush;
                    break;
            }
        }

        private void AddFirstParty_Click(object sender, RoutedEventArgs e)
        {
            // Add dummy party for testing
            Parties.Add(new Party
            {
                Name = "naveen",
                Balance = "₹0.00"
            });

            UpdateUI();
        }
    }
}