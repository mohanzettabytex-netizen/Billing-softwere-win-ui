using App_3.Models;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using System.Collections.ObjectModel;

namespace App_3.Views
{
    public sealed partial class ItemsPage : Page
    {
        public ObservableCollection<ItemModel> Items { get; set; }
        public ObservableCollection<ServiceModel> Services { get; set; }

        // Track if we have services
        private bool _hasServices = false;

        public ItemsPage()
        {
            InitializeComponent();

            // ===== Toggle default =====
            if (ItemTypeToggle != null)
            {
                ItemTypeToggle.Toggled += ItemTypeToggle_Toggled;
                ItemTypeToggle.IsOn = true; // Product default
            }

            // ===== Load dummy data =====
            LoadDummyItems();
            LoadDummyServices();

            ItemsList.ItemsSource = Items;
            if (Items.Count > 0)
                ItemsList.SelectedIndex = 0;

            // ===== Default panel =====
            ShowPanel("Items");

            // ===== Default overlay mode =====
            SetProductMode();
        }

        private void AddSale_Click(object sender, RoutedEventArgs e)
        {
            App.MainAppWindow.OpenNewSaleTab();
        }


        // =====================================================
        // TOP TABS
        // =====================================================



        private void ProductsTab_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ShowPanel("Items");
            UpdateTabColors("Products");
        }

        private void CategoriesTab_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ShowPanel("Categories");
            UpdateTabColors("Categories");
        }

        private void ServicesTab_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ShowPanel("Services");
            UpdateTabColors("Services");

            // Update services view based on whether we have services
            UpdateServicesView();
        }

        private void UnitsTab_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ShowPanel("Units");
            UpdateTabColors("Units");
        }

        private void UpdateTabColors(string activeTab)
        {
            // Reset all tabs
            ProductsTabBorder.Background = new SolidColorBrush(Colors.Transparent);
            ServicesTabBorder.Background = new SolidColorBrush(Colors.Transparent);
            CategoriesTabBorder.Background = new SolidColorBrush(Colors.Transparent);
            UnitsTabBorder.Background = new SolidColorBrush(Colors.Transparent);

            var productsText = (TextBlock)ProductsTabBorder.Child;
            var servicesText = (TextBlock)ServicesTabBorder.Child;
            var categoriesText = (TextBlock)CategoriesTabBorder.Child;
            var unitsText = (TextBlock)UnitsTabBorder.Child;

            productsText.Foreground = new SolidColorBrush(Colors.Gray);
            servicesText.Foreground = new SolidColorBrush(Colors.Gray);
            categoriesText.Foreground = new SolidColorBrush(Colors.Gray);
            unitsText.Foreground = new SolidColorBrush(Colors.Gray);

            // Set active tab - Use Windows.UI.Color for FromArgb
            var blueBackground = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 219, 234, 254));
            var blueForeground = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 37, 99, 235));

            switch (activeTab)
            {
                case "Products":
                    ProductsTabBorder.Background = blueBackground;
                    productsText.Foreground = blueForeground;
                    break;
                case "Services":
                    ServicesTabBorder.Background = blueBackground;
                    servicesText.Foreground = blueForeground;
                    break;
                case "Categories":
                    CategoriesTabBorder.Background = blueBackground;
                    categoriesText.Foreground = blueForeground;
                    break;
                case "Units":
                    UnitsTabBorder.Background = blueBackground;
                    unitsText.Foreground = blueForeground;
                    break;
            }
        }

        private void BusinessNameTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            // Change appearance when focused
            var lightBlue = Windows.UI.Color.FromArgb(20, 2, 132, 199);
            var blue = Windows.UI.Color.FromArgb(255, 2, 132, 199);

            BusinessNameTextBox.Background = new SolidColorBrush(lightBlue);
            BusinessNameTextBox.BorderThickness = new Thickness(0, 0, 0, 1);
            BusinessNameTextBox.BorderBrush = new SolidColorBrush(blue);
        }

        private void BusinessNameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            // Revert appearance when focus is lost
            BusinessNameTextBox.Background = new SolidColorBrush(Colors.Transparent);
            BusinessNameTextBox.BorderThickness = new Thickness(0);
            BusinessNameTextBox.BorderBrush = new SolidColorBrush(Colors.Transparent);
        }

        private void BusinessNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Show save button when text is changed
            if (SaveBusinessNameButton != null)
            {
                SaveBusinessNameButton.Visibility = Visibility.Visible;
            }
        }

        private void SaveBusinessName_Click(object sender, RoutedEventArgs e)
        {
            // Save business name logic here
            string businessName = BusinessNameTextBox.Text;

            // You can save to settings/database here
            // Example: ApplicationData.Current.LocalSettings.Values["BusinessName"] = businessName;

            // Hide save button after saving
            if (SaveBusinessNameButton != null)
            {
                SaveBusinessNameButton.Visibility = Visibility.Collapsed;
            }

            // Optional: Show success message
            // ShowMessage("Business name saved successfully!");
        }

        // =====================================================
        // ADD ITEM / SERVICE OVERLAY
        // =====================================================

        private void AddItem_Click(object sender, RoutedEventArgs e)
        {
            AddItemOverlay.Visibility = Visibility.Visible;

            // Product mode
            ItemTypeToggle.IsOn = true;
            SetProductMode();
        }

        private void AddService_Click(object sender, RoutedEventArgs e)
        {
            AddItemOverlay.Visibility = Visibility.Visible;

            // Service mode
            ItemTypeToggle.IsOn = false;
            SetServiceMode();
        }

        private void CloseAddItem_Click(object sender, RoutedEventArgs e)
        {
            AddItemOverlay.Visibility = Visibility.Collapsed;
        }

        private void SaveItem_Click(object sender, RoutedEventArgs e)
        {
            // 1. Close overlay
            AddItemOverlay.Visibility = Visibility.Collapsed;

            // 2. Check if we're saving a service or product
            bool isService = !ItemTypeToggle.IsOn;

            if (isService)
            {
                // Save a service
                _hasServices = true;

                // If we're currently on Services tab, refresh the view
                if (ServicesPanel.Visibility == Visibility.Visible)
                {
                    UpdateServicesView();
                }
            }
            else
            {
                // Save a product
                // Refresh products list if needed
            }

            // 3. Reset overlay state (next time open product by default)
            if (ItemTypeToggle != null)
                ItemTypeToggle.IsOn = true;

            SetProductMode();
        }

        // Update services view based on whether we have services
        private void UpdateServicesView()
        {
            if (_hasServices)
            {
                ServicesEmptyPanel.Visibility = Visibility.Collapsed;
                ServicesMainPanel.Visibility = Visibility.Visible;
            }
            else
            {
                ServicesEmptyPanel.Visibility = Visibility.Visible;
                ServicesMainPanel.Visibility = Visibility.Collapsed;
            }
        }

        // =====================================================
        // PRODUCT / SERVICE TOGGLE
        // =====================================================

        private void ItemTypeToggle_Toggled(object sender, RoutedEventArgs e)
        {
            if (ItemTypeToggle == null)
                return;

            if (ItemTypeToggle.IsOn)
                SetProductMode();
            else
                SetServiceMode();
        }

        private void SetProductMode()
        {
            if (ProductFieldsPanel == null || ServiceFieldsPanel == null)
                return;

            ProductFieldsPanel.Visibility = Visibility.Visible;
            ServiceFieldsPanel.Visibility = Visibility.Collapsed;

            PricingSection.Visibility = Visibility.Visible;
            StockSection.Visibility = Visibility.Visible;

            ActivatePricingTab();
        }

        private void SetServiceMode()
        {
            if (ProductFieldsPanel == null || ServiceFieldsPanel == null)
                return;

            ProductFieldsPanel.Visibility = Visibility.Collapsed;
            ServiceFieldsPanel.Visibility = Visibility.Visible;

            PricingSection.Visibility = Visibility.Visible;
            StockSection.Visibility = Visibility.Collapsed;

            ActivatePricingTab();
        }

        // =====================================================
        // PRICING / STOCK TABS
        // =====================================================

        private void PricingTab_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ActivatePricingTab();
        }

        private void StockTab_Tapped(object sender, TappedRoutedEventArgs e)
        {
            // Service-ku stock illa
            if (ItemTypeToggle != null && !ItemTypeToggle.IsOn)
                return;

            PricingSection.Visibility = Visibility.Collapsed;
            StockSection.Visibility = Visibility.Visible;

            PricingTab.Foreground = new SolidColorBrush(Colors.Gray);
            StockTab.Foreground = new SolidColorBrush(Colors.Red);
        }

        private void ActivatePricingTab()
        {
            PricingSection.Visibility = Visibility.Visible;
            StockSection.Visibility = Visibility.Collapsed;

            PricingTab.Foreground = new SolidColorBrush(Colors.Red);
            StockTab.Foreground = new SolidColorBrush(Colors.Gray);
        }

        // =====================================================
        // MAIN PAGE PANELS
        // =====================================================

        private void ShowPanel(string panelName)
        {
            ItemsPanel.Visibility = Visibility.Collapsed;
            CategoriesPanel.Visibility = Visibility.Collapsed;
            ServicesPanel.Visibility = Visibility.Collapsed;
            UnitsPanel.Visibility = Visibility.Collapsed;

            switch (panelName)
            {
                case "Items":
                    ItemsPanel.Visibility = Visibility.Visible;
                    UpdateTabColors("Products");
                    break;

                case "Categories":
                    CategoriesPanel.Visibility = Visibility.Visible;
                    UpdateTabColors("Categories");
                    break;

                case "Services":
                    ServicesPanel.Visibility = Visibility.Visible;
                    UpdateTabColors("Services");
                    UpdateServicesView();
                    break;

                case "Units":
                    UnitsPanel.Visibility = Visibility.Visible;
                    UpdateTabColors("Units");
                    break;
            }
        }

        // =====================================================
        // DUMMY DATA
        // =====================================================

        private void LoadDummyItems()
        {
            Items = new ObservableCollection<ItemModel>
            {
                new ItemModel
                {
                    Name = "Rice Bag",
                    StockQty = 12
                }
            };
        }

        private void LoadDummyServices()
        {
            Services = new ObservableCollection<ServiceModel>
            {
                // Initially empty
            };
        }
    }
}