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
    public class ProductController : Controller
    {
        private DatabaseOnlineShop db = new DatabaseOnlineShop();
        
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }

        public ActionResult Details(string id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Product product = db.Products.Find(id);
            if (product == null) return HttpNotFound();
            return View(product);
        }

        public ActionResult Create()
        {
            Product product = new Product();
            var lastMaSP = db.Products.OrderByDescending(c => c.Id).FirstOrDefault();
            if (lastMaSP == null) product.Id = "S00001";
            else
            {
                //using string substring method to get the number of the last inserted employee's EmployeeID 
                product.Id = "S" + (Convert.ToInt32(lastMaSP.Id.Substring(1, lastMaSP.Id.Length - 1)) + 1).ToString("D5");
            }
            var listsp = db.Products.Where(x => x.Id == product.Id);
            var lastLot = listsp.OrderByDescending(x => x.IdPackage).FirstOrDefault();
            if (lastLot == null) product.IdPackage = "L00001";
            else
            {
                product.IdPackage = "L" + (Convert.ToInt32(lastLot.IdPackage.Substring(1, lastLot.IdPackage.Length - 1)) + 1).ToString("D5");
            }
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NameProduct,IdPackage,ImportPrice,Profix,Amount,Guarantee,Sale")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public ActionResult Edit(string id, string idPackage)
        {
            if (id == null || idPackage == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Product product = db.Products.Where(x => (x.Id == id) && (x.IdPackage == idPackage)).FirstOrDefault();
            if (product == null) return HttpNotFound();
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NameProduct,IdPackage,ImportPrice,Profix,Amount,Guarantee,Sale")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public ActionResult Delete(string id, string idPackage)
        {
            if (id == null || idPackage == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Product product = db.Products.Where(x => (x.Id == id) && (x.IdPackage == idPackage)).FirstOrDefault();
            if (product == null) return HttpNotFound();
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id, string idPackage)
        {
            Product product = db.Products.Where(x => (x.Id == id) && (x.IdPackage == idPackage)).FirstOrDefault();
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public ActionResult ViewAddLot(string id)
        {
            var product = new Product();
            product.Id = id;
            var listProduct = db.Products.Where(x => x.Id == id);
            var lastLot = listProduct.OrderByDescending(x => x.IdPackage).FirstOrDefault();
            product.NameProduct = lastLot.NameProduct;
            ViewBag.ProName = lastLot.NameProduct;
            if (lastLot == null) product.IdPackage = "L00001";
            else
            {
                product.IdPackage = "L" + (Convert.ToInt32(lastLot.IdPackage.Substring(1, lastLot.IdPackage.Length - 1)) + 1).ToString("D5");
            }
            return View(product);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProLot([Bind(Include = "Id,NameProduct,IdPackage,ImportPrice,Profix,Amount,Guarantee,Sale")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) db.Dispose();
            base.Dispose(disposing);
        }
    }
}
