using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project_Test2.Common;
using Project_Test2.Models;

namespace Project_Test2.Controllers
{
    public class HOADONsController : Controller
    {
        public Project_Test2Context db = new Project_Test2Context();

        // GET: HOADONs
        public ActionResult Index()
        {
            var hOADONs = db.HOADONs.Include(h => h.KHACHHANG).Include(h => h.NV);
            var user = (UserLogin)Session[CommonConstants.USER_SEESION];
            ViewBag.UserName = user.Name;
            return View(hOADONs.ToList());
        }

        // GET: HOADONs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOADON hOADON = db.HOADONs.Find(id);
            if (hOADON == null)
            {
                return HttpNotFound();
            }
            return View(hOADON);
        }

        // GET: HOADONs/Create
        public ActionResult Create()
        {
            ViewBag.MAKH = new SelectList(db.KHACHHANGs, "MAKH", "TENKH");
            ViewBag.MANV = new SelectList(db.NVs, "MANV", "HOTEN");
         var user = (UserLogin)Session[CommonConstants.USER_SEESION];
            ViewBag.UserName = user.Name;
            return View();
        }

        // POST: HOADONs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "MAHD,MANV,MAKH,NGAYBAN")] HOADON hOADON)
        //{
        //    var user = (UserLogin)Session[CommonConstants.USER_SEESION];

        //    hOADON.MANV = user.UserID;
        //    if (ModelState.IsValid)
        //    {
        //        db.HOADONs.Add(hOADON);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.MAKH = new SelectList(db.KHACHHANGs, "MAKH", "TENKH", hOADON.MAKH);
        //    ViewBag.MANV = new SelectList(db.NVs, "MANV", "HOTEN", hOADON.MANV);
        //    return View(hOADON);
        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ADD([Bind(Include = "MAHD,MANV,MAKH,NGAYBAN")] HOADON hOADON)
        {
            var user = (UserLogin)Session[CommonConstants.USER_SEESION];
            hOADON.MANV = user.UserID;

            if (ModelState.IsValid)
            {
                db.HOADONs.Add(hOADON);
                db.SaveChanges();
                ViewBag.MAHD = hOADON.MAHD;
                ViewBag.NGAYBAN = hOADON.NGAYBAN;
                ViewBag.MASP = db.SANPHAMs;
                ViewBag.Model = db.DETAILs.Where(x => x.MAHD == hOADON.MAHD);

                return View();
            }

            ViewBag.MAKH = new SelectList(db.KHACHHANGs, "MAKH", "TENKH", hOADON.MAKH);
            ViewBag.MANV = new SelectList(db.NVs, "MANV", "HOTEN", hOADON.MANV);
            return View(hOADON);
        }
        // GET: HOADONs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOADON hOADON = db.HOADONs.Find(id);
            if (hOADON == null)
            {
                return HttpNotFound();
            }
            ViewBag.MAKH = new SelectList(db.KHACHHANGs, "MAKH", "TENKH", hOADON.MAKH);
            ViewBag.MANV = new SelectList(db.NVs, "MANV", "HOTEN", hOADON.MANV);
            return View(hOADON);
        }

        // POST: HOADONs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MAHD,MANV,MAKH,NGAYBAN")] HOADON hOADON)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hOADON).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MAKH = new SelectList(db.KHACHHANGs, "MAKH", "TENKH", hOADON.MAKH);
            ViewBag.MANV = new SelectList(db.NVs, "MANV", "HOTEN", hOADON.MANV);
            return View(hOADON);
        }

        // GET: HOADONs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOADON hOADON = db.HOADONs.Find(id);
            if (hOADON == null)
            {
                return HttpNotFound();
            }
            return View(hOADON);
        }

        // POST: HOADONs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HOADON hOADON = db.HOADONs.Find(id);
            db.HOADONs.Remove(hOADON);
            db.SaveChanges();
            return RedirectToAction("Index");
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
