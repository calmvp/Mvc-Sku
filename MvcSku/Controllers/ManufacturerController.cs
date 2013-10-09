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
    public class ManufacturerController : Controller
    {
        private LibraryContext db = new LibraryContext();

        //
        // GET: /Manufacturer/

        public ActionResult Index()
        {
            return View(db.Manufacturers.ToList());
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
      //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
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
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
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
            return RedirectToAction("Index")
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}