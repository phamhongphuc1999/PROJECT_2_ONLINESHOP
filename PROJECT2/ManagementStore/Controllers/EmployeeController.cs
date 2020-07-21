using System.Web.Mvc;
using MODELS.Dao;
using MODELS.EF;
using ManagementStore.Common;
using ManagementStore.Models;
using System.Linq;
using ManagementStore.Filter;

namespace ManagementStore.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeDao employeeDao = new EmployeeDao();
        private static string oldPassword = "";
        private static EmployeeSearch employeeSearch = new EmployeeSearch();

        public ActionResult Index(string NameSearch = "", string SexSearch = "", string PhoneSearch = "", 
            string BirthdaySearch = "", string AddressSearch = "", string PositionSearch = "")
        {
            var user = (UserLogin)Session[CommonConstants.USER_SEESION];
            string check = NameSearch + SexSearch + PhoneSearch + BirthdaySearch + AddressSearch + PositionSearch;
            if (check != "")
            {
                if (NameSearch != "")
                {
                    employeeSearch.employeeList = employeeSearch.employeeList.Where(x => x.Name.Contains(NameSearch)).ToList();
                    employeeSearch.NameSearch = NameSearch;
                }
                if (SexSearch != "")
                {
                    employeeSearch.employeeList = employeeSearch.employeeList.Where(x => x.Sex == SexSearch).ToList();
                    employeeSearch.SexSearch = SexSearch;
                }
                if (PhoneSearch != "")
                {
                    employeeSearch.employeeList = employeeSearch.employeeList.Where(x => x.Phone == PhoneSearch).ToList();
                    employeeSearch.PhoneSearch = PhoneSearch;
                }
                if (BirthdaySearch != "")
                {
                    employeeSearch.employeeList = employeeSearch.employeeList.Where(x => x.Birthday.Value.ToString("dd/MM/yyyy") == BirthdaySearch).ToList();
                    employeeSearch.BirthdaySearch = BirthdaySearch;
                }
                if (AddressSearch != "")
                {
                    employeeSearch.employeeList = employeeSearch.employeeList.Where(x => x.Address.Contains(AddressSearch)).ToList();
                    employeeSearch.AddressSearch = AddressSearch;
                }
                if (PositionSearch != "")
                {
                    employeeSearch.employeeList = employeeSearch.employeeList.Where(x => x.Position.Contains(PositionSearch)).ToList();
                    employeeSearch.PositionSearch = PositionSearch;
                }
            }
            else
            {
                employeeSearch.employeeList = employeeDao.employeeList;
                employeeSearch.CleanSearch();
            }
            ViewBag.UserName = user.Name;
            ViewBag.SEARCH = employeeSearch;
            return View(employeeSearch.employeeList);
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
        public ActionResult Create(Employee employee)
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
        public ActionResult Edit(EmployeeModel entity)
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
                if (check)
                {
                    UserLogin user = ((UserLogin)Session[CommonConstants.USER_SEESION]);
                    user.UserID = entity.ID;
                    user.Username = entity.UserName;
                    user.Password = entity.NewPassword;
                    Session[CommonConstants.USER_SEESION] = user;
                    return RedirectToAction("Details");
                }
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