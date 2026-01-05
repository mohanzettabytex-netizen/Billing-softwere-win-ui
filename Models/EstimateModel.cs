using System;

namespace App_3.Models
{
    public class EstimateModel
    {
        public string EstimateNo { get; set; }
        public DateTime Date { get; set; }

        public string PartyName { get; set; }

        public decimal TotalAmount { get; set; }

        // Status: Open / Converted / Cancelled (future)
        public string Status { get; set; }

        // If converted → link to Sale later
        public bool IsConverted { get; set; }
    }
}
