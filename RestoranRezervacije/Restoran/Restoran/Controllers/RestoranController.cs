using Restoran.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restoran.Controllers
{
    public class RestoranController : Controller
    {
        private RezervacijeDBEntities db = new RezervacijeDBEntities();
        // GET: Restoran

        public ActionResult Create()
        {
            return View();
        }
        // GET: Restoran/Create
        [HttpPost]
        public ActionResult Create(RESTORAN restoran)
        {
            if (ModelState.IsValid)
            {
                db.RESTORANs.Add(restoran);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(restoran);
        }

        public ActionResult Edit(string id = null)
        {
            RESTORAN restoran = db.RESTORANs.Find(id);
            if (restoran == null)
            {
                return HttpNotFound();
            }
            return View(restoran);
        }

        //
        // POST: /Restoran/Edit/5

        [HttpPost]
        public ActionResult Edit(RESTORAN restoran)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restoran).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(restoran);
        }


        public ActionResult Details(string id = null)
        {
            RESTORAN restoran = db.RESTORANs.Find(id);
            if (restoran == null)
            {
                return HttpNotFound();
            }
            return View(restoran);
        }



        public ActionResult Index()
        {
             return View(db.RESTORANs.ToList());
        }



        public ActionResult Delete(string id = null)
        {
            RESTORAN restoran = db.RESTORANs.Find(id);
            if (restoran == null)
            {
                return HttpNotFound();
            }
            return View(restoran);
        }

        //
        // POST: /Restoran/Delete/

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            RESTORAN restoran = db.RESTORANs.Find(id);
            db.RESTORANs.Remove(restoran);
            db.SaveChanges();
            return RedirectToAction("Index");
        }






    }
}