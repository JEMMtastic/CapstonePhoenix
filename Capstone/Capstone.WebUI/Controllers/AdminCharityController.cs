using Capstone.Domain.Concrete;
using Capstone.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.WebUI.Controllers
{
    public class AdminCharityController : Controller
    {
        CharityRepository charRepo;

        public AdminCharityController()
        {
            charRepo = new CharityRepository();
        }

        public ActionResult Index()
        {
            List<Charity> charities = charRepo.GetCharities().ToList<Charity>();

            return View(charities);
        }

        public ActionResult Create()
        {
            return View("Edit", new Charity());
        }

        public ActionResult Edit(int charityId)
        {
            // Get the correct charity
            Charity charity = charRepo.GetCharities().FirstOrDefault(ch => ch.CharityId == charityId);
            
            return View(charity);
        }

        [HttpPost]
        public ActionResult Edit(Charity charity)
        {
            if (ModelState.IsValid)
            {
                // Save the changes to the partnership night 
                charRepo.EditCharity(charity);
                TempData["message"] = string.Format("{0} has been saved", charity.Name);
                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values
                return View(charity);
            }
        }

        public ActionResult Delete(int charityId)
        {
            Charity deletedCharity = charRepo.DeleteCharity(charityId);
            if (deletedCharity != null)
            {
                TempData["message"] = string.Format("{0} was deleted",
                deletedCharity.Name);
            }
            return RedirectToAction("Index");
        }
    }
}
