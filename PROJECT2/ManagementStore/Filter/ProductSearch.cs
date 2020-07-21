using MODELS.EF;
using System.Collections.Generic;

namespace ManagementStore.Filter
{
    public class ProductSearch
    {
        public string NameSearch { get; set; }
        public string AmountUp { get; set; }
        public string AmountLow { get; set; }
        public string PriceUp { get; set; }
        public string PriceLow { get; set; }
        public string ProfixUp { get; set; }
        public string ProfixLow { get; set; }
        public string SaleUp { get; set; }
        public string SaleLow { get; set; }
        public string GuaranteeUp { get; set; }
        public string GuaranteeLow { get; set; }
        public List<Product> productList { get; set; }

        public void CleanSearch()
        {
            NameSearch = "";
            AmountUp = AmountLow = "";
            PriceLow = PriceUp = "";
            ProfixLow = ProfixUp = "";
            SaleLow = SaleUp = "";
            GuaranteeLow = GuaranteeUp = "";
        }
    }
}