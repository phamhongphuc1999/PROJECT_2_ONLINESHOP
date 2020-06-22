using System.Web.Mvc;
using ManagementStore.Common;
using MODELS.EF;
using MODELS.Dao;
using ManagementStore.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace ManagementStore.Controllers
{
    public class InvoiceController : Controller
    {
        private InvoiceDao invoiceDao = new InvoiceDao();
        private DetailDao detailDao = new DetailDao();

        public ActionResult Index(Search search)
        {
            List<Invoice> invoiceList = new List<Invoice>();
            bool a1 = (search.start == DateTime.MinValue);
            bool a2 = (search.end == DateTime.MinValue);
            if (a1 && a2) invoiceList = invoiceDao.invoiceList;
            else invoiceList = invoiceDao.FilterByDaySell(search.start, search.end);
            List<InvoiceModel> invoiceModels = new List<InvoiceModel>();
            foreach (Invoice item in invoiceList)
            {
                if (item.Status)
                {
                    invoiceModels.Add(new InvoiceModel()
                    {
                        ID = item.Id,
                        EmployeeName = invoiceDao.DB.Employees.Find(item.IdEmployee).Name,
                        CustomerName = invoiceDao.DB.Customers.Find(item.IdCustomer).Name,
                        DaySell = item.DaySell
                    });
                }
            }
            var user = (UserLogin)Session[CommonConstants.USER_SEESION];
            ViewBag.UserName = user.Name;
            ViewBag.InvoiceModels = invoiceModels;
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
