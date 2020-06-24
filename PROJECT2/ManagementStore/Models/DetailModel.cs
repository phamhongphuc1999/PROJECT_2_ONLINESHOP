using System;

namespace ManagementStore.Models
{
    public class DetailModel
    {
        public string ID { get; set; }

        public int IdInvoice { get; set; }

        public int Amount { get; set; }

        public DateTime? DaySell { get; set; }
    }
}