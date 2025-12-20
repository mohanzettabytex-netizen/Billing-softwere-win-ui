using App_3.Views;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;

namespace App_3
{
    public sealed partial class MainWindow : Window
    {
        // Singleton instances for pages that need state retention
        private ItemsPage itemsPageInstance;
        private HomePage homePageInstance;
        private PartiesPage partiesPageInstance;
        private InvoicePage invoicePageInstance;
        private QuotesPage quotesPageInstance;
        private PaymentLinksPage paymentLinksPageInstance;
        private PaymentReceivedPage paymentsReceivedPageInstance;
        private RecurringInvoicesPage recurringInvoicesPageInstance;
        private ExpensesPage expensesPageInstance;
        private ReportsPage reportsPageInstance;

        public MainWindow()
        {
            this.InitializeComponent();

            // Initialize default page
            homePageInstance = new HomePage();
            ContentFrame.Navigate(homePageInstance.GetType());

            // NavView selection changed
            NavView.SelectionChanged += NavView_SelectionChanged;
        }

        private void NavView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.SelectedItemContainer is NavigationViewItem selectedItem)
            {
                string tag = selectedItem.Tag?.ToString();
                object pageInstance = null;

                switch (tag)
                {
                    case "Home":
                        if (homePageInstance == null) homePageInstance = new HomePage();
                        pageInstance = homePageInstance;
                        break;

                    case "Parties":
                        if (partiesPageInstance == null) partiesPageInstance = new PartiesPage();
                        pageInstance = partiesPageInstance;
                        break;

                    case "Items":
                        if (itemsPageInstance == null) itemsPageInstance = new ItemsPage();
                        pageInstance = itemsPageInstance;
                        break;

                    case "Invoice":
                        if (invoicePageInstance == null) invoicePageInstance = new InvoicePage();
                        pageInstance = invoicePageInstance;
                        break;

                    case "Quotes":
                        if (quotesPageInstance == null) quotesPageInstance = new QuotesPage();
                        pageInstance = quotesPageInstance;
                        break;


                    case "PaymentLinks":
                        if (paymentLinksPageInstance == null) paymentLinksPageInstance = new PaymentLinksPage();
                        pageInstance = paymentLinksPageInstance;
                        break;

                    case "PaymentsReceived":
                        if (paymentsReceivedPageInstance == null) paymentsReceivedPageInstance = new PaymentReceivedPage();
                        pageInstance = paymentsReceivedPageInstance;
                        break;

                    case "RecurringInvoices":
                        if (recurringInvoicesPageInstance == null) recurringInvoicesPageInstance = new RecurringInvoicesPage();
                        pageInstance = recurringInvoicesPageInstance;
                        break;

                    case "Expenses":
                        if (expensesPageInstance == null) expensesPageInstance = new ExpensesPage();
                        pageInstance = expensesPageInstance;
                        break;

                    case "Reports":
                        if (reportsPageInstance == null) reportsPageInstance = new ReportsPage();
                        pageInstance = reportsPageInstance;
                        break;



                }

                // Navigate only if a valid instance is selected
                if (pageInstance != null && ContentFrame.Content != pageInstance)
                {
                    ContentFrame.Navigate(pageInstance.GetType());
                }
            }
        }
    }
}
