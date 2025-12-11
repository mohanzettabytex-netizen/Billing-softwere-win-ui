using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.ObjectModel;
using System.Timers;

namespace App3.Views
{
    public sealed partial class HomePage : Page
    {
        public ObservableCollection<DashboardCard> Cards { get; set; } = new();
        public ObservableCollection<Transaction> Transactions { get; set; } = new();

        public HomePage()
        {
            this.InitializeComponent();

            // Setup demo dashboard cards
            Cards.Add(new DashboardCard { Title = "Total Sales", Value = "₹12000", Status = "Active" });
            Cards.Add(new DashboardCard { Title = "Customers", Value = "25", Status = "Active" });
            Cards.Add(new DashboardCard { Title = "Items", Value = "100", Status = "Active" });
            Cards.Add(new DashboardCard { Title = "New Orders", Value = "5", Status = "Active" });

            DashboardCards.ItemsSource = Cards;

            // Setup demo transactions
            Transactions.Add(new Transaction { InvoiceNumber = "INV001", CustomerName = "John Doe", Amount = "₹500", Date = "10-Dec-2025" });
            Transactions.Add(new Transaction { InvoiceNumber = "INV002", CustomerName = "Jane Smith", Amount = "₹1500", Date = "10-Dec-2025" });
            TransactionsList.ItemsSource = Transactions;

            // Real-time clock
            Timer timer = new Timer(1000);
            timer.Elapsed += (s, e) =>
            {
                DispatcherQueue.TryEnqueue(() => DateTimeText.Text = DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss"));
            };
            timer.Start();
        }
    }
}
