using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restoran.Models;
using Restoran.ModelView;
using System.IO;

namespace Restoran.Controllers
{
    public class ProfilController : Controller
    {
        // GET: Profil
        RezervacijeDBEntities db = new RezervacijeDBEntities();

        //public object Utility { get; private set; }

        public ActionResult Profil()
        {
            if (Session["idGosta"] == null)
            {
                RedirectToAction("LogIn","Registracija");
            }
            else
            {
                string idGosta = Session["idGosta"].ToString();
                GOST g = new GOST();
                g = db.GOSTs.Where(z => z.EMAIL_GOSTA == idGosta).Single();
                Restoran.ModelView.Profil prof = new ModelView.Profil();
                prof.adresa = "Brigadira Ristica c8/5";
                prof.email = g.EMAIL_GOSTA;
                prof.ime = g.IME_GOSTA;
                prof.prezime = g.PREZIME_GOSTA;
                var pr = db.PRIJATELJIs.Where(x => x.EMAIL_GOSTA == idGosta).Select(x=>x.EMAIL_GOSTA1).ToList();

                prof.prijatelji = new List<GOST>();
                foreach (var item in pr)
                {
                    prof.prijatelji.Add(db.GOSTs.Where(z => z.EMAIL_GOSTA == item).Single());
                }       
                return View(prof);
            }

            return null;
        }

        /* POCETNA STRANA MENADZERA
         * Ulogaovani menadzer, profil menadzera i u kom restoranu je on menadzer.
         */
        public ActionResult ManagerLogin()
        {            
            ManagerProfile mp = new ManagerProfile();
            string idMenagera = Session["idMenadzera"].ToString();
            mp.menadzer = db.MENADZERs.Where(z => z.IDMENADZERA == idMenagera).Single();
            mp.restoran = db.RESTORANs.Where(z => z.ID_RESTORANA == mp.menadzer.ID_RESTORANA).Single();
            mp.jelovnici = db.JELOVNIKs.Where(x=>x.ID_RESTORANA ==mp.restoran.ID_RESTORANA).ToList();
            return View(mp);
        }


        /* DETAILS
         * Menadzer details jelo.
         */
        public ActionResult DetailsJela(string id)
        {
            JELOVNIK jelovnik = db.JELOVNIKs.Where(x => x.ID_JELA == id).Single();
            if (jelovnik == null)
            {
                return HttpNotFound();
            }
            return View(jelovnik);
        }

        /* EDIT
         * Izmena jela od strane menadzera.
         */
        public ActionResult EditJela(string id)
        {
            JELOVNIK jelo = db.JELOVNIKs.Where(x => x.ID_JELA == id).Single();
            if (jelo == null)
            {
                return HttpNotFound();
            }
            return View(jelo);
        }  

        [HttpPost]
        public ActionResult EditJela(JELOVNIK jelo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jelo).State = Help.Modified;
                db.SaveChanges();
                return RedirectToAction("ManagerProfil");
            }
            return View(jelo);
        }

        /* DELETE
         * Menadzer restorana brise jelo.
         */
        public ActionResult DeleteJela(string id)
        {
            JELOVNIK jelo = db.JELOVNIKs.Where(x => x.ID_JELA == id).Single();
            if (jelo == null)
            {
                return HttpNotFound();
            }
            return View(jelo);
        }

        [HttpPost, ActionName("DeleteJela")]
        public ActionResult DeleteConfirmed(string id)
        {
            JELOVNIK jelo = db.JELOVNIKs.Where(x => x.ID_JELA == id).Single();
            db.JELOVNIKs.Remove(jelo);
            db.SaveChanges();
            return RedirectToAction("ManagerLogin");
        }

    }
}