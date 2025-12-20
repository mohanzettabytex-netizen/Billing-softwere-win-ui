using App_3.Models;
using Microsoft.UI.Xaml.Controls;
using System.Collections.ObjectModel;

namespace App_3.Views
{
    public sealed partial class ReportsPage : Page
    {
        public ObservableCollection<ReportSummaryModel> SummaryCards { get; set; }

        public ReportsPage()
        {
            this.InitializeComponent();
            LoadDummyData();
        }

        private void LoadDummyData()
        {
            SummaryCards = new ObservableCollection<ReportSummaryModel>
            {
                new ReportSummaryModel
                {
                    Title = "Total Sales",
                    Amount = "₹ 1,25,000",
                    ColorHex = "#15803D"
                },
                new ReportSummaryModel
                {
                    Title = "Total Expenses",
                    Amount = "₹ 42,000",
                    ColorHex = "#DC2626"
                },
                new ReportSummaryModel
                {
                    Title = "Net Profit",
                    Amount = "₹ 83,000",
                    ColorHex = "#2563EB"
                },
                new ReportSummaryModel
                {
                    Title = "Pending Amount",
                    Amount = "₹ 18,500",
                    ColorHex = "#F59E0B"
                }
            };
        }
    }
}
