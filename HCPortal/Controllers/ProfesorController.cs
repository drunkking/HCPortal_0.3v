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
    [Filters.ModeratorFilter]
    public class ProfesorController : Controller
    {

        private IProfesor profesorRepository = new ProfesorRepository();

        // GET: Profesor
        public ActionResult Index()
        {
            List<ProfesorLOC> svi_profesori = profesorRepository.sviProfesori();
            return View("Index",svi_profesori);
        }

        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(ProfesorLOC profesorLoc)
        {
            bool rezultat_upisa = profesorRepository.upisiNovogProfesora(profesorLoc);

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
            ProfesorLOC profesorLoc = profesorRepository.traziProfesora(id);

            if(profesorLoc != null)
            {
                return View("Edit", profesorLoc);
            }
            else
            {
                return HttpNotFound("404");
            }
        }

        [HttpPost]
        public ActionResult Edit(ProfesorLOC profesorLoc)
        {
            bool rezultat_izmene = profesorRepository.izmeniProfesora(profesorLoc);

            if(rezultat_izmene)
            {
                Session["rezultat_izmene"] = "prosao";
            }
            else
            {
                Session["rezultat_izmene"] = "pao";
            }

            return RedirectToAction("Edit", new { id = profesorLoc.sifra_profesora });
        }
    }
}