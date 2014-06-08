using Capstone.WebUI.Domain.Abstract;
using Capstone.WebUI.Domain.Concrete;
using Capstone.WebUI.Domain.Entities;
using Capstone.WebUI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        [Authorize(Roles = "Admin")]
        public ActionResult CharityIndex()
        {
            List<Charity> charities = charRepo.GetCharities().ToList<Charity>();

            return View(charities);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult CharityCreate()
        {
            return View("CharityEdit", new Charity());
        }

        [Authorize(Roles = "Admin")]
        public ActionResult CharityEdit(int charityId)
        {
            // Get the correct charity
            Charity charity = charRepo.GetCharities().FirstOrDefault(ch => ch.CharityId == charityId);
            
            return View(charity);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
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
            TempData["Title"] = "Edit BV Location";
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
            TempData["Title"] = "Add a new BV Location"; 
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
            var pNt = new PNightEditViewModel();

            //vmodel.StartDate = DateTime.Now;

            //Set List variables to contain lists of child objects for selection in the view
            //vmodel.Charities = charRepo.GetCharities().ToList<Charity>();
            //vmodel.Locations = lRepo.GetBvLocations().ToList<BvLocation>();
            TempData["Title"] = "Add New Partnership Night";

            pNt.Locations = lRepo.GetBvLocations().ToList<BvLocation>();
            pNt.Charities = charRepo.GetCharities().ToList<Charity>();

            return View("PartnershipNightEdit", pNt);
        }

        public ActionResult PartnershipNightEdit(int partnershipNightId)
        {
                TempData["Title"] = "Edit";

                // Get the correct partnership night, and create a view model to store values in
                PartnershipNight pnight = pnRepo.GetPartnershipNightById(partnershipNightId);
                PNightEditViewModel temp = new PNightEditViewModel();
                temp.PartnershipNight = pnight;
                temp.Locations = lRepo.GetBvLocations().ToList<BvLocation>();
                temp.Charities = charRepo.GetCharities().ToList<Charity>();

                return View(temp);
        }

        [HttpPost]
        public ActionResult PartnershipNightEdit(PNightEditViewModel pn)
        {
            var pnEvent = new PartnershipNight();
            pnEvent.PartnershipNightId = pn.PartnershipNight.PartnershipNightId;
            pnEvent.EndDate = pn.PartnershipNight.EndDate;
            pnEvent.StartDate = pn.PartnershipNight.StartDate;
            pnEvent.AfterTheEventFinished = pn.PartnershipNight.AfterTheEventFinished;
            pnEvent.AfterTheEventFinished = pn.PartnershipNight.BeforeTheEventFinished;
            pnEvent.CheckRequestFinished = pn.PartnershipNight.CheckRequestFinished;
            pnEvent.CheckRequestId= pn.PartnershipNight.CheckRequestId;
            pnEvent.Comments = pn.PartnershipNight.Comments;          
            pnEvent.BVLocation = lRepo.GetBvLocation(pn.PartnershipNight.PartnershipNightId);
            pnEvent.Charity = charRepo.GetCharityById(pn.PartnershipNight.Charity.CharityId);
            
            if (pnEvent != null && pnEvent.BVLocation != null && pnEvent.Charity != null)
            {
                pnRepo.UpdatePartnershipNight(pnEvent);

                return RedirectToAction("PartnershipNightIndex");
            }
            else        
                return View();   
        }

        [HttpPost]
        public ActionResult PartnershipNightDelete(int partnershipNightId)
        {
            PartnershipNight deletedPNight = pnRepo.DeletePartnershipNight(partnershipNightId);
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


        //[Authorize(Roles = "Admin")]
        public ActionResult UserIndex()
        {
            var db = new ApplicationDbContext();

            //this syntax not working here
            //from pnight in db.PartnershipNights.Include("Charity").Include("BVLocation")
            //        where pnight.PartnershipNightId == partnershipNightId
            //        select pnight).FirstOrDefault()

            List<ApplicationUser> users = db.Users.ToList();

           

            List<ApplicationUserVM> users2 = new List<ApplicationUserVM>();
            foreach (ApplicationUser a in users)
            {
                ApplicationUserVM temp = new ApplicationUserVM(){};
                temp.AUser = a;
                users2.Add(temp);
            }

            return View(users);
        }


        //[Authorize(Roles = "Admin")]
        //[ValidateAntiForgeryToken]
        public ActionResult UserEdit(string id)
        {
            var Db = new ApplicationDbContext();
            var user = Db.Users.First(u => u.Id == id);
            var model = new EditUserViewModel(user);
            return View(model);
        }


        [HttpPost]
        //[Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UserEdit(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var Db = new ApplicationDbContext();
                var user = Db.Users.First(u => u.UserName == model.UserName);
                if (user != null)
                {
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.Email = model.Email;
                    user.Role = model.Role;
                    user.BvLocation = Db.BvLocations.Find(model.BvLocationId);

                    var rm = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));

                    if (rm.RoleExists("Admin") && rm.RoleExists("User"))
                    {
                        var idManager = new IdentityManager();
                        if (user.Role == "Admin")
                        {
                            idManager.AddUserToRole(user.Id, "Admin");
                        }
                        if (user.Role == "User")
                        {
                            idManager.AddUserToRole(user.Id, "User");
                        }
                    }


                    Db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                    await Db.SaveChangesAsync();
                }
                return RedirectToAction("UserIndex");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }


        public ViewResult UserCreate()
        {
            return View("UserEdit", new EditUserViewModel());
        }

        
        public ActionResult UserDelete(string id = null)
        {
            var Db = new ApplicationDbContext();
            //var user = Db.Users.First(u => u.Id == id);
            //var model = new EditUserViewModel(user);
            //if (user == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(model);


            ApplicationUser deletedUser = Db.Users.First(u => u.Id == id);

            if (deletedUser != null)
            {
                Db.Users.Remove(deletedUser);
                Db.SaveChanges();
                TempData["message"] = string.Format("{0} was deleted", deletedUser.UserName);
            }
            return RedirectToAction("UserIndex");
        }

























    }//end of class

}//end of namespace
