using System.Web.Mvc;
using MODELS.Dao;
using MODELS.EF;
using ManagementStore.Common;
using ManagementStore.Models;

namespace ManagementStore.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeDao employeeDao = new EmployeeDao();
        private static string oldPassword = "";

        public ActionResult Index()
        {
            var user = (UserLogin)Session[CommonConstants.USER_SEESION];
            ViewBag.UserName = user.Name;
            return View(employeeDao.employeeList);
        }

        public ActionResult Details(int id)
        {
            var user = (UserLogin)Session[CommonConstants.USER_SEESION];
            Employee employee = employeeDao.GetByID(id);
            if (employee == null) return HttpNotFound();
            ViewBag.session = user.UserID;
            ViewBag.ID = id;
            return View(employee);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var user = (UserLogin)Session[CommonConstants.USER_SEESION];
            if (user.TypeEmployee == "manager")
            {
                ViewBag.UserName = user.Name;
                return View();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Sex,Phone,Birthday,Address,Username,Password,Type")] Employee employee)
        {
            employeeDao.Insert(employee);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Employee employee = employeeDao.GetByID(id);
            if (employee == null) return HttpNotFound();
            else
            {
                EmployeeModel employeeModel = new EmployeeModel()
                {
                    ID = employee.Id,
                    Name = employee.Name,
                    UserName = employee.Username,
                    Sex = employee.Sex,
                    Address = employee.Address,
                    Phone = employee.Phone,
                    Birthday = employee.Birthday
                };
                oldPassword = employee.Password;
                ViewBag.ID = id;
                return View(employeeModel);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Sex,Phone,Birthday,Address,Username,ComfirmOldPassword,NewPassword,ComfirmNewPassword")] EmployeeModel entity)
        {
            string comfirmOldPassword = Cryptography_MD5.GetHash(entity.ComfirmOldPassword);
            if (comfirmOldPassword == oldPassword && entity.NewPassword == entity.ComfirmNewPassword)
            {
                Employee employee = new Employee()
                {
                    Id = entity.ID,
                    Name = entity.Name,
                    Username = entity.UserName,
                    Password = Cryptography_MD5.GetHash(entity.NewPassword),
                    Sex = entity.Sex,
                    Address = entity.Address,
                    Phone = entity.Phone,
                    Birthday = entity.Birthday
                };
                bool check = employeeDao.Edit(employee);
                if (check) return RedirectToAction("Details");
            }
            return RedirectToAction("Edit");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Employee employee = employeeDao.GetByID(id);
            if (employee == null) return HttpNotFound();
            ViewBag.ID = id;
            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            bool check = employeeDao.Delete(id);
            if (check) return RedirectToAction("Index");
            else return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult IsAlreadyUsername(string Username)
        {
            return Json(IsUserAvailable(Username));
        }

        public bool IsUserAvailable(string username)
        {
            int result = employeeDao.CountUsername(username);
            return !(result > 0);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) employeeDao.Dispose();
            base.Dispose(disposing);
        }
    }
}