using System.Web.Mvc;
using ManagementStore.Common;
using System.Collections.Generic;
using MODELS.EF;
using MODELS.Dao;

namespace ManagementStore.Controllers
{
    public class CustomerController : Controller
    {
        private CustomerDao customerDao = new CustomerDao();

        public ActionResult Index(string stringSearch = "")
        {
            var user = (UserLogin)Session[CommonConstants.USER_SEESION];
            List<Customer> customerList = new List<Customer>();
            if (stringSearch == "") customerList = customerDao.customerList;
            else customerList = customerDao.SearchCustomer(stringSearch);
            ViewBag.UserName = user.Name;
            return View(customerList);
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
