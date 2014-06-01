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
            //ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            /*
             * PLEASE DO NOT DELETE
             * 
             * NEW VERSION OF SEEDING DB: GOES IN CONFIGURATION.CS IN MIGRATIONS FOLDER. 
             * JUST PUTTING IT HERE FOR SAFE-KEEPING BECAUSE WE OFTEN DELETE THE MIGRATIONS FOLDER
            
             //data to get db up and running
            //add a location
            context.BvLocations.AddOrUpdate(
                l => l.BvLocationId,
                    new BvLocation { BvLocationId = 1, Address = "333 N Main St", City = "Bobville", BvStoreNum = "BV99", Phone = "839-839-8393", Zip = "88898", State = "CA" }
                );
            //BvLocation loc1 = new BvLocation { Address = "333 N Main St", City = "BobVille", BvStoreNum = "BV99", Phone = "839-839-8393", Zip = "88898" };
            //lRepo.AddBvLocation(loc1);

            //add a user
            context.Users.AddOrUpdate(
                  u => u.UserName,
                  new ApplicationUser { UserName = "turtles", PasswordHash = "1234567".GetHashCode().ToString(), Email = "me2@you.com", EmailConfirmed = true, BvLocation = context.BvLocations.Find(1), FirstName = "Moo", LastName = "Cow" },
                  new ApplicationUser { UserName = "User2", PasswordHash = "password123".GetHashCode().ToString(), Email = "me@you.com", EmailConfirmed = true, BvLocation = context.BvLocations.Find(1), FirstName = "Joe", LastName = "Joebert" }
                );
            //CUser u1 = new CUser { Username = "turtles", UserFName = "Bob", UserLName = "Bobberson", AccessLevel = 1, BvLocation = loc1, Password = "bobshere", UserEmail = "bob@bob.com", PhoneNumber = "541-389-8293" };
            //uRepo.AddUser(u1);

            // add a charity
            context.Charities.AddOrUpdate(
                c => c.CharityId,
                new Charity { CharityId = 1, Address = "8939 S Seventh", City = "CharityVille", FederalTaxId = "893018X", Name = "HopeForBob", Phone = "893-829-8393", TypeOfCharity = "Helpful", Zip = "83928", CharityContactNm = "Bob", State = "TX" }
                );
            //Charity c1 = new Charity { Address = "8939 S Seventh", City = "CharityVille", FederalTaxId = "893018XS", Name = "HopeForBob", Phone = "893-829-8393", TypeOfCharity = "Helpful", Zip = "83928" };
            //cRepo.AddCharity(c1);

            //add a partnership night
            context.PartnershipNights.AddOrUpdate(
                    pn => pn.PartnershipNightId,
                    new PartnershipNight { PartnershipNightId = 1, AfterTheEventFinished = false, BeforeTheEventFinished = true, BVLocation = context.BvLocations.Find(1), Charity = context.Charities.Find(1), CheckRequestFinished = false, Comments = "blah blah", StartDate = DateTime.Parse("05/30/2014"), EndDate = DateTime.Parse("05/30/2014"), CheckRequestId = 1 }
                );
            //PartnershipNight pn1 = new PartnershipNight { AfterTheEventFinished = false, BeforeTheEventFinished = true, BVLocation = loc1, Charity = c1, CheckRequestFinished = false, Comments = "blah blah", Date = DateTime.Parse("05/30/2014") };
            //pnRepo.AddPartnershipNight(pn1);

            //add a form
            context.Forms.AddOrUpdate(
                f => f.FormId,
                new Form { FormId = 1, ActualAverageCheck_45 = 345, ActualAverageCheck_56 = 45, ActualAverageCheck_67 = 4574, ActualAverageCheck_78 = 23, ActualAverageCheck_89 = 56, ActualAverageCheckTotal = 7000, ActualGuestCount_45 = 34, ActualGuestCount_56 = 78, ActualGuestCount_67 = 99, ActualGuestCount_78 = 2, ActualGuestCount_89 = 10, ActualGuestCountTotal = 300, ActualSales_45 = 34, ActualSales_56 = 77, ActualSales_67 = 12, ActualSales_78 = 354, ActualSales_89 = 58, ActualSalesTotal = 1000, Average_45_GuestCount = 23, Average_45_Sales = 700, Average_56_GuestCount = 90, Average_56_Sales = 57, Average_67_GuestCount = 42, Average_67_Sales = 66, Average_78_GuestCount = 87, Average_78_Sales = 44, Average_89_GuestCount = 31, Average_89_Sales = 46, Average_AdjustedSalesTotal = 844, Average_GuestCountTotal = 70, ContactName = "Silly Robinson", NewPartner = false, Notes = "This form is long", PosiDonations = 25.6M, Purpose = "To Wreak Havoc", DateOfPartnership = DateTime.Parse("05/21/2014"), Donations10PercentOfSalesToGL7700 = 345, DonationsTakenOnThePosiRegisterCodeToGL2005 = 3453, FederalTaxID = "35663414141", GLCode2005 = "G443", GLCode7700 = "G345", GuestCountContribution_3WeekAverage = 3754, GuestCountContribution_ActualNumber = 546, GuestCountContribution_GCCountribution = 45, HostingRestaurant = "Smoodle's Noodles", LastWeekAverageCheck_45 = 3453, LastWeekAverageCheck_56 = 345, LastWeekAverageCheck_67 = 222, LastWeekAverageCheck_78 = 777, LastWeekAverageCheck_89 = 999, LastWeekAverageCheckTotal = 9999, MailPartnershipCheckToBV = true, NameOnCheck = "Jerry Jehooble", OrganizationMailingAddress = "111 Some St. Nowhere, OR", OrganizationMailingCity = "Nowhere", OrganizationMailingState = "OR", OrganizationMailingZip = "97400", OrganizationPhone = "999-999-9999", SalesContribution_3WeekAverage = 463, SalesContribution_Actual = 575, SalesContribution_Difference = 99, SalesContribution_Donation = 243, SalesContribution_SalesContribution = 333, Scenario1_EstimatedDonation = 535.4M, Scenario1_EstimatedGuestCount = 20, Scenario1_GuestCount = 50, Scenario1_TargetedGuestCount = 20, Scenario1_ThreeWeekAverageGuestCount = 300, Scenario2_EstimatedDonation = 43, Scenario2_EstimatedGuestCount = 77, Scenario2_GuestCount = 99, Scenario2_TargetedGuestCount = 200, Scenario2_ThreeWeekAverageGuestCount = 900, TenPercentDonation = 20, TotalDonation = 200, Week1_45_AdjustedSales = 54, Week1_45_GuestCount = 67, Week1_56_AdjustedSales = 88, Week1_56_GuestCount = 99, Week1_67_AdjustedSales = 100, Week1_67_GuestCount = 30, Week1_78_AdjustedSales = 52, Week1_78_GuestCount = 88, Week1_89_AdjustedSales = 456.5M, Week1_89_GuestCount = 10, Week1_AdjustedSalesTotal = 100, Week1_GuestCountTotal = 200, Week1Date = DateTime.Parse("05/21/2013"), Week2_45_AdjustedSales = 34M, Week2_45_GuestCount = 70, Week2_56_AdjustedSales = 456M, Week2_56_GuestCount = 456, Week2_67_AdjustedSales = 1000, Week2_67_GuestCount = 45, Week2_78_AdjustedSales = 345M, Week2_78_GuestCount = 23, Week2_89_AdjustedSales = 500, Week2_89_GuestCount = 700, Week2_AdjustedSalesTotal = 234, Week2_GuestCountTotal = 222, Week2Date = DateTime.Parse("05/21/2012"), Week3_45_AdjustedSales = 546M, Week3_45_GuestCount = 32, Week3_56_AdjustedSales = 340.2M, Week3_56_GuestCount = 90, Week3_67_AdjustedSales = 998, Week3_67_GuestCount = 34, Week3_78_AdjustedSales = 45634, Week3_78_GuestCount = 43, Week3_89_AdjustedSales = 888, Week3_89_GuestCount = 50, Week3_AdjustedSalesTotal = 320, Week3_GuestCountTotal = 10, Week3Date = DateTime.Parse("05/21/2011"), WeekDayOfPartnership = "Sunday" }
                );
            */
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

        public ActionResult FullCalendar()
        {
            return View();
        }

        public JsonResult GetEvents(double start, double end)
        {
            var fromDate = ConvertFromUnixTimestamp(start);
            var toDate = ConvertFromUnixTimestamp(end);
            
            //Get the events
            var db = new ApplicationDbContext();
            var partnershipNights = (from e in db.PartnershipNights.Include("BvLocation").Include("Charity")
                                         where e.StartDate >= fromDate && e.StartDate <= toDate
                                         select e).ToList<PartnershipNight>();
            var events = new List<Event>();
            foreach (var p in partnershipNights)
            {
                var stDt = ToUnixTimespan(p.StartDate);
                var endDt = ToUnixTimespan(p.EndDate);
               
                events.Add(new Event { id = p.PartnershipNightId, title = p.Charity.Name + "," + p.BVLocation.BvStoreNum, start = stDt, end = endDt, allDay = false});
            }
            var rows = events.ToArray();
            return Json(rows, JsonRequestBehavior.AllowGet);
        }

        private static DateTime ConvertFromUnixTimestamp(double timestamp)
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return origin.AddSeconds(timestamp);
        }

        public static string ToUnixTimespan(DateTime date)
        {
            TimeSpan tspan = date.ToUniversalTime().Subtract(
         new DateTime(1970, 1, 1, 0, 0, 0));

            return Math.Truncate(tspan.TotalSeconds).ToString();
        }

        public ActionResult Documents()
        {
            return View();
        }

        public void UpdateEvent(int id, string NewEventStart, string NewEventEnd)
        {
            //find the pn with the id
            PartnershipNight pn = pnRepo.GetPartnershipNightById(id);
            pn.StartDate = DateTime.Parse(NewEventStart);
            pn.EndDate = DateTime.Parse(NewEventEnd);
            pnRepo.UpdatePartnershipNight(pn);
        }

        public bool SaveEvent(string Title, int id, string NewStartDt, string NewStartTime, string NewEndDt, string NewEndTime)
        {
            return pnRepo.CreateNewEvent(Title, id, NewStartDt, NewStartTime, NewEndDt, NewEndTime);
        }

    }
}
