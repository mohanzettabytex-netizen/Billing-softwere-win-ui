using App_3.Models;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System.Collections.Generic;
using System;

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
             
            };

            TopSellingItemsList.ItemsSource = topItems;

            // ================= ALERTS =================
            var alerts = new List<AlertModel>
            {
               
            };

            AlertsList.ItemsSource = alerts;
        }
    }
}
