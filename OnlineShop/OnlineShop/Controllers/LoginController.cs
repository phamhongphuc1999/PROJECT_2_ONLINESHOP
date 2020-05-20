using System.Web.Mvc;
using OnlineShop.Models;
using MODELS.Dao;
using OnlineShop.Common;

namespace OnlineShop.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new EmployeeDao();
                var result = dao.Login(model.UserName, model.Password);
                if (result)
                {
                    var user = dao.GetByName(model.UserName, true);
                    var userSeesion = new UserLogin();
                    userSeesion.Username = user.Username;
                    userSeesion.UserID = user.Id;
                    userSeesion.Name = user.Name;
                    userSeesion.TypeEmployee = user.Type;

                    Session.Add(CommonConstants.USER_SEESION, userSeesion);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập không đúng");
                }
            }
            return View("Index");
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "Login");
        }
    }
}