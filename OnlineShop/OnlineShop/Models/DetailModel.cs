using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class DetailModel
    {
        public string ID { get; set; }

        public int IdInvoice { get; set; }

        public int Amount { get; set; }

        public DateTime? DaySell { get; set; }
    }
}