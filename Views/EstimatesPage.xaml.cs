using App_3.ViewModels;
using Microsoft.UI.Xaml.Controls;

namespace App_3.Views
{
    public sealed partial class EstimatesPage : Page
    {
        public EstimatesViewModel ViewModel { get; }
            = new EstimatesViewModel();

        public EstimatesPage()
        {
            InitializeComponent();
            DataContext = ViewModel;
        }
    }
}
