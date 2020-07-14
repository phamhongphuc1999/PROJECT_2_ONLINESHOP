using System.Web.Mvc;
using ManagementStore.Common;
using MODELS.EF;
using MODELS.Dao;
using System.Linq;
using ManagementStore.Filter;

namespace ManagementStore.Controllers
{
    public class CustomerController : Controller
    {
        private CustomerDao customerDao = new CustomerDao();
        private static CustomerSearch customerSearch = new CustomerSearch();

        public ActionResult Index(string NameSearch = "", string SexSearch = "", string PhoneSearch = "",
            string BirthdaySearch = "", string AddressSearch = "", string TypeSearch = "")
        {
            var user = (UserLogin)Session[CommonConstants.USER_SEESION];
            string check = NameSearch + SexSearch + PhoneSearch + BirthdaySearch + AddressSearch + TypeSearch;
            if (check != "")
            {
                if (NameSearch != "")
                {
                    customerSearch.customerList = customerSearch.customerList.Where(x => x.Name.Contains(NameSearch)).ToList();
                    customerSearch.NameSearch = NameSearch;
                }
                if (SexSearch != "")
                {
                    customerSearch.customerList = customerSearch.customerList.Where(x => x.Sex == SexSearch).ToList();
                    customerSearch.SexSearch = SexSearch;
                }
                if (PhoneSearch != "")
                {
                    customerSearch.customerList = customerSearch.customerList.Where(x => x.Phone == PhoneSearch).ToList();
                    customerSearch.PhoneSearch = PhoneSearch;
                }
                if (BirthdaySearch != "")
                {
                    customerSearch.customerList = customerSearch.customerList.Where(x => x.Birthday.Value.ToString("0:dd/MM/yyyy") == BirthdaySearch).ToList();
                    customerSearch.BirthdaySearch = BirthdaySearch;
                }
                if (AddressSearch != "")
                {
                    customerSearch.customerList = customerSearch.customerList.Where(x => x.Address.Contains(AddressSearch)).ToList();
                    customerSearch.AddressSearch = AddressSearch;
                }
                if (TypeSearch != "")
                {
                    customerSearch.customerList = customerSearch.customerList.Where(x => x.Type == TypeSearch).ToList();
                    customerSearch.TypeSearch = TypeSearch;
                }
            }
            else
            {
                customerSearch.customerList = customerDao.customerList;
                customerSearch.CleanSearch();
            }
            ViewBag.UserName = user.Name;
            ViewBag.SEARCH = customerSearch;
            return View(customerSearch.customerList);
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
        public ActionResult Edit(Customer customer)
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
