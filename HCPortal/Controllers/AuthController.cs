using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using HCPortal.Models;
using HCPortal.Models.L2SRepository;
using HCPortal.Models.RepositoryInterfaces;



namespace HCPortal.Controllers
{
    public class AuthController : Controller
    {
        private IAuthModerator authModerator = new AuthModeratorRepository();
        private IAuthUcenik authUcenik = new AuthUcenikRepository();
        private IUcenik ucenikRepository = new UcenikRepository();

        public ActionResult Index()
        {
            return View("Index");
        }

        public ActionResult LoginModerator()
        {
            if (Session["ModeratorPrijavljen"] != null)
            {
                return RedirectToAction("Index", "Moderator");
            }

            return View();
        }

        [HttpPost]
        public ActionResult LoginModerator(ModeratorLOC moderator)
        {
            if (authModerator.proveri_validnost(moderator))
            {
                Session["ModeratorPrijavljen"] = true;

                return RedirectToAction("Index", "Moderator");
            }

            return View();
        }


        public ActionResult LoginUcenik()
        {
            if (Session["UcenikPrijavljen"] != null)
            {
                return RedirectToAction("Index", "UcenikGuest");
            }

            return View();
        }

        [HttpPost]
        public ActionResult LoginUcenik(UcenikLOC ucenik)
        {
            if (authUcenik.proveri_validnost(ucenik))
            {
                Session["UcenikPrijavljen"] = true;
                Session["UcenikKorisnickoIme"] = ucenik.korisnicko_ime;
                Session["UcenikSifraUcenika"] = ucenikRepository.sifraUcenika(ucenik.korisnicko_ime);
                return RedirectToAction("Index", "UcenikGuest");
            }

            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Auth");
        }
    }
}