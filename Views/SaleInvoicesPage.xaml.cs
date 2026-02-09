using App_3.Models;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace App_3.Views
{
    public sealed partial class SaleInvoicesPage : Page
    {
        // ================= DATA =================
        public ObservableCollection<SaleInvoiceModel> Transactions { get; }
            = new ObservableCollection<SaleInvoiceModel>();

        public SaleInvoicesPage()
        {
            InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Enabled;
            UpdateState();
        }

        // ================= BUSINESS NAME EDIT =================

        private void BusinessNameText_Tapped(object sender, TappedRoutedEventArgs e)
        {
            BusinessNameText.Visibility = Visibility.Collapsed;
            BusinessNameEditor.Visibility = Visibility.Visible;
            BusinessNameBox.Focus(FocusState.Programmatic);
        }

        private void SaveBusinessName_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(BusinessNameBox.Text))
            {
                BusinessNameText.Text = BusinessNameBox.Text;
                BusinessNameText.Foreground = new SolidColorBrush(Microsoft.UI.Colors.Black);
            }

            BusinessNameEditor.Visibility = Visibility.Collapsed;
            BusinessNameText.Visibility = Visibility.Visible;
        }

        // ================= DATE RANGE =================

        private void CancelDate_Click(object sender, RoutedEventArgs e)
        {
            FlyoutBase.GetAttachedFlyout(DateRangeButton)?.Hide();
        }

        private void ApplyDate_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(FromDateBox.Text) &&
                !string.IsNullOrEmpty(ToDateBox.Text))
            {
                DateRangeText.Text = $"{FromDateBox.Text} - {ToDateBox.Text}";
            }

            FlyoutBase.GetAttachedFlyout(DateRangeButton)?.Hide();
        }

        private void DatePickerCalendar_SelectedDatesChanged(
            CalendarView sender,
            CalendarViewSelectedDatesChangedEventArgs args)
        {
            if (sender.SelectedDates.Count == 0)
                return;

            var dates = sender.SelectedDates
                              .OrderBy(d => d)
                              .ToList();

            FromDateBox.Text = dates[0].ToString("dd/MM/yyyy");

            if (dates.Count > 1)
                ToDateBox.Text = dates[1].ToString("dd/MM/yyyy");
            else
                ToDateBox.Text = dates[0].ToString("dd/MM/yyyy");
        }

        // ================= ADD SALE =================

        private void AddSale_Click(object sender, RoutedEventArgs e)
        {
            Transactions.Add(new SaleInvoiceModel
            {
                Date = new DateTime(2026, 1, 10),
                InvoiceNo = "1",
                PartyName = "Nil",
                TransactionType = "Sale",
                PaymentType = "Cash",
                Amount = 0,
                Balance = 0
            });

            UpdateState();
        }

        // ================= UI STATE =================

        private void UpdateState()
        {
            if (Transactions.Count == 0)
            {
                EmptyState.Visibility = Visibility.Visible;
                TransactionsList.Visibility = Visibility.Collapsed;
            }
            else
            {
                EmptyState.Visibility = Visibility.Collapsed;
                TransactionsList.Visibility = Visibility.Visible;
            }
        }
    }
}
