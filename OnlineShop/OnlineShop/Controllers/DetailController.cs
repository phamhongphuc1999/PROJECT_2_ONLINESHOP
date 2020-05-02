using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MODELS.EF;

namespace OnlineShop.Controllers
{
    public class DetailController : Controller
    {
        private DatabaseOnlineShop db = new DatabaseOnlineShop();

        public ActionResult Index(int? id)
        {
            ViewBag.Model = db.Details.Where(x => x.IdInvoice == id);
            ViewBag.MASP = new SelectList(db.Products, "Id", "NameProduct");
            ViewBag.MAHD = id;
            return View();
        }

        public ActionResult IndexADD(int? id, int flag)
        {
            ViewBag.Model = db.Details.Where(x => x.IdInvoice == id);
            ViewBag.MASP = db.Products;
            ViewBag.MAHD = id;
            ViewBag.Flag = flag;
            return View();
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Detail detail = db.Details.Find(id);
            if (detail == null) return HttpNotFound();
            return View(detail);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdInvoice,Amount,IdProduct,NameProduct,ImportPrice,ExportPrice,Money,DaySell")] Detail detail)
        {
            Product product = db.Products.Find(detail.IdProduct);
            detail.ImportPrice = product.ImportPrice;
            detail.ExportPrice = product.ImportPrice * product.Profix / 100;
            detail.Money = detail.ExportPrice * detail.Amount;
            detail.NameProduct = product.NameProduct;
            db.Details.Add(detail);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = detail.IdInvoice });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CREATEADD([Bind(Include = "Id,IdInvoice,Amount,IdProduct,NameProduct,ImportPrice,ExportPrice,Money,DaySell")] Detail detail)
        {
            detail.IdPackage = detail.IdProduct.Substring(6);
            detail.IdProduct = detail.IdProduct.Substring(0, 6);
            var listProduct = db.Products.Where(x => (x.Id == detail.IdProduct) && (x.IdPackage == detail.IdPackage));
            Product product = listProduct.FirstOrDefault();

            if (product.Amount < detail.Amount)
            {
                int flag = 0;
                return RedirectToAction("IndexADD", new { id = detail.IdInvoice, flag });
            }
            else
            {
                Invoice invoice = db.Invoices.Find(detail.IdInvoice);
                detail.DaySell = invoice.DaySell;
                detail.ImportPrice = product.ImportPrice;
                detail.ExportPrice = (((product.ImportPrice * (product.Profix + 100)) / 100) * ((100 - product.Sale))) / 100;
                detail.Money = detail.ExportPrice * detail.Amount;
                detail.NameProduct = product.NameProduct;
                product.Amount = product.Amount - detail.Amount;
                db.Details.Add(detail);
                db.SaveChanges();
                int flag = 1;
                return RedirectToAction("IndexADD", new { id = detail.IdInvoice, flag });
            }
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Detail detail = db.Details.Find(id);
            if (detail == null) return HttpNotFound();
            return View(detail);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdInvoice,Amount,IdProduct,NameProduct,ImportPrice,ExportPrice,Money,DaySell")] Detail detail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = detail.IdInvoice });
            }
            return View(detail);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Detail detail = db.Details.Find(id);
            if (detail == null) return HttpNotFound();
            return View(detail);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Detail detail = db.Details.Find(id);
            db.Details.Remove(detail);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = detail.IdInvoice });
        }

        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search1([Bind(Include = "start,end")] Search search)
        {
            var data = db.Details.Where(x => (x.DaySell >= search.start) && (x.DaySell <= search.end));
            var data1 = data.GroupBy(x => x.NameProduct)
                .Select(g => new Statistic
                {
                    NameProduct = g.Key,
                    Amount = g.Sum(y => y.Amount)
                }
            );
            ViewBag.Model = data1;
            ViewBag.Start = search.start;
            ViewBag.End = search.end;
            return View();
        }

        public ActionResult SearchItem()
        {
            var data = db.Products;
            ViewBag.MASP = data.Select(g => g.NameProduct).Distinct();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SearchItem_(DateTime start, DateTime end, string TENSP)
        {
            var data = db.Details.Where(x => (x.DaySell >= start) && (x.DaySell <= end) && (x.NameProduct == TENSP));
            ViewBag.Model = data;
            ViewBag.Start = start;
            ViewBag.End = end;
            ViewBag.Pro = TENSP;
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) db.Dispose();
            base.Dispose(disposing);
        }
    }
}
