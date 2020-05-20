using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project_Test2.Models;

namespace Project_Test1.Controllers
{
    public class SANPHAMsController : Controller
    {

        private Project_Test2Context db = new Project_Test2Context();
        // GET: SANPHAMs
        public ActionResult Index()
        {
            return View(db.SANPHAMs.ToList());
        }

        // GET: SANPHAMs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SANPHAM sANPHAM = db.SANPHAMs.Find(id);
            if (sANPHAM == null)
            {
                return HttpNotFound();
            }
            return View(sANPHAM);
        }

        // GET: SANPHAMs/Create
        public ActionResult Create()
        {
            SANPHAM product = new SANPHAM();
            var lastMaSP = db.SANPHAMs.OrderByDescending(c => c.MASP).FirstOrDefault();
            if (lastMaSP == null)
            {
                product.MASP = "S00001";

            }
            else
            {
                //using string substring method to get the number of the last inserted employee's EmployeeID 
                product.MASP = "S" + (Convert.ToInt32(lastMaSP.MASP.Substring(1, lastMaSP.MASP.Length - 1)) + 1).ToString("D5");
            }
            var listsp = db.SANPHAMs.Where(x => x.MASP == product.MASP);
            var lastLot = listsp.OrderByDescending(x => x.MALO).FirstOrDefault();
            if (lastLot == null)
            {
                product.MALO = "L00001";

            }
            else
            {
                product.MALO = "L" + (Convert.ToInt32(lastLot.MALO.Substring(1, lastLot.MALO.Length - 1)) + 1).ToString("D5");
            }


            return View(product);
        }

        // POST: SANPHAMs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MASP,TENSP,MALO,GIANHAP,LOINHUAN,SL,BAOHANH,Sale")] SANPHAM sANPHAM)
        {
            if (ModelState.IsValid)
            {
                db.SANPHAMs.Add(sANPHAM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sANPHAM);
        }

        // GET: SANPHAMs/Edit/5
        public ActionResult Edit(string MASP, string MALO)
        {
            if (MASP == null || MALO ==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SANPHAM sANPHAM = db.SANPHAMs.Where(x => (x.MASP == MASP) && (x.MALO==MALO)).FirstOrDefault();
            if (sANPHAM == null)
            {
                return HttpNotFound();
            }
            return View(sANPHAM);
        }

        // POST: SANPHAMs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MASP,TENSP,MALO,GIANHAP,LOINHUAN,SL,BAOHANH,Sale")] SANPHAM sANPHAM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sANPHAM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sANPHAM);
        }

        // GET: SANPHAMs/Delete/5
        public ActionResult Delete(string MASP, string MALO)
        {
            if (MASP == null || MALO==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SANPHAM sANPHAM = db.SANPHAMs.Where(x => (x.MASP == MASP) && (x.MALO == MALO)).FirstOrDefault();
            if (sANPHAM == null)
            {
                return HttpNotFound();
            }
            return View(sANPHAM);
        }

        // POST: SANPHAMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string MASP , string MALO)
        {
            SANPHAM sANPHAM = db.SANPHAMs.Where(x => (x.MASP == MASP) && (x.MALO == MALO)).FirstOrDefault();
            db.SANPHAMs.Remove(sANPHAM);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // POST : AddLot
        public ActionResult ViewAddLot(string id)
        {
            var product = new SANPHAM();
            product.MASP = id;
            var listsp = db.SANPHAMs.Where(x => x.MASP == id);
            var lastLot = listsp.OrderByDescending(x => x.MALO).FirstOrDefault();
            product.TENSP = lastLot.TENSP;
            ViewBag.ProName = lastLot.TENSP;
            if (lastLot == null)
            {
                product.MALO = "L00001";

            }
            else
            {
                product.MALO = "L" + (Convert.ToInt32(lastLot.MALO.Substring(1, lastLot.MALO.Length - 1)) + 1).ToString("D5");
            }
            return View(product);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProLot([Bind(Include = "MASP,TENSP,MALO,GIABAN,LOINHUAN,SL,BAOHANH")] SANPHAM sANPHAM)
        {
            if (ModelState.IsValid)
            {
                db.SANPHAMs.Add(sANPHAM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sANPHAM);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
