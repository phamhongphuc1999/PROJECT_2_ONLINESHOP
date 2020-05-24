using System.Net;
using System.Web.Mvc;
using MODELS.EF;
using MODELS.Dao;
using System.Linq;

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

        public ActionResult ViewAddLot(string id)
        {
            var product = new Product();
            product.Id = id;
            var productList = productDao.DB.Products.Where(x => x.Id == id);
            var productTemp = productList.FirstOrDefault();
            if (productTemp == null) product.IdPackage = "L00001";
            else
            {
                product.NameProduct = productTemp.NameProduct;
                ViewBag.ProName = productTemp.NameProduct;
                product.IdPackage = productTemp.IdPackage;
            }
            return View(product);
        }

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
