namespace App_3.Models
{
    public class EstimateModel
    {
        public string Date { get; set; }
        public string EstimateNo { get; set; }
        public string PartyName { get; set; }

        // Use decimal for money to match ViewModel expectations
        public decimal Amount { get; set; }

        // TotalAmount used by ViewModel; keep it in sync with Amount
        public decimal TotalAmount
        {
            get => Amount;
            set => Amount = value;
        }

        // Flag used by ViewModel to compute Converted/Open amounts
        public bool IsConverted { get; set; }

        public string Status { get; set; }
    }
}
