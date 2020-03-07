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
        // GET: UcenikGuest
        public ActionResult Index()
        {
            return View();
        }
    }
}