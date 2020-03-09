using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HCPortal.Models;
using HCPortal.Models.L2SRepository;
using HCPortal.Models.RepositoryInterfaces;


namespace HCPortal.Controllers
{
    [Filters.UcenikFilter]
    public class UcenikGuestController : Controller
    {

        private IAuthUcenik authUcenik = new AuthUcenikRepository();
        private IDnevnik dnevnikRepository = new DnevnikRepository();
        private IUcenik ucenikRepositroy = new UcenikRepository();
        // GET: UcenikGuest
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PregledPredmeta(int ucenik_sifra)
        {
            List<PredmetLOC> svi_predmeti = dnevnikRepository.predmetiUcenika(ucenik_sifra);

            if (svi_predmeti != null)
            {
                ViewBag.sifra_ucenika = ucenik_sifra;
                return View("PregledPredmeta", svi_predmeti);
            }
            else
            {
                return HttpNotFound("404");
            }
        }

        public ActionResult PregledOcena(int ucenik_sifra, int predmet_sifra)
        {
            List<OcenaUcenikaMetaLOC> sve_ocene_ucenika = dnevnikRepository.traziOceneUcenika(ucenik_sifra, predmet_sifra);

            if (sve_ocene_ucenika != null)
            {
                ViewBag.ucenik = ucenikRepositroy.traziUcenika(ucenik_sifra);
                ViewBag.sifra_predmeta = predmet_sifra;
                return View("PregledOcena", sve_ocene_ucenika);
            }
            else
            {
                return HttpNotFound("404");
            }
        }
    }
}