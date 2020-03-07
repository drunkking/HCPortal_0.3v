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
    public class PredmetController : Controller
    {
        private IPredmet predmetRepository;



        public PredmetController()
        {
            predmetRepository = new PredmetRepository();

        }

        // GET: Predmet
        public ActionResult Index()
        {
            List<PredmetLOC> svi_predmeti = predmetRepository.sviPredmeti();
            return View("Index", svi_predmeti);
        }

        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(PredmetLOC predmetLoc, int[] razredi)
        {
            bool rezultat_upisa = predmetRepository.upisiNoviPredmet(predmetLoc, razredi);

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
            PredmetLOC predmetLoc = predmetRepository.traziPredmet(id);

            if(predmetLoc != null)
            {
                return View("Edit", predmetLoc);
            }
            else
            {
                return HttpNotFound("404");
            }
        }

        [HttpPost]
        public ActionResult Edit(PredmetLOC predmetLoc, int[] razredi)
        {
            bool rezultat_izmene = predmetRepository.izmeniPredmet(predmetLoc, razredi);

            if (rezultat_izmene)
            {
                Session["rezultat_izmene"] = "prosao";
            }
            else
            {
                Session["rezultat_izmene"] = "pao";
            }

            return RedirectToAction("Edit", new { id = predmetLoc.sifra_predmeta });
        }
    }
}