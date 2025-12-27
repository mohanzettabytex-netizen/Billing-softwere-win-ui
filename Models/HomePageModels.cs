using System;
using System.Collections.Generic;

namespace App_3.Models
{
    // ================= DASHBOARD METRIC =================
    public class MetricModel
    {
        public string Title { get; set; }      // e.g. Total Customers
        public string Value { get; set; }      // e.g. 128
        public string Tooltip { get; set; }    // e.g. Monthly growth +10%
    }

    // ================= TOP SELLING ITEM =================
    public class TopItemModel
    {
        public string ItemName { get; set; }       // Product A
        public int QuantitySold { get; set; }      // 45
        public string RevenueFormatted { get; set; } // "₹4,500"
    }
    // ================= ALERT =================
    public class AlertModel
    {
        public string Type { get; set; }        // Payment / Stock / Reminder
        public string Message { get; set; }     // Alert text
        public string Timestamp { get; set; }   // "5 mins ago"
        public string AlertColor { get; set; }  // e.g., "#D1FAE5"
    }
}

