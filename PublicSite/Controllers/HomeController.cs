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
            return View();
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
    }
}