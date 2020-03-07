using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HCPortal.Models;
using HCPortal.Models.RepositoryInterfaces;
using HCPortal.Models.L2SRepository;


namespace HCPortal.Controllers
{
    [Filters.ModeratorFilter]
    public class OdeljenjeController : Controller
    {

        private IOdeljenje odeljenjeRepository;


        public OdeljenjeController()
        {
            odeljenjeRepository = new OdeljenjeRepositroy();
        }

        // GET: Odeljenje
        public ActionResult Index()
        {
            List<OdeljenjeLOC> sva_odeljenja = odeljenjeRepository.svaOdeljenja();
            return View("Index",sva_odeljenja);
        }

        public ActionResult Create()
        {
            return View("Create");
        }
        
        [HttpPost]
        public ActionResult Create(OdeljenjeLOC odeljenjeLoc)
        {
            bool rezultat_upisa = odeljenjeRepository.upisiNovoOdeljenje(odeljenjeLoc);

            if(rezultat_upisa)
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
            OdeljenjeLOC odeljenjeLoc = odeljenjeRepository.traziOdeljenje(id);

            if(odeljenjeLoc != null)
            {
                return View("Edit", odeljenjeLoc);
            }
            else
            {
                return HttpNotFound("404");
            }
        }

        [HttpPost]
        public ActionResult Edit(OdeljenjeLOC odeljenjeLoc)
        {
            bool rezultat_izmene = odeljenjeRepository.izmeniOdeljenje(odeljenjeLoc);

            if(rezultat_izmene)
            {
                Session["rezultat_izmene"] = "prosao";
            }
            else
            {
                Session["rezultat_izmene"] = "pao";
            }

            return RedirectToAction("Edit", new { id = odeljenjeLoc.sifra_odeljenja });
        }
    }
}