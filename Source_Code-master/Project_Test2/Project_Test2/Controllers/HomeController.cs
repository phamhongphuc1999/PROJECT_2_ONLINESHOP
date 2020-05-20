using Project_Test2.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_Test2.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
           
           var user = (UserLogin)Session[CommonConstants.USER_SEESION];
            if (user== null)
            {
                return RedirectToAction("Login", "Login");
            }
            ViewBag.UserName = user.Name;
            return View();
        }    
    }
}