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
    public class LeaderBoardController : Controller
    {
        FormInterface fRepo;

        // The default constructor is called by the framework
        public LeaderBoardController()
        {
            fRepo = new FormRepository();
        }

        public ActionResult Index()
        {
            // TODO: Add a condtion so that if there are no complete forms, it just displays a nice message
            GetCompleteLeaders();
            return View();
        }

        public string GetCompleteLeaders()
        {
            var db = new ApplicationDbContext();
            
            // Get a list of complete partnership night forms, in order by the actual total sales
            var leaderForms = (from f in db.Forms
                                where f.IsComplete == true
                                orderby f.ActualSalesTotal
                                select f).ToList<Form>();

            var forms = new List<Form>();

            // Add the forms to the list
            foreach (var f in leaderForms)
            {
                forms.Add(new Form { 
                    HostingRestaurant = f.HostingRestaurant, NameOnCheck = f.NameOnCheck, Purpose = f.Purpose, 
                    DateOfPartnership = f.DateOfPartnership, ActualSalesTotal = f.ActualSalesTotal, 
                    ActualGuestCountTotal = f.ActualGuestCountTotal, PosiDonations = f.PosiDonations });
            }

            // Display list
            return leaderForms.ToString();
        }
    }
}