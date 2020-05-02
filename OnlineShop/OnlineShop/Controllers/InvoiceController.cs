using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Common;
using MODELS.EF;

namespace OnlineShop.Controllers
{
    public class InvoiceController : Controller
    {
        public DatabaseOnlineShop db = new DatabaseOnlineShop();

        public ActionResult Index()
        {
            var invoice = db.Invoices.Include(h => h.IdCustomer).Include(h => h.IdEmployee);
            var user = (UserLogin)Session[CommonConstants.USER_SEESION];
            ViewBag.UserName = user.Name;
            return View(invoice.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Invoice invoice = db.Invoices.Find(id);
            if (invoice == null) return HttpNotFound();
            return View(invoice);
        }

        public ActionResult Create()
        {
            ViewBag.MAKH = new SelectList(db.Customers, "Id", "Name");
            ViewBag.MANV = new SelectList(db.Employees, "Id", "Name");
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
            if (ModelState.IsValid)
            {
                db.Invoices.Add(invoice);
                db.SaveChanges();
                ViewBag.MAHD = invoice.Id;
                ViewBag.NGAYBAN = invoice.DaySell;
                ViewBag.MASP = db.Products;
                ViewBag.Model = db.Details.Where(x => x.IdInvoice == invoice.Id);
                return View();
            }
            ViewBag.MAKH = new SelectList(db.Customers, "Id", "Name", invoice.IdCustomer);
            ViewBag.MANV = new SelectList(db.Employees, "Id", "Name", invoice.IdEmployee);
            return View(invoice);
        }
       
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Invoice invoice = db.Invoices.Find(id);
            if (invoice == null) return HttpNotFound();
            ViewBag.MAKH = new SelectList(db.Customers, "Id", "Name", invoice.IdCustomer);
            ViewBag.MANV = new SelectList(db.Employees, "Id", "Name", invoice.IdEmployee);
            return View(invoice);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdEmployee,IdCustomer,DaySell")] Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(invoice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MAKH = new SelectList(db.Customers, "Id", "Name", invoice.IdCustomer);
            ViewBag.MANV = new SelectList(db.Employees, "Id", "Name", invoice.IdEmployee);
            return View(invoice);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Invoice invoice = db.Invoices.Find(id);
            if (invoice == null) return HttpNotFound();
            return View(invoice);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Invoice invoice = db.Invoices.Find(id);
            db.Invoices.Remove(invoice);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) db.Dispose();
            base.Dispose(disposing);
        }
    }
}
