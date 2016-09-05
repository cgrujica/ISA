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
        public ActionResult Edit()
        {
            return View();
        }
    }
}