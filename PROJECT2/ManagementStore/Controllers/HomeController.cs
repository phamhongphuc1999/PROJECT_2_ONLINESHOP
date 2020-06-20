using ManagementStore.Common;
using System.Web.Mvc;
using MODELS.Dao;
using MODELS.EF;
using System.Linq;
using System.Collections.Generic;

namespace ManagementStore.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var user = (UserLogin)Session[CommonConstants.USER_SEESION];
            if (user == null) return RedirectToAction("Login", "Login");
            List<Product> temp = new BaseDao().DB.Products.ToList();
            int count = 0;
            List<Product> productList = new List<Product>();
            foreach(Product item in temp)
            {
                productList.Add(item);
                if (count++ == 4) break;
            }
            ViewBag.ListProduct = productList;
            return View();
        }
    }
}