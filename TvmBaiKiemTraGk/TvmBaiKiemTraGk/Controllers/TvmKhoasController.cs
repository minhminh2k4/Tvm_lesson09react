using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TvmBaiKiemTraGk.Models;

namespace TvmBaiKiemTraGk.Controllers
{
    public class TvmKhoasController : Controller
    {
        private Tvmk22CNT2Lesson07DbEntities db = new Tvmk22CNT2Lesson07DbEntities();

        // GET: TvmKhoas
        public ActionResult TvmIndex()
        {
            return View(db.tvmKhoa.ToList());
        }

        // GET: TvmKhoas/Details/5
        public ActionResult TvmDetails(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tvmKhoa tvmKhoa = db.tvmKhoa.Find(id);
            if (tvmKhoa == null)
            {
                return HttpNotFound();
            }
            return View(tvmKhoa);
        }

        // GET: TvmKhoas/Create
        public ActionResult TvmCreate()
        {
            return View();
        }

        // POST: TvmKhoas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TvmCreate([Bind(Include = "TvmMaKH,TvmTenKH,TvmTrangThai")] tvmKhoa tvmKhoa)
        {
            if (ModelState.IsValid)
            {
                db.tvmKhoa.Add(tvmKhoa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tvmKhoa);
        }

        // GET: TvmKhoas/Edit/5
        public ActionResult TvmEdit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tvmKhoa tvmKhoa = db.tvmKhoa.Find(id);
            if (tvmKhoa == null)
            {
                return HttpNotFound();
            }
            return View(tvmKhoa);
        }

        // POST: TvmKhoas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TvmEdit([Bind(Include = "TvmMaKH,TvmTenKH,TvmTrangThai")] tvmKhoa tvmKhoa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tvmKhoa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tvmKhoa);
        }

        // GET: TvmKhoas/Delete/5
        public ActionResult TvmDelete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tvmKhoa tvmKhoa = db.tvmKhoa.Find(id);
            if (tvmKhoa == null)
            {
                return HttpNotFound();
            }
            return View(tvmKhoa);
        }

        // POST: TvmKhoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult TvmDeleteConfirmed(string id)
        {
            tvmKhoa tvmKhoa = db.tvmKhoa.Find(id);
            db.tvmKhoa.Remove(tvmKhoa);
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
