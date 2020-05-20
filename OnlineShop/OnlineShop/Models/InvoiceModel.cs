using System;

namespace OnlineShop.Models
{
    public class InvoiceModel
    {
        public int ID { get; set; }

        public string EmployeeName { get; set; }

        public string CustomerName { get; set; }

        public DateTime? DaySell { get; set; }
    }
}