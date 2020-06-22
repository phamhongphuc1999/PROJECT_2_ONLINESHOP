using System.Net;
using System.Web.Mvc;
using MODELS.EF;
using MODELS.Dao;

namespace ManagementStore.Controllers
{
    public class ProductController : Controller
    {
        private ProductDao productDao = new ProductDao();

        public ActionResult Index()
        {
            return View(productDao.productList);
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
