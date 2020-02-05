using DAL.Model;
using DAL.Repo;
using PublicSite.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PublicSite.Controllers
{
    public class HomeController : Controller
    {
        private RegistrationViewModel model = new RegistrationViewModel();
        public string Username
        {
            get => FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name;
        }

        public ActionResult Index()
        {
            if (SqlRepo.Instance.FetchLoggedInKorisnik() != null)
            {
                return RedirectToAction("MainMenu", "Home");
            }
            else return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Korisnik k)
        {
            ViewBag.user = k;
            FormsAuthentication.SetAuthCookie(k.KorisnickoIme, false);
            SqlRepo.Instance.InsertKorisnik(k.KorisnickoIme, k.Ime, k.Prezime, k.DOB, k.Spol, k.TipDijabetesa, k.FizickaAktivnost, k.Visina, k.Tezina, k.Email, k.Lozinka);
            SqlRepo.Instance.SaveLoggedInKorisnik(k.KorisnickoIme);
            return RedirectToAction("MainMenu", "Home");

        }

        [HttpGet]
        public ActionResult MainMenu()
        {
            Korisnik k = SqlRepo.Instance.FetchLoggedInKorisnik();
            ViewBag.Ime = k.Ime + " " + k.Prezime;
            return View();
        }

        [AllowAnonymous]
        public ActionResult LogIn(LogInViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Content("Bad request");
            }
            foreach (var k in SqlRepo.Instance.FetchKorisnici())
            {
                if (k.KorisnickoIme == model.Username && k.Lozinka == model.Password)
                {
                    SqlRepo.Instance.SaveLoggedInKorisnik(model.Username);
                    FormsAuthentication.SetAuthCookie(model.Username, false);
                    return RedirectToAction("MainMenu", "Home");
                }
            }
            TempData["showModal"] = "login";
            TempData["errorMessage"] = $"Podaci nisu ispravni";
            return RedirectToAction("Index", "Home");
        }

        public ActionResult LogOff()
        {
            SqlRepo.Instance.LogOutKorisnik();
            // Obriši cookie i vrati korisnika na landing page.
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Settings()
        {
            Korisnik k = SqlRepo.Instance.FetchLoggedInKorisnik();
            model.IDKorisnik = k.IDKorisnik;
            model.Email = k.Email;
            model.KorisnickoIme = k.KorisnickoIme;
            model.Lozinka = k.Lozinka;
            model.Ime = k.Ime;
            model.Prezime = k.Prezime;
            model.DOB = k.DOB;
            model.Spol = k.Spol;
            model.TipDijabetesa = k.TipDijabetesa;
            model.Visina = k.Visina;
            model.Tezina = k.Tezina;

            ViewData.Model = model;
            return View();
        }

        public ActionResult Settings(Korisnik k)
        {
            ViewBag.user = k;
            ViewData.Model = model;

            if (k.Ime==null||k.Prezime==null||k.Email==null)
            {
                TempData["Message"] = "Please fill in all the fields!";

                k = SqlRepo.Instance.FetchLoggedInKorisnik();
                model.IDKorisnik = k.IDKorisnik;
                model.Email = k.Email;
                model.KorisnickoIme = k.KorisnickoIme;
                model.Lozinka = k.Lozinka;
                model.Ime = k.Ime;
                model.Prezime = k.Prezime;
                model.DOB = k.DOB;
                model.Spol = k.Spol;
                model.TipDijabetesa = k.TipDijabetesa;
                model.Visina = k.Visina;
                model.Tezina = k.Tezina;
                ViewData.Model = model;
                return View();
            }
            else
            {
                SqlRepo.Instance.UpdateKorisnik(k.KorisnickoIme, k.Ime, k.Prezime, k.DOB, k.Spol, k.TipDijabetesa, k.FizickaAktivnost, k.Visina, k.Tezina, k.Email, k.BMI);
            }
            SqlRepo.Instance.SaveLoggedInKorisnik(k.KorisnickoIme);
            return RedirectToAction("MainMenu", "Home");

        }

        public ActionResult ViewMenus()
        {
            return View();
        }

        public ActionResult EditMenus()
        {
            return View();
        }
    }
}