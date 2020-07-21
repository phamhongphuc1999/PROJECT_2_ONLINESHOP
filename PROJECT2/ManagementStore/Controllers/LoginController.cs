using System.Web.Mvc;
using ManagementStore.Models;
using MODELS.Dao;
using ManagementStore.Common;

namespace ManagementStore.Controllers
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
                var result = dao.Login(model.UserName, Cryptography_MD5.GetHash(model.Password));
                if (result)
                {
                    var user = dao.GetByName(model.UserName, true);
                    var userSeesion = new UserLogin();
                    userSeesion.Username = user.Username;
                    userSeesion.Password = user.Password;
                    userSeesion.Image = user.Image;
                    userSeesion.UserID = user.Id;
                    userSeesion.Name = user.Name;
                    userSeesion.TypeEmployee = user.Position;

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