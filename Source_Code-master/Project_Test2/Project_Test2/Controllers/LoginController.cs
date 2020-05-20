using Project_Test2.Areas.Admin.Models;
using Project_Test2.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Test2.Models;

namespace Project_Test2.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
           
            return View();
        }
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(model.UserName, model.Password);
                if (result)
                {
                    var user = dao.GetByID(model.UserName);
                    var userSeesion = new UserLogin();
                    userSeesion.UserName = user.USERNAME;
                    userSeesion.UserID = user.MANV;
                    userSeesion.Name = user.HOTEN;
                    userSeesion.TypeNV = user.TYPENV;

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