using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System.Collections.ObjectModel;
using App_3.Models;

namespace App_3.Views
{
    public sealed partial class PartiesPage : Page
    {
        public ObservableCollection<Party> Parties { get; set; } = new ObservableCollection<Party>();

        public PartiesPage()
        {
            this.InitializeComponent();

            // Dummy data
            

            PartiesItemsControl.ItemsSource = Parties;
        }

        private void CustomerToggle_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Filter only customers
        }

        private void SupplierToggle_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Filter only suppliers
        }
    }
}
