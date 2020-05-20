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
    public class NVsController : Controller
    {
        private Project_Test2Context db = new Project_Test2Context();

        // GET: NVs
        public ActionResult Index()
        {
            var user = (UserLogin)Session[CommonConstants.USER_SEESION];
            ViewBag.UserName = user.Name;
            return View(db.NVs.ToList());
        }

        // GET: NVs/Details/5
        public ActionResult Details()
        {

            var user = (UserLogin)Session[CommonConstants.USER_SEESION];
            NV nV = db.NVs.Find(user.UserID);
            if (nV == null)
            {
                return HttpNotFound();
            }
            return View(nV);
        }

        // GET: NVs/Create
        public ActionResult Create()
        {
            var user = (UserLogin)Session[CommonConstants.USER_SEESION];
            if (user.TypeNV == "admin")
            {

                ViewBag.UserName = user.Name;
                return View();
            }
            return RedirectToAction("Index");

        }

        // POST: NVs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MANV,HOTEN,GIOITINH,SDT,NGAYSINH,DIACHI,USERNAME,PASSWORD,TYPENV")] NV nV)
        {


            db.NVs.Add(nV);
            db.SaveChanges();
            return RedirectToAction("Index");




        }

        // GET: NVs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NV nV = db.NVs.Find(id);
            if (nV == null)
            {
                return HttpNotFound();
            }
            return View(nV);
        }

        // POST: NVs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MANV,HOTEN,GIOITINH,SDT,NGAYSINH,DIACHI,USERNAME,PASSWORD,TYPENV")] NV nV)
        {
            var user = (UserLogin)Session[CommonConstants.USER_SEESION];
            nV.USERNAME = user.UserName;
            nV.TYPENV = user.TypeNV;


            db.Entry(nV).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");


        }

        // GET: NVs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NV nV = db.NVs.Find(id);
            if (nV == null)
            {
                return HttpNotFound();
            }
            return View(nV);
        }

        // POST: NVs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NV nV = db.NVs.Find(id);
            db.NVs.Remove(nV);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public JsonResult IsAlreadyUsername(string Username)
        {

            return Json(IsUserAvailable(Username));

        }
        public bool IsUserAvailable(string Username)
        {

            var result = db.NVs.Count(x => x.USERNAME == Username);

            bool status;
            if (result > 0)
            {
                //Already registered  
                status = false;
            }
            else
            {
                //Available to use  
                status = true;
            }

            return status;
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
