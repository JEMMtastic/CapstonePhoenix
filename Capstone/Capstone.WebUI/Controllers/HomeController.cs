using Capstone.Domain.Concrete;
using Capstone.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone.Domain.Entities;

namespace Capstone.WebUI.Controllers
{
    public class HomeController : Controller
    {
        PartnershipNightInterface pnRepo;
        UserInterface uRepo;
        CharityInterface cRepo;
        BvLocationInterface lRepo;
        FormInterface fRepo;

        // The default constructor is called by the framework
        public HomeController()
        {
            uRepo = new UserRepository();
            pnRepo = new PartnershipNightRepository();
            cRepo = new CharityRepository();
            lRepo = new BvLocationRepository();
            fRepo = new FormRepository();
        }

        // Use this for dependency injection
        public HomeController(UserInterface iUser, PartnershipNightInterface iPn, CharityInterface iChar, BvLocationInterface iLoc, FormInterface iForm)
        {
            uRepo = iUser;
            pnRepo = iPn;
            cRepo = iChar;
            lRepo = iLoc;
            fRepo = iForm;
        }

        public ActionResult Index()
        {
            /*
            //data to get db up and running -- delete when done
            //add a location
            BvLocation loc1 = new BvLocation { Address = "333 N Main St", City = "BobVille", BvStoreNum = "BV99", Phone = "839-839-8393", Zip = "88898" };
            lRepo.AddBvLocation(loc1);
            //add a user
            User u1 = new User { Username = "turtles", UserFName = "Bob", UserLName = "Bobberson", AccessLevel = 1, BvLocation = loc1, Password = "bobshere", UserEmail = "bob@bob.com", PhoneNumber = "541-389-8293" };
            uRepo.AddUser(u1);
            //add a charity
            Charity c1 = new Charity { Address = "8939 S Seventh", City = "CharityVille", FederalTaxId = "893018XS", Name = "HopeForBob", Phone = "893-829-8393", TypeOfCharity = "Helpful", Zip = "83928" };
            cRepo.AddCharity(c1);
            //add a partnership night
            PartnershipNight pn1 = new PartnershipNight { AfterTheEventFinished = false, BeforeTheEventFinished = true, BVLocation = loc1, Charity = c1, CheckRequestFinished = false, Comments = "blah blah", Date = DateTime.Parse("05/30/2014") };
            pnRepo.AddPartnershipNight(pn1);
            //Form data will be here when it is finished:
       
            //testing
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";*/
            return View();
        }

        public ActionResult About()
        {
            //testing
            ViewBag.Message = "Your app description page.";
            return View();
        }

        public ActionResult Calculator()
        {
            return View();
        }

        public ActionResult Contact()
        {
            //testing
            ViewBag.Message = "Your contact page.";
            return View();
        }

        public ViewResult Empty()
        {
            return View();
        }

        //need to pass a user to this method once the login stuff is worked out
        public ViewResult Calendar()
        {
            User u = uRepo.GetUser(12);
            if (u != null)
            {
                BvLocation bvLocation = lRepo.GetBvLocation(u.BvLocation.BvLocationId);
                if (bvLocation != null)
                {
                    var db = new CapstoneDbContext();
                    bvLocation.PartnershipNights = lRepo.GetPartnershipNights(bvLocation);
                    if (bvLocation.PartnershipNights.Count != 0)
                        return View(bvLocation);
                    else return View();
                }
                else return View();
            }
            else
                return View();
            
        }

        public ActionResult FullCalendar()
        {
            IList<PartnershipNight> events = new List<PartnershipNight>();
            var db = new CapstoneDbContext();
            events = (from e in db.PartnershipNights select e).ToList();
            return Json(events, JsonRequestBehavior.AllowGet);
        }

       private long ToUnixTimespan(DateTime date)
       {
           TimeSpan tspan = date.ToUniversalTime().Subtract(
            new DateTime(1970, 1, 1, 0, 0, 0));

           return (long)Math.Truncate(tspan.TotalSeconds);
       }

       

        public ActionResult Documents()
        {
            return View();
        }

    }
}
