using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MODELS.EF;
using MODELS.Dao;
using Microsoft.Ajax.Utilities;

namespace OnlineShop.Controllers
{
    public class ProductController : Controller
    {
        private ProductDao productDao = new ProductDao();
        
        public ActionResult Index()
        {
            return View(productDao.productList);
        }

        public ActionResult Details(string id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Product product = productDao.GetByID(id);
            if (product == null) return HttpNotFound();
            return View(product);
        }

        public ActionResult Create()
        {
            Product product = productDao.CreateNewProduct();
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NameProduct,IdPackage,ImportPrice,Profix,Amount,Guarantee,Sale")] Product product)
        {
            if (ModelState.IsValid)
            {
                productDao.Insert(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public ActionResult Edit(string id, string idPackage)
        {
            if (id == null || idPackage == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Product product = productDao.FindByIDAndPackage(id, idPackage);
            if (product == null) return HttpNotFound();
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NameProduct,IdPackage,ImportPrice,Profix,Amount,Guarantee,Sale")] Product product)
        {
            if (ModelState.IsValid)
            {
                productDao.Edit(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public ActionResult Delete(string id, string idPackage)
        {
            if (id == null || idPackage == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Product product = productDao.FindByIDAndPackage(id, idPackage);
            if (product == null) return HttpNotFound();
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id, string idPackage)
        {
            productDao.Delete(id, idPackage);
            return RedirectToAction("Index");
        }
        
        //public ActionResult ViewAddLot(string id)
        //{
        //    var product = new Product();
        //    product.Id = id;
        //    var listProduct = db.Products.Where(x => x.Id == id);
        //    var lastLot = listProduct.OrderByDescending(x => x.IdPackage).FirstOrDefault();
        //    product.NameProduct = lastLot.NameProduct;
        //    ViewBag.ProName = lastLot.NameProduct;
        //    if (lastLot == null) product.IdPackage = "L00001";
        //    else
        //    {
        //        product.IdPackage = "L" + (Convert.ToInt32(lastLot.IdPackage.Substring(1, lastLot.IdPackage.Length - 1)) + 1).ToString("D5");
        //    }
        //    return View(product);

        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProLot([Bind(Include = "Id,NameProduct,IdPackage,ImportPrice,Profix,Amount,Guarantee,Sale")] Product product)
        {
            if (ModelState.IsValid)
            {
                productDao.Insert(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) productDao.Dispose();
            base.Dispose(disposing);
        }
    }
}
