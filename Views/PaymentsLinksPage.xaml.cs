using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Windows.ApplicationModel.DataTransfer;
using App_3.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace App_3.Views
{
    public sealed partial class PaymentsLinksPage : Page
    {
        public ObservableCollection<PaymentLink> PaymentLinks { get; set; } = new();
        public ObservableCollection<PaymentLink> FilteredLinks { get; set; } = new();

        public PaymentsLinksPage()
        {
            this.InitializeComponent();
            PaymentList.ItemsSource = FilteredLinks;
            RefreshFiltered();
        }

        private void AddLink_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(NameInput.Text) && !string.IsNullOrWhiteSpace(LinkInput.Text))
            {
                PaymentLinks.Add(new PaymentLink
                {
                    Name = NameInput.Text,
                    Link = LinkInput.Text,
                    Status = (LinkStatus)StatusCombo.SelectedIndex
                });
                RefreshFiltered();
                ClearInputs();
            }
        }

        private void EditLink_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is PaymentLink link)
            {
                NameInput.Text = link.Name;
                LinkInput.Text = link.Link;
                StatusCombo.SelectedIndex = (int)link.Status;
                PaymentList.SelectedItem = link;
            }
        }

        private void UpdateLink_Click(object sender, RoutedEventArgs e)
        {
            if (PaymentList.SelectedItem is PaymentLink selected)
            {
                selected.Name = NameInput.Text;
                selected.Link = LinkInput.Text;
                selected.Status = (LinkStatus)StatusCombo.SelectedIndex;
                RefreshFiltered();
                ClearInputs();
            }
        }

        private void DeleteLink_Click(object sender, RoutedEventArgs e)
        {
            PaymentLink target = null;

            if (sender is Button btn && btn.Tag is PaymentLink link)
                target = link;
            else if (PaymentList.SelectedItem is PaymentLink selected)
                target = selected;

            if (target != null)
            {
                PaymentLinks.Remove(target);
                RefreshFiltered();
                ClearInputs();
            }
        }

        private void CopyLink_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is PaymentLink link)
            {
                var data = new DataPackage();
                data.SetText(link.Link);
                Clipboard.SetContent(data);
            }
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            RefreshFiltered(SearchBox.Text);
        }

        private void ClearInputs()
        {
            NameInput.Text = "";
            LinkInput.Text = "";
            StatusCombo.SelectedIndex = 0;
            PaymentList.SelectedItem = null;
        }

        private void RefreshFiltered(string query = "")
        {
            FilteredLinks.Clear();
            foreach (var link in PaymentLinks.Where(x => x.Name.ToLower().Contains(query.ToLower())
                                                      || x.Link.ToLower().Contains(query.ToLower())))
            {
                FilteredLinks.Add(link);
            }
        }
    }
}
