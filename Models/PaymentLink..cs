
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App_3.Models
{
    public enum LinkStatus
    {
        Active,
        Inactive,
        Expired
    }

    public class PaymentLink
    {
        public string Name { get; set; } = string.Empty;
        public string Link { get; set; } = string.Empty;
        public LinkStatus Status { get; set; } = LinkStatus.Active;
    }
}







