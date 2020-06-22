using ManagementStore.Common;
using System.Web.Mvc;
using MODELS.Dao;
using MODELS.EF;
using System.Linq;
using System.Collections.Generic;
using System;

namespace ManagementStore.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var user = (UserLogin)Session[CommonConstants.USER_SEESION];
            if (user == null) return RedirectToAction("Login", "Login");
            List<Product> temp = new BaseDao().DB.Products.ToList();
            int countNew = 0, countHigh = 0;
            List<Product> productNew = new List<Product>();
            List<Product> productHighlight = new List<Product>();
            foreach(Product item in temp)
            {
                if (countNew == 7 && countHigh == 4) break;
                if (item.Status == "new") productNew.Add(item);
                else if (item.Status == "highlight") productHighlight.Add(item);
            }
            ViewBag.ProductNew = productNew;
            ViewBag.ProductHigh = productHighlight;
            return View();
        }
    }
}