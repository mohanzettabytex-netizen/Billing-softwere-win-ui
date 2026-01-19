using App_3.Models;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System.Collections.ObjectModel;
using System.Linq;

namespace App_3.Views
{
    public sealed partial class ItemsPage : Page
    {
        public ObservableCollection<ItemModel> Items { get; set; }
        public ObservableCollection<ItemModel> FilteredItems { get; set; }
        public ObservableCollection<ServiceModel> Services { get; set; }
        public ObservableCollection<ServiceModel> FilteredServices { get; set; }

        private bool _hasServices = false;
        private bool _isInitialized = false;

        public ItemsPage()
        {
            InitializeComponent();

            if (_isInitialized) return;

            // Initialize collections
            Items = new ObservableCollection<ItemModel>();
            Services = new ObservableCollection<ServiceModel>();
            FilteredItems = new ObservableCollection<ItemModel>();
            FilteredServices = new ObservableCollection<ServiceModel>();

            // Load dummy data
            LoadDummyItems();
            LoadDummyServices();

            // Set up list views
            if (ItemsList != null) ItemsList.ItemsSource = FilteredItems;
            if (ServicesListControl != null) ServicesListControl.ItemsSource = FilteredServices;

            // Update filtered collections
            UpdateFilteredItems();
            UpdateFilteredServices();

            // Select first item if available
            if (FilteredItems.Count > 0 && ItemsList != null)
                ItemsList.SelectedIndex = 0;

            // Show default panel
            ShowPanel("Items");

            // Set default overlay mode
            if (ItemTypeToggle != null)
            {
                ItemTypeToggle.IsOn = true;
                ItemTypeToggle.Toggled += ItemTypeToggle_Toggled;
            }

            SetProductMode();

            // Initialize search handlers
            if (ItemsSearchBox != null) ItemsSearchBox.TextChanged += ItemsSearchBox_TextChanged;
            if (ServicesSearchBox != null) ServicesSearchBox.TextChanged += ServicesSearchBox_TextChanged;

            _isInitialized = true;
        }

        // =====================================================
        // Helper safe setters to avoid NullReferenceExceptions
        // =====================================================
        private void SafeSetVisibility(FrameworkElement element, Visibility visibility)
        {
            if (element != null)
                element.Visibility = visibility;
        }

        private void SafeSetForeground(TextBlock textBlock, Brush brush)
        {
            if (textBlock != null)
                textBlock.Foreground = brush;
        }

        // =====================================================
        // OVERLAY METHODS
        // =====================================================

        private void AddItem_Click(object sender, RoutedEventArgs e)
        {
            SafeSetVisibility(OverlayContainer, Visibility.Visible);
            SafeSetVisibility(AddItemOverlay, Visibility.Visible);

            if (ItemTypeToggle != null)
            {
                ItemTypeToggle.IsOn = true;
                SetProductMode();
            }
            ClearOverlayFields();
        }

        private void AddService_Click(object sender, RoutedEventArgs e)
        {
            SafeSetVisibility(OverlayContainer, Visibility.Visible);
            SafeSetVisibility(AddItemOverlay, Visibility.Visible);

            if (ItemTypeToggle != null)
            {
                ItemTypeToggle.IsOn = false;
                SetServiceMode();
            }
            ClearOverlayFields();
        }

        private void CloseAddItem_Click(object sender, RoutedEventArgs e)
        {
            SafeSetVisibility(OverlayContainer, Visibility.Collapsed);
            SafeSetVisibility(AddItemOverlay, Visibility.Collapsed);
        }

        private void SaveItem_Click(object sender, RoutedEventArgs e)
        {
            SaveOverlayItem();
            SafeSetVisibility(OverlayContainer, Visibility.Collapsed);
            SafeSetVisibility(AddItemOverlay, Visibility.Collapsed);
        }

        private void SaveAndNew_Click(object sender, RoutedEventArgs e)
        {
            SaveOverlayItem();
            ClearOverlayFields();

            if (ItemTypeToggle != null && ItemTypeToggle.IsOn)
                ItemNameTextBox?.Focus(FocusState.Programmatic);
            else
                ServiceNameTextBox?.Focus(FocusState.Programmatic);
        }

        private void ClearOverlayFields()
        {
            // Clear product fields
            if (ItemNameTextBox != null) ItemNameTextBox.Text = "";
            if (HsnTextBox != null) HsnTextBox.Text = "";
            if (ItemCodeTextBox != null) ItemCodeTextBox.Text = "";
            if (CategoryComboBox != null) CategoryComboBox.SelectedIndex = -1;
            if (SalePriceTextBox != null) SalePriceTextBox.Text = "";
            if (PurchasePriceTextBox != null) PurchasePriceTextBox.Text = "";
            if (OpeningQtyTextBox != null) OpeningQtyTextBox.Text = "";
            if (AtPriceTextBox != null) AtPriceTextBox.Text = "";
            if (MinStockTextBox != null) MinStockTextBox.Text = "";

            // Clear service fields
            if (ServiceNameTextBox != null) ServiceNameTextBox.Text = "";
            if (ServiceCodeTextBox != null) ServiceCodeTextBox.Text = "";
        }

        private void SaveOverlayItem()
        {
            bool isService = !(ItemTypeToggle?.IsOn ?? true);

            if (isService)
            {
                // Save service
                var service = new ServiceModel
                {
                    ServiceName = ServiceNameTextBox?.Text,
                    Code = ServiceCodeTextBox?.Text,
                    Rate = 500, // Default rate
                    Category = "General",
                    Description = "Service description"
                };

                Services.Add(service);
                _hasServices = true;
                UpdateFilteredServices();

                // Update services view if on services tab
                if (ServicesPanel != null && ServicesPanel.Visibility == Visibility.Visible)
                {
                    UpdateServicesView();
                }
            }
            else
            {
                // Save product
                var item = new ItemModel
                {
                    Name = ItemNameTextBox?.Text,
                    Code = ItemCodeTextBox?.Text,
                    StockQty = int.TryParse(OpeningQtyTextBox?.Text, out int qty) ? qty : 0,
                    SalePrice = decimal.TryParse(SalePriceTextBox?.Text, out decimal salePrice) ? salePrice : 0,
                    PurchasePrice = decimal.TryParse(PurchasePriceTextBox?.Text, out decimal purchasePrice) ? purchasePrice : 0,
                    HSN = HsnTextBox?.Text
                };

                Items.Add(item);
                UpdateFilteredItems();

                // Select the new item
                if (ItemsList != null) ItemsList.SelectedItem = item;
            }

            // Reset to product mode
            if (ItemTypeToggle != null)
            {
                ItemTypeToggle.IsOn = true;
                SetProductMode();
            }
        }

        // =====================================================
        // CATEGORY OVERLAY
        // =====================================================

        private void AddCategory_Click(object sender, RoutedEventArgs e)
        {
            SafeSetVisibility(OverlayContainer, Visibility.Visible);
            SafeSetVisibility(AddCategoryOverlay, Visibility.Visible);
            if (CategoryNameBox != null) CategoryNameBox.Text = "";
        }

        private void CloseAddCategory_Click(object sender, RoutedEventArgs e)
        {
            SafeSetVisibility(OverlayContainer, Visibility.Collapsed);
            SafeSetVisibility(AddCategoryOverlay, Visibility.Collapsed);
        }

        private void CreateCategory_Click(object sender, RoutedEventArgs e)
        {
            string categoryName = CategoryNameBox?.Text?.Trim();

            if (!string.IsNullOrEmpty(categoryName))
            {
                // TODO: Add category logic here
            }

            SafeSetVisibility(OverlayContainer, Visibility.Collapsed);
            SafeSetVisibility(AddCategoryOverlay, Visibility.Collapsed);
        }

        // =====================================================
        // UNIT OVERLAY
        // =====================================================

        private void AddUnit_Click(object sender, RoutedEventArgs e)
        {
            SafeSetVisibility(OverlayContainer, Visibility.Visible);
            SafeSetVisibility(AddUnitOverlay, Visibility.Visible);

            if (UnitNameBox != null) UnitNameBox.Text = "";
            if (UnitShortNameBox != null) UnitShortNameBox.Text = "";
        }

        private void CloseAddUnit_Click(object sender, RoutedEventArgs e)
        {
            SafeSetVisibility(OverlayContainer, Visibility.Collapsed);
            SafeSetVisibility(AddUnitOverlay, Visibility.Collapsed);
        }

        private void SaveUnit_Click(object sender, RoutedEventArgs e)
        {
            string unitName = UnitNameBox?.Text?.Trim();
            string shortName = UnitShortNameBox?.Text?.Trim();

            if (!string.IsNullOrEmpty(unitName))
            {
                // TODO: Save unit logic here
            }

            SafeSetVisibility(OverlayContainer, Visibility.Collapsed);
            SafeSetVisibility(AddUnitOverlay, Visibility.Collapsed);
        }

        private void SaveNewUnit_Click(object sender, RoutedEventArgs e)
        {
            string unitName = UnitNameBox?.Text?.Trim();
            string shortName = UnitShortNameBox?.Text?.Trim();

            if (!string.IsNullOrEmpty(unitName))
            {
                // TODO: Save unit logic here
            }

            // Clear fields for next entry
            if (UnitNameBox != null) UnitNameBox.Text = "";
            if (UnitShortNameBox != null) UnitShortNameBox.Text = "";
            UnitNameBox?.Focus(FocusState.Programmatic);
        }

        // =====================================================
        // CONVERSION OVERLAY
        // =====================================================

        private void AddConversion_Click(object sender, RoutedEventArgs e)
        {
            SafeSetVisibility(OverlayContainer, Visibility.Visible);
            SafeSetVisibility(AddConversionOverlay, Visibility.Visible);
        }

        private void CloseAddConversion_Click(object sender, RoutedEventArgs e)
        {
            SafeSetVisibility(OverlayContainer, Visibility.Collapsed);
            SafeSetVisibility(AddConversionOverlay, Visibility.Collapsed);
        }

        private void SaveConversion_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Save conversion logic
            SafeSetVisibility(OverlayContainer, Visibility.Collapsed);
            SafeSetVisibility(AddConversionOverlay, Visibility.Collapsed);
        }

        private void SaveAndNewConversion_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Save conversion and clear fields for next entry
        }

        // =====================================================
        // STOCK ADJUSTMENT OVERLAY
        // =====================================================

        private void AdjustItem_Click(object sender, RoutedEventArgs e)
        {
            if (ItemsList?.SelectedItem is ItemModel selectedItem)
            {
                if (AdjustItemName != null) AdjustItemName.Text = selectedItem.Name;
                SafeSetVisibility(OverlayContainer, Visibility.Visible);
                SafeSetVisibility(StockAdjustmentOverlay, Visibility.Visible);
            }
        }

        private void CloseStockAdjustment_Click(object sender, RoutedEventArgs e)
        {
            SafeSetVisibility(OverlayContainer, Visibility.Collapsed);
            SafeSetVisibility(StockAdjustmentOverlay, Visibility.Collapsed);
        }

        private void SaveStockAdjustment_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Save stock adjustment logic
            SafeSetVisibility(OverlayContainer, Visibility.Collapsed);
            SafeSetVisibility(StockAdjustmentOverlay, Visibility.Collapsed);
        }

        // =====================================================
        // TOP TABS NAVIGATION
        // =====================================================

        private void ProductsTab_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ShowPanel("Items");
            UpdateTabColors("Products");
        }

        private void ServicesTab_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ShowPanel("Services");
            UpdateTabColors("Services");
            UpdateServicesView();
        }

        private void CategoriesTab_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ShowPanel("Categories");
            UpdateTabColors("Categories");
        }

        private void UnitsTab_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ShowPanel("Units");
            UpdateTabColors("Units");
        }

        private void ShowPanel(string panelName)
        {
            SafeSetVisibility(ItemsPanel, Visibility.Collapsed);
            SafeSetVisibility(ServicesPanel, Visibility.Collapsed);
            SafeSetVisibility(CategoriesPanel, Visibility.Collapsed);
            SafeSetVisibility(UnitsPanel, Visibility.Collapsed);

            switch (panelName)
            {
                case "Items":
                    SafeSetVisibility(ItemsPanel, Visibility.Visible);
                    break;
                case "Services":
                    SafeSetVisibility(ServicesPanel, Visibility.Visible);
                    break;
                case "Categories":
                    SafeSetVisibility(CategoriesPanel, Visibility.Visible);
                    break;
                case "Units":
                    SafeSetVisibility(UnitsPanel, Visibility.Visible);
                    break;
            }
        }

        private void UpdateTabColors(string activeTab)
        {
            // Reset all tabs
            var transparent = new SolidColorBrush(Colors.Transparent);
            var gray = new SolidColorBrush(Colors.Gray);
            var blueBackground = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 219, 234, 254));
            var blueForeground = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 37, 99, 235));

            if (ProductsTabBorder != null) ProductsTabBorder.Background = transparent;
            if (ServicesTabBorder != null) ServicesTabBorder.Background = transparent;
            if (CategoriesTabBorder != null) CategoriesTabBorder.Background = transparent;
            if (UnitsTabBorder != null) UnitsTabBorder.Background = transparent;

            var productsText = (TextBlock?)ProductsTabBorder?.Child;
            var servicesText = (TextBlock?)ServicesTabBorder?.Child;
            var categoriesText = (TextBlock?)CategoriesTabBorder?.Child;
            var unitsText = (TextBlock?)UnitsTabBorder?.Child;

            if (productsText != null) productsText.Foreground = gray;
            if (servicesText != null) servicesText.Foreground = gray;
            if (categoriesText != null) categoriesText.Foreground = gray;
            if (unitsText != null) unitsText.Foreground = gray;

            // Activate selected tab
            switch (activeTab)
            {
                case "Products":
                    if (ProductsTabBorder != null) ProductsTabBorder.Background = blueBackground;
                    if (productsText != null) productsText.Foreground = blueForeground;
                    break;
                case "Services":
                    if (ServicesTabBorder != null) ServicesTabBorder.Background = blueBackground;
                    if (servicesText != null) servicesText.Foreground = blueForeground;
                    break;
                case "Categories":
                    if (CategoriesTabBorder != null) CategoriesTabBorder.Background = blueBackground;
                    if (categoriesText != null) categoriesText.Foreground = blueForeground;
                    break;
                case "Units":
                    if (UnitsTabBorder != null) UnitsTabBorder.Background = blueBackground;
                    if (unitsText != null) unitsText.Foreground = blueForeground;
                    break;
            }
        }

        // =====================================================
        // PRODUCT/SERVICE TOGGLE
        // =====================================================

        private void ItemTypeToggle_Toggled(object sender, RoutedEventArgs e)
        {
            if (ItemTypeToggle.IsOn)
                SetProductMode();
            else
                SetServiceMode();
        }

        private void SetProductMode()
        {
            if (ProductFieldsPanel != null)
                ProductFieldsPanel.Visibility = Visibility.Visible;
            if (ServiceFieldsPanel != null)
                ServiceFieldsPanel.Visibility = Visibility.Collapsed;

            ActivatePricingTab();
        }

        private void SetServiceMode()
        {
            if (ProductFieldsPanel != null)
                ProductFieldsPanel.Visibility = Visibility.Collapsed;
            if (ServiceFieldsPanel != null)
                ServiceFieldsPanel.Visibility = Visibility.Visible;

            // Services don't have stock section
            SafeSetVisibility(PricingSection, Visibility.Visible);
            SafeSetVisibility(StockSection, Visibility.Collapsed);
            ActivatePricingTab();
        }

        // =====================================================
        // PRICING/STOCK TABS
        // =====================================================

        private void PricingTab_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ActivatePricingTab();
        }

        private void StockTab_Tapped(object sender, TappedRoutedEventArgs e)
        {
            // Only for products
            if (!ItemTypeToggle.IsOn) return;

            SafeSetVisibility(PricingSection, Visibility.Collapsed);
            SafeSetVisibility(StockSection, Visibility.Visible);

            SafeSetForeground(PricingTab, new SolidColorBrush(Colors.Gray));
            SafeSetForeground(StockTab, new SolidColorBrush(Windows.UI.Color.FromArgb(255, 220, 38, 38)));
        }

        private void ActivatePricingTab()
        {
            SafeSetVisibility(PricingSection, Visibility.Visible);
            SafeSetVisibility(StockSection, Visibility.Collapsed);

            SafeSetForeground(PricingTab, new SolidColorBrush(Windows.UI.Color.FromArgb(255, 220, 38, 38)));
            SafeSetForeground(StockTab, new SolidColorBrush(Colors.Gray));
        }

        // =====================================================
        // BUSINESS NAME
        // =====================================================

        private void BusinessNameTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            var lightBlue = Windows.UI.Color.FromArgb(20, 2, 132, 199);
            var blue = Windows.UI.Color.FromArgb(255, 2, 132, 199);

            if (BusinessNameTextBox != null)
            {
                BusinessNameTextBox.Background = new SolidColorBrush(lightBlue);
                BusinessNameTextBox.BorderThickness = new Thickness(0, 0, 0, 1);
                BusinessNameTextBox.BorderBrush = new SolidColorBrush(blue);
            }
        }

        private void BusinessNameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (BusinessNameTextBox != null)
            {
                BusinessNameTextBox.Background = new SolidColorBrush(Colors.Transparent);
                BusinessNameTextBox.BorderThickness = new Thickness(0);
                BusinessNameTextBox.BorderBrush = new SolidColorBrush(Colors.Transparent);
            }
        }

        private void BusinessNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SaveBusinessNameButton != null)
            {
                SaveBusinessNameButton.Visibility = Visibility.Visible;
            }
        }

        private void SaveBusinessName_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Save business name
            if (SaveBusinessNameButton != null)
            {
                SaveBusinessNameButton.Visibility = Visibility.Collapsed;
            }
        }

        // =====================================================
        // OTHER ACTION BUTTONS
        // =====================================================

        private void AddSale_Click(object sender, RoutedEventArgs e)
        {
            // Open a new sale tab via MainWindow singleton instance
            try
            {
                MainWindow.Instance?.OpenNewSaleTab();
            }
            catch
            {
                // Fallback: navigate in current frame if available
                var frame = Window.Current?.Content as Frame;
                frame?.Navigate(typeof(SalePage));
            }
        }

        private void AddPurchase_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Implement add purchase
        }

        private void ItemMoreButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Show context menu for item
        }

        // =====================================================
        // SEARCH FUNCTIONALITY
        // =====================================================

        private void ItemsSearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateFilteredItems();
        }

        private void ServicesSearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateFilteredServices();
        }

        private void UpdateFilteredItems()
        {
            FilteredItems.Clear();
            var searchText = ItemsSearchBox?.Text?.ToLower() ?? "";

            if (string.IsNullOrWhiteSpace(searchText))
            {
                foreach (var item in Items)
                {
                    FilteredItems.Add(item);
                }
            }
            else
            {
                foreach (var item in Items.Where(i => i.Name.ToLower().Contains(searchText)))
                {
                    FilteredItems.Add(item);
                }
            }
        }

        private void UpdateFilteredServices()
        {
            FilteredServices.Clear();
            var searchText = ServicesSearchBox?.Text?.ToLower() ?? "";

            if (string.IsNullOrWhiteSpace(searchText))
            {
                foreach (var service in Services)
                {
                    FilteredServices.Add(service);
                }
            }
            else
            {
                foreach (var service in Services.Where(s =>
                    s.ServiceName.ToLower().Contains(searchText) ||
                    (s.Code?.ToLower().Contains(searchText) ?? false)))
                {
                    FilteredServices.Add(service);
                }
            }
        }

        // =====================================================
        // LIST SELECTION
        // =====================================================

        private void ItemsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ItemsList.SelectedItem is ItemModel selectedItem)
            {
                UpdateItemDetails(selectedItem);
            }
        }

        private void ServicesListControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ServicesListControl.SelectedItem is ServiceModel selectedService)
            {
                UpdateServiceDetails(selectedService);
            }
        }

        private void UpdateItemDetails(ItemModel item)
        {
            if (SelectedItemName != null) SelectedItemName.Text = item.Name;
            if (SelectedItemSku != null) SelectedItemSku.Text = $"SKU : {item.Code ?? "---"}";
            if (SalePriceText != null) SalePriceText.Text = $"SALE PRICE : ₹{item.SalePrice:F2} (excl)";
            if (PurchasePriceText != null) PurchasePriceText.Text = $"PURCHASE PRICE : ₹{item.PurchasePrice:F2} (excl)";
            if (StockQtyText != null) StockQtyText.Text = $"STOCK QUANTITY : {item.StockQty}";
            if (StockValueText != null) StockValueText.Text = $"STOCK VALUE : ₹{(item.StockQty * item.PurchasePrice):F2}";
        }

        private void UpdateServiceDetails(ServiceModel service)
        {
            if (SelectedServiceName != null) SelectedServiceName.Text = service.ServiceName;
            // Note: You need to add these properties to ServiceModel or create them in XAML
            // if (SelectedServiceCode != null) SelectedServiceCode.Text = $"Code: {service.Code ?? "---"}";
            // if (ServiceRateText != null) ServiceRateText.Text = $"₹{service.Rate:F2}";
            // if (ServiceGstText != null) ServiceGstText.Text = $"{service.TaxRate}%";
            // if (ServiceDescriptionText != null) ServiceDescriptionText.Text = service.Description ?? "No description available.";
        }

        private void UpdateServicesView()
        {
            if (_hasServices)
            {
                SafeSetVisibility(ServicesEmptyPanel, Visibility.Collapsed);
                SafeSetVisibility(ServicesMainPanel, Visibility.Visible);
            }
            else
            {
                SafeSetVisibility(ServicesEmptyPanel, Visibility.Visible);
                SafeSetVisibility(ServicesMainPanel, Visibility.Collapsed);
            }
        }

        // =====================================================
        // DUMMY DATA
        // =====================================================

        private void LoadDummyItems()
        {
            Items.Add(new ItemModel
            {
                Name = "Rice Bag",
                StockQty = 12,
                SalePrice = 100,
                PurchasePrice = 80,
                Code = "ITM-001"
            });
        }

        private void LoadDummyServices()
        {
            // Initially empty
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (FilteredItems.Count > 0 && ItemsList.SelectedIndex == -1)
            {
                ItemsList.SelectedIndex = 0;
            }
        }
    }
}