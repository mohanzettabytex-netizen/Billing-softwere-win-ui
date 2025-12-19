using App_3.Models;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.ObjectModel;

namespace App_3.Views
{
    public sealed partial class RecurringInvoicesPage : Page
    {
        private ObservableCollection<RecurringInvoice> RecurringInvoices;

        public RecurringInvoicesPage()
        {
            this.InitializeComponent();
            LoadDummyData();
        }

        private void LoadDummyData()
        {
            RecurringInvoices = new ObservableCollection<RecurringInvoice>
            {
                new RecurringInvoice{TemplateID=1, Customer="Alice", TemplateName="Weekly Supplies", Amount=5000, Frequency="Weekly", NextInvoiceDate=DateTime.Today.AddDays(7), Status="Active"},
                new RecurringInvoice{TemplateID=2, Customer="Bob", TemplateName="Monthly Maintenance", Amount=2500, Frequency="Monthly", NextInvoiceDate=DateTime.Today.AddDays(30), Status="Paused"},
                new RecurringInvoice{TemplateID=3, Customer="Charlie", TemplateName="Quarterly Audit", Amount=3000, Frequency="Quarterly", NextInvoiceDate=DateTime.Today.AddDays(90), Status="Completed"},
            };

            RecurringInvoicesItemsControl.ItemsSource = RecurringInvoices;
        }
    }
}
