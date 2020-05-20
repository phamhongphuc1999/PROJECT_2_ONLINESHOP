using System;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using MODELS.EF;
using MODELS.Dao;

namespace OnlineShop.Controllers
{
    public class DetailController : Controller
    {
        private DetailDao detailDao = new DetailDao();

        public ActionResult Index(int id)
        {
            ViewBag.Model = detailDao.ListDetail(id);
            ViewBag.MASP = new SelectList(detailDao.DB.Products, "Id", "NameProduct");
            ViewBag.MAHD = id;
            return View();
        }

        public ActionResult IndexADD(int id, int flag)
        {
            ViewBag.Model = detailDao.ListDetail(id);
            ViewBag.MASP = detailDao.DB.Products;
            ViewBag.MAHD = id;
            ViewBag.Flag = flag;
            return View();
        }

        public ActionResult Details(int id)
        {
            Detail detail = detailDao.GetByID(id);
            if (detail == null) return HttpNotFound();
            return View(detail);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdInvoice,Amount,IdProduct,NameProduct,ImportPrice,ExportPrice,Money,DaySell")] Detail detail)
        {
            detailDao.AddByProduct(detail);
            return RedirectToAction("Index", new { id = detail.IdInvoice });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CREATEADD([Bind(Include = "Id,IdInvoice,Amount,IdProduct,NameProduct,ImportPrice,ExportPrice,Money,DaySell")] Detail detail)
        {
            detail.IdPackage = detail.IdProduct.Substring(6);
            detail.IdProduct = detail.IdProduct.Substring(0, 6);
            var listProduct = detailDao.ListProduct(detail.IdProduct, detail.IdPackage);
            Product product = listProduct.FirstOrDefault();

            if (product.Amount < detail.Amount)
            {
                int flag = 0;
                return RedirectToAction("IndexADD", new { id = detail.IdInvoice, flag });
            }
            else
            {
                detailDao.AddByInvoice(detail, product);
                int flag = 1;
                return RedirectToAction("IndexADD", new { id = detail.IdInvoice, flag });
            }
        }

        public ActionResult Edit(int id)
        {
            Detail detail = detailDao.GetByID(id);
            if (detail == null) return HttpNotFound();
            return View(detail);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdInvoice,Amount,IdProduct,NameProduct,ImportPrice,ExportPrice,Money,DaySell")] Detail detail)
        {
            if (ModelState.IsValid)
            {
                detailDao.Edit(detail);
                return RedirectToAction("Index", new { id = detail.IdInvoice });
            }
            return View(detail);
        }

        public ActionResult Delete(int id)
        {
            Detail detail = detailDao.GetByID(id);
            if (detail == null) return HttpNotFound();
            return View(detail);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Detail detail = detailDao.Delete(id);
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
            var data = detailDao.FilterByDaySell(search.start, search.end);
            var data1 = data.GroupBy(x => x.NameProduct).Select(g => new Statistic
            {
                NameProduct = g.Key,
                Amount = g.Sum(y => y.Amount)
            });

            ViewBag.Model = data1;
            ViewBag.Start = search.start;
            ViewBag.End = search.end;
            return View();
        }

        public ActionResult SearchItem()
        {
            var data = detailDao.DB.Products;
            ViewBag.MASP = data.Select(g => g.NameProduct).Distinct();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SearchItem_(DateTime start, DateTime end, string nameProduct)
        {
            var data = detailDao.FilterByDaySell(start, end, nameProduct);
            ViewBag.Model = data;
            ViewBag.Start = start;
            ViewBag.End = end;
            ViewBag.Pro = nameProduct;
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) detailDao.Dispose();
            base.Dispose(disposing);
        }
    }
}
