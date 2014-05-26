using Capstone.WebUI.Domain.Concrete;
using Capstone.WebUI.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone.WebUI.Domain.Entities;
using Capstone.WebUI.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

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

        public ViewResult Index()
        {
            
           // //data to get db up and running -- delete when done
           // //add a location
           // BvLocation loc1 = new BvLocation { Address = "333 N Main St", City = "BobVille", BvStoreNum = "BV99", Phone = "839-839-8393", Zip = "88898" };
           // lRepo.AddBvLocation(loc1);
           // //add a user
           // User u1 = new User { Username = "turtles", FName = "Bob", LName = "Bobberson", AccessLevel = 1, BvLocation = loc1, Password = "bobshere", UserEmail = "bob@bob.com", PhoneNumber = "541-389-8293" };
           // uRepo.AddUser(u1);
           //// add a charity
           // Charity c1 = new Charity { Address = "8939 S Seventh", City = "CharityVille", FederalTaxId = "893018XS", Name = "HopeForBob", Phone = "893-829-8393", TypeOfCharity = "Helpful", Zip = "83928" };
           // cRepo.AddCharity(c1);
           // //add a partnership night
           // PartnershipNight pn1 = new PartnershipNight { AfterTheEventFinished = false, BeforeTheEventFinished = true, BVLocation = loc1, Charity = c1, CheckRequestFinished = false, Comments = "blah blah", Date = DateTime.Parse("05/30/2014") };
           // pnRepo.AddPartnershipNight(pn1);
           // //Form data will be here when it is finished:
       
            /*
            //testing
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";*/
            return View();
        }
/*
        [HttpPost]
        public ActionResult Index()
        {
            return RedirectToAction("Login", "Account");
        }
*/
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
                    var db = new OldCapstoneDbContext();
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
            return View();
        }

        public JsonResult GetEvents(double start, double end)
        {
            var fromDate = ConvertFromUnixTimestamp(start);
            var toDate = ConvertFromUnixTimestamp(end);
            
            //Get the events
            var db = new OldCapstoneDbContext();
            var partnershipNights = (from e in db.PartnershipNights.Include("BvLocation").Include("Charity")
                                         where e.StartDate >= fromDate && e.StartDate <= toDate
                                         select e).ToList<PartnershipNight>();
            var events = new List<Event>();
            foreach (var p in partnershipNights)
            {
                string jsonStart = JsonConvert.SerializeObject(p.StartDate, new IsoDateTimeConverter());
                string jsonEnd = JsonConvert.SerializeObject(p.EndDate, new IsoDateTimeConverter());
                events.Add(new Event { Id = p.BVLocation.BvStoreNum, Title = p.Charity.Name, Start = jsonStart, End = jsonEnd});
            }
            var rows = events.ToArray();
            return Json(rows, JsonRequestBehavior.AllowGet);
        }

        private static DateTime ConvertFromUnixTimestamp(double timestamp)
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return origin.AddSeconds(timestamp);
        }

        public ActionResult Documents()
        {
            return View();
        }

    }
}
