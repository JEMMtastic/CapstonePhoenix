using Capstone.Domain.Concrete;
using Capstone.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone.WebUI.Models;

namespace Capstone.WebUI.Controllers
{
    public class AdminPartnershipNightController : Controller
    {
        //
        // GET: /AdminPartnershipNight/
        PartnershipNightRepository pnRepo;
        CharityRepository charRepo; 
        BvLocationRepository bvlocRepo;
        
        public AdminPartnershipNightController()
        {
            pnRepo = new PartnershipNightRepository();
            charRepo = new CharityRepository();
            bvlocRepo = new BvLocationRepository();
        }

        public ActionResult Index()
        {
            List<PartnershipNight> pnightEvents = pnRepo.GetPartnershipNights().ToList<PartnershipNight>();
            
            return View(pnightEvents);
        }

        public ViewResult Create()
        {
            return View("Edit", new PNightEditViewModel());
        }

        public ActionResult Edit(int partnershipNightId)
        {
            // Get the correct partnership night, and create a view model to store values in
            PartnershipNight pnight = pnRepo.GetPartnershipNights().FirstOrDefault(pn => pn.PartnershipNightId == partnershipNightId);
            PNightEditViewModel vmodel = new PNightEditViewModel();

            //Set view model to corresponding partnership night values
            vmodel.PartnershipNightId = pnight.PartnershipNightId;
            vmodel.Date = pnight.Date;
            vmodel.CharityId = pnight.Charity.CharityId;
            vmodel.BVLocationId = pnight.BVLocation.BvLocationId;
            vmodel.CheckRequestId = pnight.CheckRequestId;
            vmodel.Comments = pnight.Comments;
            vmodel.CheckRequestFinished = pnight.CheckRequestFinished;
            vmodel.BeforeTheEventFinished = pnight.BeforeTheEventFinished;
            vmodel.AfterTheEventFinished = pnight.AfterTheEventFinished;

            //Set List variables to contain lists of child objects for selection in the view
            vmodel.Charities = charRepo.GetCharities().ToList<Charity>();
            vmodel.Locations = bvlocRepo.GetBvLocations().ToList<BvLocation>();

            //Set session variables to contain lists of child objects for selection in the view
            //Session["charities"] = charRepo.GetCharities().ToList<Charity>();
            //Session["bvlocations"] = bvlocRepo.GetBvLocations().ToList<BvLocation>();

            return View(vmodel);
        }

        [HttpPost]
        public ActionResult Edit(PNightEditViewModel vmodel)
        {
            //PartnershipNight pnight = pnRepo.GetPartnershipNights().FirstOrDefault<PartnershipNight>(pn => pn.PartnershipNightId)

            if (ModelState.IsValid)
            {
                // Transfer view model values to a partnership night object
                PartnershipNight pnight = new PartnershipNight();
                pnight.PartnershipNightId = vmodel.PartnershipNightId;
                pnight.Date = vmodel.Date;
                pnight.Comments = vmodel.Comments;
                pnight.CheckRequestId = vmodel.CheckRequestId;
                pnight.CheckRequestFinished = vmodel.CheckRequestFinished;
                pnight.BeforeTheEventFinished = vmodel.BeforeTheEventFinished;
                pnight.AfterTheEventFinished = vmodel.AfterTheEventFinished;

                // Store the correct child objects 
                pnight.Charity = charRepo.GetCharities().FirstOrDefault(ch => ch.CharityId == vmodel.CharityId);
                pnight.BVLocation = bvlocRepo.GetBvLocations().FirstOrDefault(bvl => bvl.BvLocationId == vmodel.BVLocationId);
                
                // Save the changes to the partnership night 
                pnRepo.UpdatePartnershipNight(pnight);
                TempData["message"] = string.Format("Partnership Night for BV Location {0}, {1} has been saved", pnight.Date.ToShortDateString(), pnight.BVLocation.BvStoreNum);
                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values
                return View(vmodel);
            }
        }

        [HttpPost]
        public ActionResult Delete(int pnightId)
        {
            PartnershipNight deletedPNight = pnRepo.DeletePartnershipNight(pnightId);
            if (deletedPNight != null)
            {
                TempData["message"] = string.Format("Event on {0} was deleted",
                deletedPNight.Date.ToShortDateString());
            }
            return RedirectToAction("Index");
        }
    }
}
