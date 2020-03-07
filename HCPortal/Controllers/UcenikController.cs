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
    [Filters.ModeratorFilter]
    public class UcenikController : Controller
    {

        private IUcenik ucenikRepository = new UcenikRepository();
        private IOdeljenje odeljenjeRepository = new OdeljenjeRepositroy();

        // GET: Ucenik
        public ActionResult Index()
        {
            List<UcenikLOC> svi_ucenici = ucenikRepository.sviUcenici();
            return View("Index",svi_ucenici);
        }


        public ActionResult Create()
        {
            ViewBag.Odeljenja = odeljenjeRepository.svaOdeljenja();
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(UcenikLOC ucenikLoc)
        {
            bool rezultat_upisa = ucenikRepository.upisiNovogUcenika(ucenikLoc);

            if (rezultat_upisa)
            {
                Session["rezultat_upisa"] = "prosao";
            }
            else
            {
                Session["rezultat_upisa"] = "pao";
            }

            return RedirectToAction("Create");
        }

        public ActionResult Edit(int? id)
        {
            UcenikLOC ucenikLoc = ucenikRepository.traziUcenika(id);
            
            if (ucenikLoc != null)
            {
                ViewBag.Odeljenja = odeljenjeRepository.svaOdeljenja();
                return View("Edit", ucenikLoc);
            }
            else
            {
                return HttpNotFound("404");
            }
        }

        [HttpPost]
        public ActionResult Edit(UcenikLOC ucenikLoc)
        {
            bool rezultat_izmene = ucenikRepository.izmeniUcenika(ucenikLoc);

            if(rezultat_izmene)
            {
                Session["rezultat_izmene"] = "prosao";
            }
            else
            {
                Session["rezultat_izmene"] = "pao";
            }

            return RedirectToAction("Edit", new { id = ucenikLoc.sifra_ucenika });
        }
    }
}