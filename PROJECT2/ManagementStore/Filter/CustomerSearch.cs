using MODELS.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagementStore.Filter
{
    public class CustomerSearch
    {
        public string NameSearch { get; set; }
        public string SexSearch { get; set; }
        public string PhoneSearch { get; set; }
        public string BirthdaySearch { get; set; }
        public string AddressSearch { get; set; }
        public string TypeSearch { get; set; }
        public List<Customer> customerList { get; set; }

        public void CleanSearch()
        {
            NameSearch = "";
            SexSearch = "";
            PhoneSearch = "";
            BirthdaySearch = "";
            AddressSearch = "";
            TypeSearch = "";
        }
    }
}