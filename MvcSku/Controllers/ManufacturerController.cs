﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcSku.Models;
using MvcSku.DAL;
using PagedList;

namespace MvcSku.Controllers
{
    public class ManufacturerController : Controller
    {
        private LibraryContext db = new LibraryContext();

        //
        // GET: /Manufacturer/

        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page )
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name_desc" : "";
            if (searchString != null)
            {
                page = 1;
            }
            else {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;

            var manufacturers = from m in db.Manufacturers
                                select m;
            if (!String.IsNullOrEmpty(searchString))
            { 
              manufacturers = manufacturers.Where(m => m.ManufacturerName.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            { 
                case "Name_desc":
                    manufacturers = manufacturers.OrderByDescending(m => m.ManufacturerName);
                    break;
                default:
                    manufacturers = manufacturers.OrderBy(m => m.ManufacturerName);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(manufacturers.ToPagedList(pageNumber, pageSize));
        }

        //
        // GET: /Manufacturer/Details/5

        public ActionResult Details(int id = 0)
        {
            Manufacturer manufacturer = db.Manufacturers.Find(id);
            if (manufacturer == null)
            {
                return HttpNotFound();
            }
            return View(manufacturer);
        }

        //
        // GET: /Manufacturer/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Manufacturer/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include="ManufacturerName")]
            Manufacturer manufacturer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Manufacturers.Add(manufacturer);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
   {

      ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
   }
   return View(manufacturer);
}
   
        //
        // GET: /Manufacturer/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Manufacturer manufacturer = db.Manufacturers.Find(id);
            if (manufacturer == null)
            {
                return HttpNotFound();
            }
            return View(manufacturer);
        }

        //
        // POST: /Manufacturer/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ManufacturerId, ManufacturerName")]Manufacturer manufacturer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(manufacturer).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(manufacturer);
        }

        //
        // GET: /Manufacturer/Delete/5

        public ActionResult Delete(bool? saveChangesError = false, int id = 0)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            Manufacturer manufacturer = db.Manufacturers.Find(id);
            if (manufacturer == null)
            {
                return HttpNotFound();
            }
            return View(manufacturer);
        }

        //
        // POST: /Manufacturer/Delete/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Manufacturer manufacturer = db.Manufacturers.Find(id);
                db.Manufacturers.Remove(manufacturer);
                db.SaveChanges();
            }
            catch (DataException/* dex */)
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}