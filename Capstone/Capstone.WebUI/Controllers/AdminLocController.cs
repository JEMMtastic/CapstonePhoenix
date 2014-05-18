using Capstone.Domain.Concrete;
using Capstone.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone.Domain.Abstract;

namespace Capstone.WebUI.Controllers
{
    public class AdminLocController : Controller
    {
        BvLocationInterface lRepo;

        // The default constructor is called by the framework
        public AdminLocController()
        {
            lRepo = new BvLocationRepository();
        }

        // Use this for dependency injection
        public AdminLocController(BvLocationRepository iLoc)
        {
            lRepo = iLoc;
        }

        public ActionResult AdminLocIndex()
        {
            //need to get a list of all users
            var db = new CapstoneDbContext();
            List<BvLocation> locations = (from l in db.BvLocations
                                select l).ToList<BvLocation>();
            return View(locations);
        }

        public ActionResult EditLoc(int bvLocationId)
        {
            BvLocation l = lRepo.GetBvLocation(bvLocationId);
            return View(l);
        }
        [HttpPost]
        public ActionResult EditLoc(BvLocation l)
        {
            if (ModelState.IsValid)
            {
                lRepo.SaveBvLocation(l);
                TempData["message"] = string.Format("{0} has been saved", l.BvLocationId);
                return RedirectToAction("AdminLocIndex");
            }
            else
            {
                return View(l);
            }
        }
        public ViewResult CreateLoc()
        {
            return View("EditLoc", new BvLocation());
        }

        [HttpPost]
        public ActionResult DeleteLoc(int bvLocationId)
        {
            BvLocation deletedLoc = lRepo.DeleteBvLocation(bvLocationId);
            if (deletedLoc != null)
            {
                TempData["message"] = string.Format("{0} was deleted", deletedLoc.BvStoreNum);
            }
            return RedirectToAction("AdminLocIndex");
        }

    }
}
