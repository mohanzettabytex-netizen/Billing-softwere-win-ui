using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using App_3.Models;
using System.Collections.ObjectModel;

namespace App_3.Views
{
    public sealed partial class ItemsManagementPage : Page
    {
        public ObservableCollection<ManagedItem> Items { get; set; }

        public ItemsManagementPage()
        {
            this.InitializeComponent();

            // Dummy data
            Items = new ObservableCollection<ManagedItem>
            {
                new ManagedItem { Name="Laptop", Code="ITM001", Category="Electronics", Price="₹45,000", Stock=12 },
                new ManagedItem { Name="Mouse", Code="ITM002", Category="Accessories", Price="₹800", Stock=3 },
                new ManagedItem { Name="Keyboard", Code="ITM003", Category="Accessories", Price="₹1,200", Stock=7 },
                new ManagedItem { Name="Chair", Code="ITM004", Category="Furniture", Price="₹3,500", Stock=0 },
            };

            // Bind dummy data
            ItemsListView.ItemsSource = Items;
        }

        private void AddOrUpdate_Click(object sender, RoutedEventArgs e)
        {
            // Dummy - do nothing
        }

        private void EditItem_Click(object sender, RoutedEventArgs e)
        {
            // Dummy - do nothing
        }

        private void DeleteItem_Click(object sender, RoutedEventArgs e)
        {
            // Dummy - do nothing
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Dummy - do nothing
        }

        private void StockFilterCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Dummy stub for XAML compile
        }

        private void SortCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Dummy stub for XAML compile
        }

        private void ResetFilters_Click(object sender, RoutedEventArgs e)
        {
            // Dummy stub for XAML compile
        }
    }
}
