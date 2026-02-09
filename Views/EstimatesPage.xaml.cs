using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System.Collections.ObjectModel;
using App_3.Models;

namespace App_3.Views
{
    public sealed partial class EstimatesPage : Page
    {
        private ObservableCollection<EstimateModel> Estimates =
            new ObservableCollection<EstimateModel>();

        public EstimatesPage()
        {
            this.InitializeComponent();
        }

        private void AddEstimate_Click(object sender, RoutedEventArgs e)
        {
            Estimates.Add(new EstimateModel
            {
                Date = "10/01/2026",
                EstimateNo = "EST-001",
                PartyName = "Nav",
                Amount = 0,
                Status = "Open"
            });

            EstimateList.ItemsSource = Estimates;
            EmptyState.Visibility = Visibility.Collapsed;
            EstimateList.Visibility = Visibility.Visible;
        }
    }
}
