﻿using System;
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
    public class UnitController : Controller
    {
        private LibraryContext db = new LibraryContext();

        //
        // GET: /Unit/

        public ActionResult Index()
        {
            return View(db.Units.ToList());
        }

        //
        // GET: /Unit/Details/5

        public ActionResult Details(int id = 0)
        {
            Unit unit = db.Units.Find(id);
            if (unit == null)
            {
                return HttpNotFound();
            }
            return View(unit);
        }

        //
        // GET: /Unit/Create

        public ActionResult Create()
        {
            
            // do we know the manufacturer_id?
            // we need to pass it into the view
            ViewBag.Manufacturer = db.Manufacturers.Find(Int32.Parse(Request.QueryString["ManufacturerId"]));
            return View();
        }

        //
        // POST: /Unit/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Unit unit)
        {
            unit.Manufacturer = db.Manufacturers.Find(Int32.Parse(Request.QueryString["ManufacturerId"]));

         
                db.Units.Add(unit);
                db.SaveChanges();


                return RedirectToAction("Details", new { id = unit.UnitId } );
        }

        //
        // GET: /Unit/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Unit unit = db.Units.Find(id);
            if (unit == null)
            {
                return HttpNotFound();
            }
            return View(unit);
        }

        //
        // POST: /Unit/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Unit unit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(unit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", new { id = unit.UnitId });
            }
            return View(unit);
        }

        //
        // GET: /Unit/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Unit unit = db.Units.Find(id);
            if (unit == null)
            {
                return HttpNotFound();
            }
            return View(unit);
        }

        //
        // POST: /Unit/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Unit unit = db.Units.Find(id);
            var ManufacturerInt = unit.Manufacturer.ManufacturerId;
            db.Units.Remove(unit);
            db.SaveChanges();
            return RedirectToAction("Details", "Manufacturer", new { id = ManufacturerInt });
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}