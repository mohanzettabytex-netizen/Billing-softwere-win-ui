using App_3.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace App_3.ViewModels
{
    public class EstimatesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        // ================= LIST =================
        public ObservableCollection<EstimateModel> Estimates { get; }
            = new ObservableCollection<EstimateModel>();

        // ================= SUMMARY =================
        public decimal TotalQuotations =>
            Estimates.Sum(e => e.TotalAmount);

        public decimal ConvertedAmount =>
            Estimates.Where(e => e.IsConverted)
                     .Sum(e => e.TotalAmount);

        public decimal OpenAmount =>
            Estimates.Where(e => !e.IsConverted)
                     .Sum(e => e.TotalAmount);

        // ================= UI STATE =================
        public bool HasEstimates => Estimates.Count > 0;

        // ================= HELPERS =================
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public EstimatesViewModel()
        {
            // EMPTY by default → Empty state shows
            // Later you’ll load data here
        }
    }
}
