using Capstone.WebUI.Domain.Abstract;
using Capstone.WebUI.Domain.Concrete;
using Capstone.WebUI.Domain.Entities;
using Capstone.WebUI.Models;
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

        public ActionResult StoreProfile(int bvLocationId)
        {
            var db = new ApplicationDbContext();
            var loc = lRepo.GetBvLocation(bvLocationId);
            List<PartnershipNight> events = (from e in db.PartnershipNights.Include("BvLocation").Include("Charity")
                                         where e.BVLocation.BvLocationId == bvLocationId
                                         select e).ToList<PartnershipNight>();
            if (events.Count > 0)
            {
                TempData["message"] = string.Format("Profile for Restaurant Number:  {0}", loc.BvStoreNum);

                return View(events);
            }              
            else
            {
                TempData["message"] = string.Format("Restaurant {0} has no Partnership Nights Yet", loc.BvStoreNum);

                return RedirectToAction("Index", "Profiles");
            }
                
        }
    }
}