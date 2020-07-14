using System.Web.Mvc;
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
        private static ProductSearch productSearch = new ProductSearch();

        public ActionResult Index(string NameSearch = "", string AmountLow = "", string AmountUp = "", string PriceLow = "",
            string PriceUp = "", string ProfixLow = "", string ProfixUp = "", string SaleLow = "", string SaleUp = "",
            string GuaranteeLow = "", string GuaranteeUp = "")
        {
            string check = NameSearch + AmountLow + AmountUp + PriceLow + PriceUp + ProfixLow + ProfixUp + SaleLow +
                SaleUp + GuaranteeLow + GuaranteeUp;
            if (check != "")
            {
                int intUp = 0, intLow = 0;
                if (NameSearch != "")
                {
                    productSearch.productList = productSearch.productList.Where(x => x.NameProduct.Contains(NameSearch)).ToList();
                    productSearch.NameSearch = NameSearch;
                }
                if (AmountUp != "" && AmountLow != "")
                {
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
        
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                product.Image = "/dist/img/product/p1.jpg";
                product.Status = "new";
                productDao.Insert(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Product product = productDao.GetByID(id);
            if (product == null) return HttpNotFound();
            ViewBag.ID = id;
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit( Product product)
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
