using System.Web.Mvc;
using MODELS.EF;
using MODELS.Dao;
using ManagementStore.Models;
using System.Collections.Generic;
using System.Linq;
using ManagementStore.Filter;

namespace ManagementStore.Controllers
{
    public class InvoiceController : Controller
    {
        private InvoiceDao invoiceDao = new InvoiceDao();
        private DetailDao detailDao = new DetailDao();
        private static InvoiceSearch invoiceSearch = new InvoiceSearch();

        public ActionResult Index(Search search, string CustomerName = "", string EmployeeName = "")
        {
            string check = CustomerName + EmployeeName;
            if(check != "" || invoiceSearch.IsInvalidSearch(search))
            {
                if (invoiceSearch.IsInvalidSearch(search))
                {
                    invoiceSearch.invoiceList = invoiceSearch.invoiceList.Where(x => x.DaySell >= search.start && x.DaySell <= search.end).ToList();
                    invoiceSearch.search = search;
                }
                if (CustomerName != "")
                {
                    invoiceSearch.invoiceList = invoiceSearch.invoiceList.Where(x => x.CustomerName.Contains(CustomerName)).ToList();
                    invoiceSearch.CustomerName = CustomerName;
                }  
                if (EmployeeName != "")
                {
                    invoiceSearch.invoiceList = invoiceSearch.invoiceList.Where(x => x.EmployeeName.Contains(EmployeeName)).ToList();
                    invoiceSearch.EmployeeName = EmployeeName;
                }   
            }
            else
            {
                invoiceSearch.invoiceList = invoiceSearch.CreateInvoiceList();
                invoiceSearch.CleanSearch();
            }
            ViewBag.SEARCH = invoiceSearch;
            return View();
        }

        public ActionResult Details(int id)
        {
            InvoiceDetailModel invoiceDetailModel = new InvoiceDetailModel();
            invoiceDetailModel.invoice = invoiceDao.GetByID(id);
            if (invoiceDetailModel.invoice == null) return HttpNotFound();
            invoiceDetailModel.productList = new List<KeyValuePair<int, Product>>();
            invoiceDetailModel.customer = invoiceDao.DB.Customers.Find(invoiceDetailModel.invoice.IdCustomer);
            invoiceDetailModel.employee = invoiceDao.DB.Employees.Find(invoiceDetailModel.invoice.IdEmployee);
            List<Detail> detailList = invoiceDao.DB.Details.Where(x => x.IdInvoice == id).ToList();
            foreach (Detail item in detailList)
            {
                Product temp = invoiceDao.DB.Products.Find(item.IdProduct);
                invoiceDetailModel.productList.Add(new KeyValuePair<int, Product>(item.Amount, temp));
            }
            invoiceDetailModel.money = 0;
            foreach(KeyValuePair<int, Product> item in invoiceDetailModel.productList)
            {
                invoiceDetailModel.money += item.Key * item.Value.ExportPrice * (100 - item.Value.Sale) / 100;
            }
            ViewBag.ID = id;
            return View(invoiceDetailModel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            InvoiceDetailModel invoiceDetailModel = new InvoiceDetailModel();
            invoiceDetailModel.invoice = invoiceDao.GetByID(id);
            if (invoiceDetailModel.invoice == null) return HttpNotFound();
            invoiceDetailModel.productList = new List<KeyValuePair<int, Product>>();
            invoiceDetailModel.customer = invoiceDao.DB.Customers.Find(invoiceDetailModel.invoice.IdCustomer);
            invoiceDetailModel.employee = invoiceDao.DB.Employees.Find(invoiceDetailModel.invoice.IdEmployee);
            List<Detail> detailList = invoiceDao.DB.Details.Where(x => x.IdInvoice == id).ToList();
            foreach (Detail item in detailList)
            {
                Product temp = invoiceDao.DB.Products.Find(item.IdProduct);
                invoiceDetailModel.productList.Add(new KeyValuePair<int, Product>(item.Amount, temp));
            }
            ViewBag.ID = id;
            return View(invoiceDetailModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) invoiceDao.Dispose();
            base.Dispose(disposing);
        }
    }
}
