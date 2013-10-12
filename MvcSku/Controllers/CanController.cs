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
    public class CanController : Controller
    {
        private LibraryContext db = new LibraryContext();

        //
        // GET: /Can/

        public ActionResult Index()
        {
            return View(db.Units.ToList());
        }

        //
        // GET: /Can/Details/5

        public ActionResult Details(int id = 0)
        {
            Can can = (Can)db.Units.Find(id);
            if (can == null)
            {
                return HttpNotFound();
            }
            return View(can);
        }

        //
        // GET: /Can/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Can/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Can can)
        {
            if (ModelState.IsValid)
            {
                db.Units.Add(can);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(can);
        }

        //
        // GET: /Can/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Can can = (Can)db.Units.Find(id);
            if (can == null)
            {
                return HttpNotFound();
            }
            return View(can);
        }

        //
        // POST: /Can/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Can can)
        {
            if (ModelState.IsValid)
            {
                db.Entry(can).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(can);
        }

        //
        // GET: /Can/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Can can = (Can)db.Units.Find(id);
            if (can == null)
            {
                return HttpNotFound();
            }
            return View(can);
        }

        //
        // POST: /Can/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Can can = (Can)db.Units.Find(id);
            db.Units.Remove(can);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}