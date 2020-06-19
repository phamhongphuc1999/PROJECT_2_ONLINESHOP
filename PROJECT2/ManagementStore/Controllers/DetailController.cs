using System;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using MODELS.EF;
using MODELS.Dao;
using ManagementStore.Models;

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
