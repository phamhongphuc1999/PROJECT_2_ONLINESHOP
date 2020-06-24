using ManagementStore.Models;
using MODELS.Dao;
using MODELS.EF;
using System;
using System.Collections.Generic;

namespace ManagementStore.Filter
{
    public class InvoiceSearch
    {
        private InvoiceDao InvoiceDao = new InvoiceDao();
        public string CustomerName { get; set; }
        public string EmployeeName { get; set; }
        public Search search { get; set; }
        public List<InvoiceModel> invoiceList { get; set; }

        public bool IsInvalidSearch(Search search)
        {
            return (search.start != DateTime.MinValue) && (search.end != DateTime.MaxValue) && (search.start <= search.end);
        }

        public List<InvoiceModel> CreateInvoiceList()
        {
            List<Invoice> temp = InvoiceDao.invoiceList;
            List<InvoiceModel> result = new List<InvoiceModel>();
            foreach (Invoice invoice in temp)
            {
                result.Add(new InvoiceModel()
                {
                    ID = invoice.Id,
                    CustomerName = InvoiceDao.DB.Customers.Find(invoice.IdCustomer).Name,
                    EmployeeName = InvoiceDao.DB.Employees.Find(invoice.IdEmployee).Name,
                    DaySell = invoice.DaySell
                });
            }
            return result;
        }

        public void CleanSearch()
        {
            search = new Search();
            search.start = DateTime.MinValue;
            search.end = DateTime.MaxValue;
            CustomerName = "";
            EmployeeName = "";
        }
    }
}