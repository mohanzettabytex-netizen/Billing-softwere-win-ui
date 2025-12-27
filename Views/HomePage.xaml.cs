using App_3.Models;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI;
using Microsoft.UI.Xaml.Media;
using System.Collections.Generic;

namespace App_3.Views
{
    public sealed partial class HomePage : Page
    {
        public HomePage()
        {
            this.InitializeComponent();
            LoadDashboardData();
        }

        private void LoadDashboardData()
        {
            // ================= METRICS =================
            CustomersCount.Text = "128";
            SuppliersCount.Text = "52";
            TodaySalesAmount.Text = "₹12,450";
            TodayExpenses.Text = "₹4,300";
            TodayProfit.Text = "₹8,150";

            // ================= TOP SELLING ITEMS =================
            var topItems = new List<TopItemModel>
    {
        new TopItemModel { ItemName="Product A", QuantitySold=15, RevenueFormatted="₹4,500" },
        new TopItemModel { ItemName="Product B", QuantitySold=10, RevenueFormatted="₹3,000" },
        new TopItemModel { ItemName="Product C", QuantitySold=8, RevenueFormatted="₹2,400" }
    };
            TopSellingItemsList.ItemsSource = topItems;

            // ================= ALERTS =================
            var alerts = new List<AlertModel>
    {
        new AlertModel { Type="Payment Received", Message="Invoice #101 paid", Timestamp="5 mins ago", AlertColor="#D1FAE5" },
        new AlertModel { Type="Low Stock", Message="Product B is low", Timestamp="20 mins ago", AlertColor="#FEE2E2" }
    };
            AlertsList.ItemsSource = alerts;
        }
    }
}

