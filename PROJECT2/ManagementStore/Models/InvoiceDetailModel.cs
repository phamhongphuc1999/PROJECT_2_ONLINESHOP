using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MODELS.EF;

namespace ManagementStore.Models
{
    public class InvoiceDetailModel
    {
        public Invoice invoice { get; set; }

        public List<Product> productList { get; set; }

        public Employee employee { get; set; }

        public Customer customer { get; set; }
    }
}