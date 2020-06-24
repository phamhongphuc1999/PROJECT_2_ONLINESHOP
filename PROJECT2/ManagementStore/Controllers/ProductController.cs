﻿using System.Web.Mvc;
using MODELS.EF;
using MODELS.Dao;
using System.Linq;
using System;
using ManagementStore.Filter;

namespace ManagementStore.Controllers
{
    public class ProductController : Controller
    {
        private ProductDao productDao = new ProductDao();
        private ProductSearch productSearch = new ProductSearch();

        public ActionResult Index(string NameSearch = "", string AmountLow = "", string AmountUp = "", string PriceLow = "",
            string PriceUp = "", string ProfixLow = "", string ProfixUp = "", string SaleLow = "", string SaleUp = "",
            string GuaranteeLow = "", string GuaranteeUp = "")
        {
            string check = NameSearch + AmountLow + AmountUp + PriceLow + PriceUp + ProfixLow + ProfixUp + SaleLow +
                SaleUp + GuaranteeLow + GuaranteeUp;
            if (check != "")
            {
                if (NameSearch != "")
                {
                    productSearch.productList = productSearch.productList.Where(x => x.NameProduct.Contains(NameSearch)).ToList();
                    productSearch.NameSearch = NameSearch;
                }
                if (AmountUp != "" && AmountLow != "")
                {
                    int intUp = 0, intLow = 0;
                    bool check1 = Int32.TryParse(AmountLow, out intLow);
                    bool check2 = Int32.TryParse(AmountUp, out intUp);
                    if (check1 && check2)
                    {
                        productSearch.productList = productSearch.productList.Where(x => x.Amount >= intLow && x.Amount <= intUp).ToList();
                        productSearch.AmountLow = AmountLow;
                        productSearch.AmountUp = AmountUp;
                    }
                }
                if (PriceLow != "" && PriceUp != "")
                {
                    int intUp = 0, intLow = 0;
                    bool check1 = Int32.TryParse(PriceLow, out intLow);
                    bool check2 = Int32.TryParse(PriceUp, out intUp);
                    if (check1 && check2)
                    {
                        productSearch.productList = productSearch.productList.Where(x => x.ExportPrice >= intLow && x.ExportPrice <= intUp).ToList();
                        productSearch.PriceLow = PriceLow;
                        productSearch.PriceUp = PriceUp;
                    }
                }
                if (ProfixLow != "" && ProfixUp != "")
                {
                    int intUp = 0, intLow = 0;
                    bool check1 = Int32.TryParse(ProfixLow, out intLow);
                    bool check2 = Int32.TryParse(ProfixUp, out intUp);
                    if (check1 && check2)
                    {
                        productSearch.productList = productSearch.productList.Where(x => x.Profix >= intLow && x.Profix <= intUp).ToList();
                        productSearch.ProfixLow = ProfixLow;
                        productSearch.ProfixUp = ProfixUp;
                    }
                }
                if (SaleLow != "" && SaleUp != "")
                {
                    int intUp = 0, intLow = 0;
                    bool check1 = Int32.TryParse(SaleLow, out intLow);
                    bool check2 = Int32.TryParse(SaleUp, out intUp);
                    if (check1 && check2)
                    {
                        productSearch.productList = productSearch.productList.Where(x => x.Sale >= intLow && x.Sale <= intUp).ToList();
                        productSearch.SaleLow = SaleLow;
                        productSearch.SaleUp = SaleUp;
                    }
                }
                if (GuaranteeLow != "" && GuaranteeUp != "")
                {
                    int intUp = 0, intLow = 0;
                    bool check1 = Int32.TryParse(GuaranteeLow, out intLow);
                    bool check2 = Int32.TryParse(GuaranteeUp, out intUp);
                    if (check1 && check2)
                    {
                        productSearch.productList = productSearch.productList.Where(x => x.Guarantee >= intLow && x.Guarantee <= intUp).ToList();
                        productSearch.GuaranteeLow = GuaranteeLow;
                        productSearch.GuaranteeUp = GuaranteeUp;
                    }
                }
            }
            else
            {
                productSearch.productList = productDao.productList;
                productSearch.CleanSearch();
            }
            ViewBag.SEARCH = productSearch;
            return View(productSearch.productList);
        }

        public ActionResult Details(int id)
        {
            Product product = productDao.GetByID(id);
            if (product == null) return HttpNotFound();
            ViewBag.ID = id;
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

        public ActionResult Edit(int id)
        {
            Product product = productDao.GetByID(id);
            if (product == null) return HttpNotFound();
            ViewBag.ID = id;
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

        public ActionResult Delete(int id)
        {
            Product product = productDao.GetByID(id);
            if (product == null) return HttpNotFound();
            ViewBag.ID = id;
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            productDao.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) productDao.Dispose();
            base.Dispose(disposing);
        }
    }
}
