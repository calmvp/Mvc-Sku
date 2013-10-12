using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcSku.Models;
using MvcSku.DAL;

namespace MvcSku.Controllers
{
    public class SoftPackController : Controller
    {
        private LibraryContext db = new LibraryContext();

        //
        // GET: /SoftPack/

        public ActionResult Index()
        {
            return View(db.Units.ToList());
        }

        //
        // GET: /SoftPack/Details/5

        public ActionResult Details(int id = 0)
        {
            SoftPack softpack = (SoftPack)db.Units.Find(id);
            if (softpack == null)
            {
                return HttpNotFound();
            }
            return View(softpack);
        }

        //
        // GET: /SoftPack/Create

        public ActionResult Create()
        {
            ViewBag.Manufacturer = db.Manufacturers.Find(Int32.Parse(Request.QueryString["ManufacturerId"]));
            return View();
        }

        //
        // POST: /SoftPack/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SoftPack softpack)
        {
            softpack.Manufacturer = db.Manufacturers.Find(Int32.Parse(Request.QueryString["ManufacturerId"]));
            db.Units.Add(softpack);
            db.SaveChanges();
            return RedirectToAction("Details", new { id = softpack.UnitId });
        }

        //
        // GET: /SoftPack/Edit/5

        public ActionResult Edit(int id = 0)
        {
            SoftPack softpack = (SoftPack)db.Units.Find(id);
            if (softpack == null)
            {
                return HttpNotFound();
            }
            return View(softpack);
        }

        //
        // POST: /SoftPack/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SoftPack softpack)
        {
            if (ModelState.IsValid)
            {
                db.Entry(softpack).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", new { id = softpack.UnitId }); ;
            }
            return View(softpack);
        }

        //
        // GET: /SoftPack/Delete/5

        public ActionResult Delete(int id = 0)
        {
            SoftPack softpack = (SoftPack)db.Units.Find(id);
            if (softpack == null)
            {
                return HttpNotFound();
            }
            return View(softpack);
        }

        //
        // POST: /SoftPack/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SoftPack softpack = (SoftPack)db.Units.Find(id);
            var ManuId = softpack.Manufacturer.ManufacturerId;
            db.Units.Remove(softpack);
            db.SaveChanges();
            return RedirectToAction("Details", new { controller="Manufacturer", id=ManuId });
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}