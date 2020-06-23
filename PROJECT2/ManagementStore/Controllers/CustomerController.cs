using System.Web.Mvc;
using ManagementStore.Common;
using System.Collections.Generic;
using MODELS.EF;
using MODELS.Dao;
using System.Linq;

namespace ManagementStore.Controllers
{
    public class CustomerController : Controller
    {
        private CustomerDao customerDao = new CustomerDao();
        private static List<Customer> customers;

        public ActionResult Index(string NameSearch = "", string SexSearch = "", string PhoneSearch = "",
            string BirthdaySearch = "", string AddressSearch = "", string TypeSearch = "")
        {
            var user = (UserLogin)Session[CommonConstants.USER_SEESION];
            string check = NameSearch + SexSearch + PhoneSearch + BirthdaySearch + AddressSearch + TypeSearch;
            if (check != "")
            {
                if (NameSearch != "") customers = customers.Where(x => x.Name.Contains(NameSearch)).ToList();
                if (SexSearch != "") customers = customers.Where(x => x.Sex == SexSearch).ToList();
                if (PhoneSearch != "") customers = customers.Where(x => x.Phone == PhoneSearch).ToList();
                if (BirthdaySearch != "") customers = customers.Where(x => x.Birthday.Value.ToString("0:dd/MM/yyyy") == BirthdaySearch).ToList();
                if (AddressSearch != "") customers = customers.Where(x => x.Address.Contains(AddressSearch)).ToList();
                if (TypeSearch != "") customers = customers.Where(x => x.Type == TypeSearch).ToList();
            }
            else customers = customerDao.customerList;
            ViewBag.UserName = user.Name;
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            Customer customer = customerDao.GetByID(id);
            if (customer == null) return HttpNotFound();
            ViewBag.ID = id;
            return View(customer);
        }

        public ActionResult Create()
        {
            var user = (UserLogin)Session[CommonConstants.USER_SEESION];
            ViewBag.UserName = user.Name;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Address,Phone,Type")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                bool check = customerDao.Add(customer);
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        public ActionResult Edit(int id)
        {
            Customer customer = customerDao.GetByID(id);
            if (customer == null) return HttpNotFound();
            ViewBag.ID = id;
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Sex,Birthday,Address,Phone,Type")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                bool check = customerDao.Edit(customer);
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        public ActionResult Delete(int id)
        {
            Customer customer = customerDao.GetByID(id);
            if (customer == null) return HttpNotFound();
            ViewBag.ID = id;
            return View(customer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            customerDao.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) customerDao.Dispose();
            base.Dispose(disposing);
        }
    }
}
