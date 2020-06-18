using ManagementStore.Common;
using System.Web.Mvc;

namespace ManagementStore.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var user = (UserLogin)Session[CommonConstants.USER_SEESION];
            if (user == null) return RedirectToAction("Login", "Login");
            ViewBag.UserName = user.Name;
            return View();
        }
    }
}