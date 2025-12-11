using App_3.Views;
using App3.Views;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;

namespace App_3
{
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();

            // Default page: HomePage
            ContentFrame.Navigate(typeof(HomePage));

            // NavView selection changed
            NavView.SelectionChanged += NavView_SelectionChanged;
        }

        private void NavView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.SelectedItemContainer is NavigationViewItem selectedItem)
            {
                string tag = selectedItem.Tag?.ToString();
                Type pageType = null;

                switch (tag)
                {
                    case "Home":
                        pageType = typeof(HomePage);
                        break;
                    case "Parties":
                        pageType = typeof(PartiesPage);
                        break;
                    case "ItemsManagement":
                        pageType = typeof(ItemsManagementPage);
                        break;
                    case "Quotes":
                        pageType = typeof(QuotesPage);
                        break;
                    case "Invoice":
                        pageType = typeof(InvoicePage);
                        break;
                    case "PaymentLinks":
                        pageType = typeof(PaymentsLinksPage);
                        break;
                    case "PaymentsReceived":
                        pageType = typeof(PaymentReceivedPage);
                        break;
                    case "RecurringInvoices":
                        pageType = typeof(RecurringInvoicesPage);
                        break;
                }

                // Only navigate if it's a different page
                if (pageType != null && ContentFrame.CurrentSourcePageType != pageType)
                {
                    ContentFrame.Navigate(pageType);
                }
            }
        }
    }
}
