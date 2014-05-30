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
            var db = new ApplicationDbContext();
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
            var pNt = new PartnershipNightVM();

            //vmodel.StartDate = DateTime.Now;

            //Set List variables to contain lists of child objects for selection in the view
            //vmodel.Charities = charRepo.GetCharities().ToList<Charity>();
            //vmodel.Locations = lRepo.GetBvLocations().ToList<BvLocation>();
            TempData["Title"] = "Add New Partnership Night";

            pNt.BvLocations = lRepo.GetBvLocations().ToList<BvLocation>();
            pNt.Charities = charRepo.GetCharities().ToList<Charity>();

            return View("PartnershipNightEdit", pNt);
        }

        public ActionResult PartnershipNightEdit(int partnershipNightId)
        {
                TempData["Title"] = "Edit";

                // Get the correct partnership night, and create a view model to store values in
                PartnershipNight pnight = pnRepo.GetPartnershipNightById(partnershipNightId);
                PartnershipNightVM temp = new PartnershipNightVM() {
                    AfterTheEventFinished = pnight.AfterTheEventFinished,
                    BeforeTheEventFinished = pnight.BeforeTheEventFinished,
                    CheckRequestFinished = pnight.CheckRequestFinished,
                    BVLocation = pnight.BVLocation,
                    Charity = pnight.Charity,
                    StartDate = pnight.StartDate,
                    EndDate = pnight.EndDate,
                    Comments = pnight.Comments,
                    CheckRequestId = pnight.CheckRequestId,
                    PartnershipNightId = pnight.PartnershipNightId
                };

                temp.BvLocations = lRepo.GetBvLocations().ToList<BvLocation>();
                temp.Charities = charRepo.GetCharities().ToList<Charity>();

                //PNightEditViewModel vModel = new PNightEditViewModel();

                ////Set view model to corresponding partnership night values
                //vModel.PartnershipNight = pnight;

                //Set List variables to contain lists of child objects for selection in the view
                //vModel.Charities = charRepo.GetCharities().ToList<Charity>();
                //vModel.Locations = lRepo.GetBvLocations().ToList<BvLocation>();

                return View(temp);
        }

        [HttpPost]
        public ActionResult PartnershipNightEdit(PartnershipNightVM partnershipNightVM)
        {
            partnershipNightVM.BVLocation = lRepo.GetBvLocations().FirstOrDefault(bvl => bvl.BvLocationId == partnershipNightVM.BvLocationId);
            partnershipNightVM.Charity = charRepo.GetCharities().FirstOrDefault(char1 => char1.CharityId == partnershipNightVM.CharityId);

            if (ModelState.IsValid)
            {
                

                pnRepo.UpdatePartnershipNight(partnershipNightVM);

                return RedirectToAction("PartnershipNightIndex");
            }
               
            
            return View();
                
                
                
           
            //PartnershipNight pnight = pnRepo.GetPartnershipNights().FirstOrDefault<PartnershipNight>(pn => pn.PartnershipNightId)
            //if (ModelState.IsValid)
            //{
            //    // Transfer view model values to a partnership night object
            //    PartnershipNight pnight = new PartnershipNight();

            //    // Store the correct child objects 
            //    pnight.Charity = charRepo.GetCharityById(partnershipNight.Charity.CharityId);
            //    pnight.BVLocation = lRepo.GetBvLocation(partnershipNight.BVLocation.BvLocationId);
                
            //    // Save the changes to the partnership night 
            //    pnRepo.UpdatePartnershipNight(pnight);
            //    TempData["message"] = string.Format("Partnership Night for BV Location {0}, {1} has been saved", pnight.StartDate.ToShortDateString(), pnight.BVLocation.BvStoreNum);
            //    return RedirectToAction("PartnershipNightIndex");
            //}
            //else
            //{
            //    // there is something wrong with the data values
            //    return View();
            //}
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






        //TEMPORARILY REMOVING WHILE WE GET IDENTITY TO HANDLE USER CRUD

        //User
        //***********************************
/*        public ActionResult UserIndex()
        {
            //need to get a list of all users
            var db = new ApplicationDbContext();
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
                    TempData["message"] = string.Format("{0} has been saved", u.FName + " " + u.LName);
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
                TempData["message"] = string.Format("{0} was deleted", deletedUser.FName + deletedUser.LName);
            }
            return RedirectToAction("UserIndex");
        }

*/


























    }//end of class

}//end of namespace
