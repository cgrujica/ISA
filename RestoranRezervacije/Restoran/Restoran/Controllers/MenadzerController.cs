using Restoran.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restoran.Controllers
{
    public class MenadzerController : Controller
    {
        RezervacijeDBEntities db = new RezervacijeDBEntities();

        // GET: Menadzer
        public ActionResult Index()
        {
            return View(db.MENADZERs.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.ID_RESTORANA = new SelectList(db.RESTORANs, "ID_RESTORANA", "NAZIV_RESTORANA");
            return View();
        }

        [HttpPost]
        public ActionResult Create(MENADZER menadzer)
        {
            if (ModelState.IsValid)
            {
                db.MENADZERs.Add(menadzer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_RESTORANA = new SelectList(db.RESTORANs, "ID_RESTORANA", "NAZIV_RESTORANA", menadzer.ID_RESTORANA);
            return View(menadzer);
        }


        public ActionResult Delete(string id = null)
        {
            MENADZER menadzer = db.MENADZERs.Find(id);
            if (menadzer == null)
            {
                return HttpNotFound();
            }
            return View(menadzer);
        }

        //
        // POST: /Menadzer/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            MENADZER menadzer = db.MENADZERs.Find(id);
            db.MENADZERs.Remove(menadzer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string id = null)
        {
            MENADZER menadzer = db.MENADZERs.Find(id);
            if (menadzer == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_RESTORANA = new SelectList(db.RESTORANs, "ID_RESTORANA", "NAZIV_RESTORANA", menadzer.ID_RESTORANA);
            return View(menadzer);
        }

        //
        // POST: /Menadzer/Edit/5

        [HttpPost]
        public ActionResult Edit(MENADZER menadzer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(menadzer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_RESTORANA = new SelectList(db.RESTORANs, "ID_RESTORANA", "NAZIV_RESTORANA", menadzer.ID_RESTORANA);
            return View(menadzer);
        }

        public ActionResult Details(string id = null)
        {
            MENADZER menadzer = db.MENADZERs.Find(id);
            if (menadzer == null)
            {
                return HttpNotFound();
            }
            return View(menadzer);
        }

    }
}