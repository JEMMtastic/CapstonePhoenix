using Capstone.Domain.Abstract;
using Capstone.Domain.Concrete;
using Capstone.Domain.Entities;
using Capstone.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.WebUI.Controllers
{
    public class CRUDController : Controller
    {
        

        CharityRepository charRepo;
        PartnershipNightRepository pnRepo;
        UserInterface uRepo;
        BvLocationInterface lRepo;


        public CRUDController()
        {
            charRepo = new CharityRepository();
            pnRepo = new PartnershipNightRepository();
            uRepo = new UserRepository();
            lRepo = new BvLocationRepository();
        }

         // Use this for dependency injection
        public CRUDController(BvLocationRepository iLoc, UserInterface iUser, BvLocationInterface iLocation)
        {
            lRepo = iLoc;
            uRepo = iUser;
            lRepo = iLocation;
        }


        //Charity
        //***********************************
        public ActionResult CharityIndex()
        {
            List<Charity> charities = charRepo.GetCharities().ToList<Charity>();

            return View(charities);
        }

        public ActionResult CharityCreate()
        {
            return View("CharityEdit", new Charity());
        }

        public ActionResult CharityEdit(int charityId)
        {
            // Get the correct charity
            Charity charity = charRepo.GetCharities().FirstOrDefault(ch => ch.CharityId == charityId);
            
            return View(charity);
        }

        [HttpPost]
        public ActionResult CharityEdit(Charity charity)
        {
            if (ModelState.IsValid)
            {
                // Save the changes to the partnership night 
                charRepo.EditCharity(charity);
                TempData["message"] = string.Format("{0} has been saved", charity.Name);
                return RedirectToAction("CharityIndex");
            }
            else
            {
                // there is something wrong with the data values
                return View(charity);
            }
        }

        public ActionResult CharityDelete(int charityId)
        {
            Charity deletedCharity = charRepo.DeleteCharity(charityId);
            if (deletedCharity != null)
            {
                TempData["message"] = string.Format("{0} was deleted",
                deletedCharity.Name);
            }
            return RedirectToAction("CharityIndex");
        }









        //Location
        //***********************************
        public ActionResult LocationIndex()
        {
            //need to get a list of all users
            var db = new CapstoneDbContext();
            List<BvLocation> locations = (from l in db.BvLocations
                                select l).ToList<BvLocation>();
            return View(locations);
        }

        public ActionResult LocationEdit(int bvLocationId)
        {
            BvLocation l = lRepo.GetBvLocation(bvLocationId);
            return View(l);
        }
        [HttpPost]
        public ActionResult LocationEdit(BvLocation l)
        {
            if (ModelState.IsValid)
            {
                lRepo.SaveBvLocation(l);
                TempData["message"] = string.Format("{0} has been saved", l.BvLocationId);
                return RedirectToAction("LocationIndex");
            }
            else
            {
                return View(l);
            }
        }
        public ViewResult LocationCreate()
        {
            return View("LocationEdit", new BvLocation());
        }

        [HttpPost]
        public ActionResult LocationDelete(int bvLocationId)
        {
            BvLocation deletedLoc = lRepo.DeleteBvLocation(bvLocationId);
            if (deletedLoc != null)
            {
                TempData["message"] = string.Format("{0} was deleted", deletedLoc.BvStoreNum);
            }
            return RedirectToAction("LocationIndex");
        }







        //PartnershipNight
        //***********************************
        public ActionResult PartnershipNightIndex()
        {
            List<PartnershipNight> pnightEvents = pnRepo.GetPartnershipNights().ToList<PartnershipNight>();
            
            return View(pnightEvents);
        }

        public ViewResult PartnershipNightCreate()
        {
            var vmodel = new PNightEditViewModel();

            vmodel.Date = DateTime.Now;

            //Set List variables to contain lists of child objects for selection in the view
            vmodel.Charities = charRepo.GetCharities().ToList<Charity>();
            vmodel.Locations = lRepo.GetBvLocations().ToList<BvLocation>();
            TempData["Title"] = "Add New Partnership Night";

            return View("PartnershipNightEdit", vmodel);
        }

        public ActionResult PartnershipNightEdit(int? partnershipNightId)
        {
            if (partnershipNightId != null)
            {
                TempData["Title"] = "Edit";

                // Get the correct partnership night, and create a view model to store values in
                PartnershipNight pnight = pnRepo.GetPartnershipNights().FirstOrDefault(pn => pn.PartnershipNightId == partnershipNightId);
                PNightEditViewModel vmodel = new PNightEditViewModel();

                //Set view model to corresponding partnership night values
                vmodel.PartnershipNightId = pnight.PartnershipNightId;
                vmodel.Date = pnight.StartDate;
                vmodel.CharityId = pnight.Charity.CharityId;
                vmodel.BVLocationId = pnight.BVLocation.BvLocationId;
                vmodel.CheckRequestId = pnight.CheckRequestId;
                vmodel.Comments = pnight.Comments;
                vmodel.CheckRequestFinished = pnight.CheckRequestFinished;
                vmodel.BeforeTheEventFinished = pnight.BeforeTheEventFinished;
                vmodel.AfterTheEventFinished = pnight.AfterTheEventFinished;

                //Set List variables to contain lists of child objects for selection in the view
                vmodel.Charities = charRepo.GetCharities().ToList<Charity>();
                vmodel.Locations = lRepo.GetBvLocations().ToList<BvLocation>();

                //Set session variables to contain lists of child objects for selection in the view
                //Session["charities"] = charRepo.GetCharities().ToList<Charity>();
                //Session["bvlocations"] = lRepo.GetBvLocations().ToList<BvLocation>();

                return View(vmodel);
            }
            else
            {
                return View("PartnershipNightIndex");
            }
        }

        [HttpPost]
        public ActionResult PartnershipNightEdit(PNightEditViewModel vmodel)
        {
            //PartnershipNight pnight = pnRepo.GetPartnershipNights().FirstOrDefault<PartnershipNight>(pn => pn.PartnershipNightId)

            if (ModelState.IsValid)
            {
                // Transfer view model values to a partnership night object
                PartnershipNight pnight = new PartnershipNight();
                pnight.PartnershipNightId = vmodel.PartnershipNightId;
                pnight.StartDate = vmodel.Date;
                pnight.Comments = vmodel.Comments;
                pnight.CheckRequestId = vmodel.CheckRequestId;
                pnight.CheckRequestFinished = vmodel.CheckRequestFinished;
                pnight.BeforeTheEventFinished = vmodel.BeforeTheEventFinished;
                pnight.AfterTheEventFinished = vmodel.AfterTheEventFinished;

                // Store the correct child objects 
                pnight.Charity = charRepo.GetCharities().FirstOrDefault(ch => ch.CharityId == vmodel.CharityId);
                pnight.BVLocation = lRepo.GetBvLocations().FirstOrDefault(bvl => bvl.BvLocationId == vmodel.BVLocationId);
                
                // Save the changes to the partnership night 
                pnRepo.UpdatePartnershipNight(pnight);
                TempData["message"] = string.Format("Partnership Night for BV Location {0}, {1} has been saved", pnight.StartDate.ToShortDateString(), pnight.BVLocation.BvStoreNum);
                return RedirectToAction("PartnershipNightIndex");
            }
            else
            {
                // there is something wrong with the data values
                return View(vmodel);
            }
        }

        [HttpPost]
        public ActionResult PartnershipNightDelete(int pnightId)
        {
            PartnershipNight deletedPNight = pnRepo.DeletePartnershipNight(pnightId);
            if (deletedPNight != null)
            {
                TempData["message"] = string.Format("Event on {0} was deleted",
                deletedPNight.StartDate.ToShortDateString());
            }
            return RedirectToAction("PartnershipNightIndex");
        }








        //User
        //***********************************
        public ActionResult UserIndex()
        {
            //need to get a list of all users
            var db = new CapstoneDbContext();
            List<User> users = (from u in db.Users.Include("BvLocation")
                                select u).ToList<User>();

               
            //TODO:  add functionality to get users by restaurant or city?
            return View(users);
        }

        public ActionResult UserEdit(int userId)
        {
            User u = uRepo.GetUser(userId);
            return View(u);
        }
        [HttpPost]
        public ActionResult UserEdit(User u)
        {
            if (ModelState.IsValid)
            {
                BvLocation l = lRepo.GetBvLocation(u.BvLocation.BvStoreNum);
                if (l != null)
                {
                    u.BvLocation = l;
                    uRepo.SaveUser(u);
                    TempData["message"] = string.Format("{0} has been saved", u.UserFName + " " + u.UserLName);
                }
                else
                {
                    TempData["message"] = string.Format("{0} is not a valid Restaurant", u.BvLocation.BvStoreNum);
                }
                return RedirectToAction("UserIndex");
            }
            else
            {
                return View(u);
            }
        }
        public ViewResult UserCreate()
        {
            return View("UserEdit", new User());
        }

        [HttpPost]
        public ActionResult UserDelete(int userId)
        {
            User deletedUser = uRepo.DeleteUser(userId);
            if (deletedUser != null)
            {
                TempData["message"] = string.Format("{0} was deleted", deletedUser.UserFName + deletedUser.UserLName);
            }
            return RedirectToAction("UserIndex");
        }




























    }//end of class

}//end of namespace
