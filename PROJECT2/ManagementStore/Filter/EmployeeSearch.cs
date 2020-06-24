using MODELS.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagementStore.Filter
{
    public class EmployeeSearch
    {
        public string NameSearch { get; set; }
        public string SexSearch { get; set; }
        public string PhoneSearch { get; set; }
        public string BirthdaySearch { get; set; }
        public string AddressSearch { get; set; }
        public string PositionSearch { get; set; }
        public List<Employee> employeeList { get; set; }

        public void CleanSearch()
        {
            NameSearch = "";
            SexSearch = "";
            PhoneSearch = "";
            BirthdaySearch = "";
            AddressSearch = "";
            PositionSearch = "";
        }
    }
}