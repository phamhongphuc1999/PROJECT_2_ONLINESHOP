using System.Web.Mvc;
using ManagementStore.Common;
using MODELS.EF;
using MODELS.Dao;
using ManagementStore.Models;
using System.Collections.Generic;

namespace ManagementStore.Controllers
{
    public class InvoiceController : Controller
    {
        private InvoiceDao invoiceDao = new InvoiceDao();

        public ActionResult Index()
        {
            List<Invoice> invoiceList = invoiceDao.invoiceList;
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
            return View(invoiceModels);
        }

        public ActionResult Details(int id)
        {
            Invoice invoice = invoiceDao.GetByID(id);
            if (invoice == null) return HttpNotFound();
            return View(invoice);
        }

        public ActionResult Create()
        {
            ViewBag.IdCustomer = new SelectList(invoiceDao.DB.Customers, "Id", "Name");
            ViewBag.IdEmployee = new SelectList(invoiceDao.DB.Employees, "Id", "Name");
            var user = (UserLogin)Session[CommonConstants.USER_SEESION];
            ViewBag.UserName = user.Name;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ADD([Bind(Include = "Id,IdEmployee,IdCustomer,DaySell")] Invoice invoice)
        {
            var user = (UserLogin)Session[CommonConstants.USER_SEESION];
            invoice.IdEmployee = user.UserID;
            invoice.DaySell = System.DateTime.Now;
            if (ModelState.IsValid)
            {
                invoiceDao.Add(invoice);
                DetailModel detailModel = new DetailModel()
                {
                    IdInvoice = invoice.Id,
                    DaySell = invoice.DaySell
                };
                ViewBag.MAHD = invoice.Id;
                ViewBag.NGAYBAN = invoice.DaySell;
                ViewBag.MASP = invoiceDao.DB.Products;
                ViewBag.Model = invoiceDao.ListDetail(invoice.Id);
                return View(detailModel);
            }
            ViewBag.MAKH = new SelectList(invoiceDao.DB.Customers, "Id", "Name", invoice.IdCustomer);
            ViewBag.MANV = new SelectList(invoiceDao.DB.Employees, "Id", "Name", invoice.IdEmployee);
            return View(invoice);
        }

        public ActionResult Edit(int id)
        {
            Invoice invoice = invoiceDao.GetByID(id);
            if (invoice == null) return HttpNotFound();
            ViewBag.MAKH = new SelectList(invoiceDao.DB.Customers, "Id", "Name", invoice.IdCustomer);
            ViewBag.MANV = new SelectList(invoiceDao.DB.Employees, "Id", "Name", invoice.IdEmployee);
            return View(invoice);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdEmployee,IdCustomer,DaySell")] Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                invoiceDao.Edit(invoice);
                return RedirectToAction("Index");
            }
            ViewBag.MAKH = new SelectList(invoiceDao.DB.Customers, "Id", "Name", invoice.IdCustomer);
            ViewBag.MANV = new SelectList(invoiceDao.DB.Employees, "Id", "Name", invoice.IdEmployee);
            return View(invoice);
        }

        public ActionResult Delete(int id)
        {
            Invoice invoice = invoiceDao.GetByID(id);
            if (invoice == null) return HttpNotFound();
            return View(invoice);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            invoiceDao.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) invoiceDao.Dispose();
            base.Dispose(disposing);
        }
    }
}
