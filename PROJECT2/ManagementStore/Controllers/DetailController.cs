using System.Web.Mvc;
using MODELS.Dao;

namespace ManagementStore.Controllers
{
    public class DetailController : Controller
    {
        DetailDao detailDao = new DetailDao();

        protected override void Dispose(bool disposing)
        {
            if (disposing) detailDao.Dispose();
            base.Dispose(disposing);
        }
    }
}
