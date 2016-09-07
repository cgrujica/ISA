using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restoran.Models;
using System.Net.Mail;
using System.Net;

namespace Restoran.Controllers
{
    public class RegistracijaController : Controller
    {

        RezervacijeDBEntities db = new RezervacijeDBEntities();

        public object Utility { get; private set; }

        // GET: Registracija
        public ActionResult Index()
        {
            return View();
        }

        // GET: Registracija/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Registracija/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Registracija/Create
        [HttpPost]
        public ActionResult Create(GOST gost)
        {
            try
            {
                // TODO: Add insert logic here
                GOST g = new GOST();
                g.EMAIL_GOSTA = gost.EMAIL_GOSTA;
                g.PASS_GOSTA = gost.PASS_GOSTA;
                g.IME_GOSTA = gost.IME_GOSTA;
                g.PREZIME_GOSTA = gost.PREZIME_GOSTA;
                g.POL_GOSTA = "m" ;
                g.MAIL_POTVRA = false;
                g.CPASS_GOSTA = gost.CPASS_GOSTA;
                g.SLIKA = null;

                db.GOSTs.Add(g);
                db.SaveChanges();

                return RedirectToAction("LogIn");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(GOST gost)
        {
            try
            {
                if (db.GOSTs.Where(x => x.EMAIL_GOSTA == gost.EMAIL_GOSTA).Select(x => x.PASS_GOSTA).Single() == gost.PASS_GOSTA)
                {
                    Session["idGosta"] = gost.EMAIL_GOSTA;
                    return RedirectToAction("Profil", "Profil");
                }
                else
                {
                    return RedirectToAction("LogIn");
                }
        


            }
            catch (Exception)
            {
                try
                {
                    if (db.MENADZERs.Where(x => x.IDMENADZERA == gost.EMAIL_GOSTA).Select(x => x.ASD).Single() == gost.PASS_GOSTA)
                    {
                        Session["idMenadzera"] = gost.EMAIL_GOSTA;
                        return RedirectToAction("ManagerLogin", "Profil");
                    }
                    else
                    {
                        return RedirectToAction("Login");
                    }
                }
                catch (Exception)
                {

                    return RedirectToAction("LogIn");
                }
                return RedirectToAction("LogIn");
            }          
           
             return null;
        }


        // GET: Registracija/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Registracija/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Registracija/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Registracija/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
