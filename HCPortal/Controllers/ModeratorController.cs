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
    public class ModeratorController : Controller
    {

        private IAuthModerator authModerator = new AuthModeratorRepository();
        private IModerator moderatorRepository = new ModeratorRepository();


        // GET: Moderator
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Show()
        {
            List<ModeratorLOC> svi_moderatori = moderatorRepository.sviModeratori();
            return View("Show", svi_moderatori);
        }

        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(ModeratorLOC moderatorLoc)
        {
            bool rezultat_upisa = moderatorRepository.upisiNovogModerator(moderatorLoc);

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
            ModeratorLOC moderatorLoc = moderatorRepository.traziModeratora(id);

            if (moderatorLoc != null)
            {
                
                return View("Edit", moderatorLoc);
            }
            else
            {
                return HttpNotFound("404");
            }
        }

        [HttpPost]
        public ActionResult Edit(ModeratorLOC moderatorLoc)
        {
            bool rezultat_izmene = moderatorRepository.izmeniModeratora(moderatorLoc);

            if(rezultat_izmene)
            {
                Session["rezultat_izmene"] = "prosao";
            }
            else
            {
                Session["rezultat_izmene"] = "pao";
            }

            return RedirectToAction("Edit", new { id = moderatorLoc.sifra_moderatora });
        }
    }
}