namespace App_3.Models
{
    public class ProformaInvoiceModel
    {
        public string Date { get; set; }
        public string EstimateNo { get; set; }
        public string PartyName { get; set; }
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
        public string Status { get; set; }
    }
}
