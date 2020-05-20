using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project_Test2.Models;

namespace Project_Test2.Controllers
{
    public class DETAILsController : Controller
    {
        private Project_Test2Context db = new Project_Test2Context();

        //GET: DETAILs
        public ActionResult Index(int? id)
        {
            ViewBag.Model = db.DETAILs.Where(x => x.MAHD == id);

            ViewBag.MASP = new SelectList(db.SANPHAMs, "MASP", "TENSP");
            ViewBag.MAHD = id;
            return View();
        }
        public ActionResult IndexADD(int? id, int flag)
        {
            ViewBag.Model = db.DETAILs.Where(x => x.MAHD == id);

            ViewBag.MASP = db.SANPHAMs;
            ViewBag.MAHD = id;
            ViewBag.Flag = flag;


            return View();
        }

        // GET: DETAILs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETAIL dETAIL = db.DETAILs.Find(id);
            if (dETAIL == null)
            {
                return HttpNotFound();
            }
            return View(dETAIL);
        }

        // GET: DETAILs/Create
        //public ActionResult Create(int? id)
        //{



        //    return View(db.DETAILs.ToList());
        //}

        // POST: DETAILs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MADT,MAHD,SOLUONG,MASP,TENSP,GIANHAP,GIABAN,TIEN,NGAYBAN")] DETAIL dETAIL)
        {

            SANPHAM sp = db.SANPHAMs.Find(dETAIL.MASP);
            dETAIL.GIANHAP = sp.GIANHAP;
            dETAIL.GIABAN = sp.GIANHAP * sp.LOINHUAN / 100;
            dETAIL.TIEN = dETAIL.GIABAN * dETAIL.SOLUONG;
            dETAIL.TENSP = sp.TENSP;


            db.DETAILs.Add(dETAIL);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = dETAIL.MAHD });



        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CREATEADD([Bind(Include = "MADT,MAHD,SOLUONG,MASP,TENSP,MALO,GIANHAP,GIABAN,TIEN,NGAYBAN")] DETAIL dETAIL)
        {
            dETAIL.MALO = dETAIL.MASP.Substring(6);
            dETAIL.MASP = dETAIL.MASP.Substring(0, 6);
            var listsp = db.SANPHAMs.Where(x => (x.MASP == dETAIL.MASP) && (x.MALO == dETAIL.MALO));
            SANPHAM sp = listsp.FirstOrDefault();

            if (sp.SL < dETAIL.SOLUONG)
            {
                int flag = 0;

                return RedirectToAction("IndexADD", new { id = dETAIL.MAHD, flag });
            }
            else
            {
                HOADON hOADON = db.HOADONs.Find(dETAIL.MAHD);
                dETAIL.NGAYBAN = hOADON.NGAYBAN;
                dETAIL.GIANHAP = sp.GIANHAP;
                dETAIL.GIABAN = (((sp.GIANHAP * (sp.LOINHUAN+100))/100)*((100-sp.Sale)))/100;
                dETAIL.TIEN = dETAIL.GIABAN * dETAIL.SOLUONG;
                dETAIL.TENSP = sp.TENSP;
                sp.SL = sp.SL - dETAIL.SOLUONG;


                db.DETAILs.Add(dETAIL);
                db.SaveChanges();
                int flag = 1;
                return RedirectToAction("IndexADD", new { id = dETAIL.MAHD, flag });
            }





        }

        // GET: DETAILs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETAIL dETAIL = db.DETAILs.Find(id);
            if (dETAIL == null)
            {
                return HttpNotFound();
            }
            return View(dETAIL);
        }

        // POST: DETAILs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MADT,MAHD,SOLUONG,MASP,TENSP,DONGIA,TIEN,NGAYBAN")] DETAIL dETAIL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dETAIL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = dETAIL.MAHD });
            }
            return View(dETAIL);
        }

        // GET: DETAILs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETAIL dETAIL = db.DETAILs.Find(id);
            if (dETAIL == null)
            {
                return HttpNotFound();
            }
            return View(dETAIL);
        }

        // POST: DETAILs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DETAIL dETAIL = db.DETAILs.Find(id);
            db.DETAILs.Remove(dETAIL);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = dETAIL.MAHD });
        }
        public ActionResult Search()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search1([Bind(Include = "start,end")] Search search)
        {

            var data = db.DETAILs.Where(x => (x.NGAYBAN >= search.start) && (x.NGAYBAN <= search.end));
            var data1 = data.GroupBy(x => x.TENSP)
                .Select(g => new TK
                {
                    TENSANPHAM = g.Key,
                    SL = g.Sum(y => y.SOLUONG)
                }
                );


            ViewBag.Model = data1;
            ViewBag.Start = search.start;
            ViewBag.End = search.end;
            return View();


        }
        public ActionResult SearchItem()

        {
            var data = db.SANPHAMs;
            ViewBag.MASP = data.Select(g => g.TENSP).Distinct();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SearchItem_(DateTime start , DateTime end, string TENSP)
        {

            var data = db.DETAILs.Where(x => (x.NGAYBAN >=start) && (x.NGAYBAN <=end) && (x.TENSP==TENSP));
          

            ViewBag.Model = data;
            ViewBag.Start =start;
            ViewBag.End =end;
            ViewBag.Pro = TENSP;
            return View();


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
