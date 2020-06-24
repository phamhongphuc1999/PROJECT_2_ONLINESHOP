using System.Collections.Generic;
using MODELS.EF;

namespace ManagementStore.Models
{
    public class InvoiceDetailModel
    {
        public Invoice invoice { get; set; }

        public List<KeyValuePair<int, Product>> productList { get; set; }

        public long money { get; set; }

        public Employee employee { get; set; }

        public Customer customer { get; set; }
    }
}