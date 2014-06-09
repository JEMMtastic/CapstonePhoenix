using Capstone.WebUI.Domain.Abstract;
using Capstone.WebUI.Domain.Concrete;
using Capstone.WebUI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.WebUI.Controllers
{
    public class ProfilesController : Controller
    {
        PartnershipNightInterface pnRepo;
        UserInterface uRepo;
        CharityInterface cRepo;
        BvLocationInterface lRepo;
        FormInterface fRepo;

        // The default constructor is called by the framework
        public ProfilesController()
        {
            uRepo = new UserRepository();
            pnRepo = new PartnershipNightRepository();
            cRepo = new CharityRepository();
            lRepo = new BvLocationRepository();
            fRepo = new FormRepository();
        }

        // Use this for dependency injection
        public ProfilesController(UserInterface iUser, PartnershipNightInterface iPn, CharityInterface iChar, BvLocationInterface iLoc, FormInterface iForm)
        {
            uRepo = iUser;
            pnRepo = iPn;
            cRepo = iChar;
            lRepo = iLoc;
            fRepo = iForm;
        }

        public ActionResult Index()
        {
            List<BvLocation> locs = lRepo.GetBvLocations(); 
            return View(locs);
        }
    }
}