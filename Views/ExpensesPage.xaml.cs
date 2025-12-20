using App_3.Models;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.ObjectModel;

namespace App_3.Views
{
    public sealed partial class ExpensesPage : Page
    {
        public ObservableCollection<ExpenseModel> Expenses { get; set; }

        public ExpensesPage()
        {
            this.InitializeComponent();
            LoadDummyData();
            ExpensesItemsControl.ItemsSource = Expenses;
        }

        private void LoadDummyData()
        {
            Expenses = new ObservableCollection<ExpenseModel>
            {
                new ExpenseModel { Vendor = "Amazon", Category = "Office Supplies", Amount = "₹ 1,200", PaymentMode = "Card", Status = "Paid", Date = DateTime.Now.AddDays(-2), Notes="Stationery" },
                new ExpenseModel { Vendor = "Ola", Category = "Travel", Amount = "₹ 350", PaymentMode = "Cash", Status = "Unpaid", Date = DateTime.Now.AddDays(-1), Notes="Taxi to client" },
                new ExpenseModel { Vendor = "Flipkart", Category = "Electronics", Amount = "₹ 8,000", PaymentMode = "Online", Status = "Paid", Date = DateTime.Now.AddDays(-10), Notes="Headset purchase" },
                new ExpenseModel { Vendor = "Domino's", Category = "Food", Amount = "₹ 500", PaymentMode = "Cash", Status = "Paid", Date = DateTime.Now, Notes="Team lunch" },
            };
        }

        // Open Add Expense Form
        private void AddExpense_Click(object sender, RoutedEventArgs e)
        {
            ClearForm();
            ExpenseFormOverlay.Visibility = Visibility.Visible;
        }

        // Open Edit Expense Form (dummy)
        private void EditExpense_Click(object sender, RoutedEventArgs e)
        {
            ExpenseFormOverlay.Visibility = Visibility.Visible;
        }

        // Cancel Form
        private void CancelExpenseForm_Click(object sender, RoutedEventArgs e)
        {
            ExpenseFormOverlay.Visibility = Visibility.Collapsed;
        }

        // Save Form (dummy)
        private void SaveExpenseForm_Click(object sender, RoutedEventArgs e)
        {
            // Optional: Add logic to save
            ExpenseFormOverlay.Visibility = Visibility.Collapsed;
        }

        private void ClearForm()
        {
        }

        // SAVE EXPENSE (from row / form)
        private void SaveExpense_Click(object sender, RoutedEventArgs e)
        {
            // Dummy save logic
            ExpenseFormOverlay.Visibility = Visibility.Collapsed;
        }

        // DELETE EXPENSE
        private void DeleteExpense_Click(object sender, RoutedEventArgs e)
        {
            // Dummy delete logic
            if (sender is Button btn && btn.DataContext is ExpenseModel expense)
            {
                Expenses.Remove(expense);
            }
        }

    }
}
