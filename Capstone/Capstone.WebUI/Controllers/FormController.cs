using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone.WebUI.Domain.Concrete;
using Capstone.WebUI.Domain.Entities;

namespace Capstone.WebUI.Controllers
{
    public class FormController : Controller
    {

        FormRepository formRepo;

        public FormController()
        {
            formRepo = new FormRepository();
        }

        public ActionResult Index()
        {
            List<Form> forms = formRepo.GetForms().ToList<Form>();
            return View(forms);
        }

        public ActionResult Create()
        {
            Form newForm = new Form()
                {
                DateOfPartnership = DateTime.Now,  
                Week1Date = DateTime.Now,
                Week2Date = DateTime.Now,
                Week3Date = DateTime.Now
                };

            //from example word document, fill with temp data
            newForm = FillFormWithTempData(newForm);

            return View("Edit", newForm);
        }

        public ActionResult Edit(int formId)
        {
            Form f = formRepo.GetForms().FirstOrDefault(s => s.FormId == formId);

            return View(f);
        }

        [HttpPost]
        public ActionResult Edit(Form f)
        {
            if (ModelState.IsValid)
            {
                // Save the changes to the Form 
                f.CalculateSection1();
                f.CalculateSection2();
                f.CalculateSection3();
                f.CalculateSection4();
                f.CalculateSection5();
                formRepo.UpdateForm(f);
                TempData["message"] = string.Format("Form for Partnership Night {0} has been saved", f.DateOfPartnership);
                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values
                return View(f);
            }
        }

        public ActionResult Delete(int formId)
        {
            Form deletedForm = formRepo.DeleteForm(formId);
            if (deletedForm != null)
            {
                // TODO: Fix this. Partnership Night was removed from Form class
                //TempData["message"] = string.Format("Form for Partnership Night {0} was deleted",
                //deletedForm.pNight.Date);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Print(int PrintFormId)
        {
            //Save the form first (not working)
            
            var form = formRepo.GetFormById(PrintFormId);  
            return View(form);
        }

        //Alternate print with formatting - unfinished
        public ActionResult Print2(Form form)
        {
            return View(form);
        }

        protected Form FillFormWithTempData(Form form)
        {
            form.NameOnCheck = "Clackamas Christian School";
            form.Purpose = "Fundraiser for Field Trip to DC";
            form.ContactName = "Mr Smith";
            form.OrganizationMailingAddress = "123 Main Street";
            form.OrganizationMailingCity  = "Portland";
            form.OrganizationMailingState = "OR";
            form.OrganizationMailingZip = "92735";
            form.OrganizationPhone = "555-555-1234";
            form.FederalTaxID = "75-8888888";
            form.NewPartner = true;
            form.HostingRestaurant = 28;
            form.WeekDayOfPartnership = "Thursday";
            form.DateOfPartnership = new DateTime(2011, 3, 17);

            form.Week1Date = new DateTime(2011, 2, 24);
            form.Week2Date = new DateTime(2011, 3, 3);
            form.Week3Date = new DateTime(2011, 3, 10);
            form.Week1_45_GuestCount = 0;
            form.Week1_56_GuestCount = 43;
            form.Week1_67_GuestCount = 51;
            form.Week1_78_GuestCount = 34;
            form.Week1_89_GuestCount = 0;
            form.Week2_45_GuestCount = 0;
            form.Week2_56_GuestCount = 51;
            form.Week2_67_GuestCount = 46;
            form.Week2_78_GuestCount = 30;
            form.Week2_89_GuestCount = 0;
            form.Week3_45_GuestCount = 0;
            form.Week3_56_GuestCount = 30;
            form.Week3_67_GuestCount = 31;
            form.Week3_78_GuestCount = 7;
            form.Week3_89_GuestCount = 0;
            form.LastWeekAverageCheck_45 = 0;
            form.LastWeekAverageCheck_56 = 9.50;
            form.LastWeekAverageCheck_67 = 10.11;
            form.LastWeekAverageCheck_78 = 12.00;
            form.LastWeekAverageCheck_89 = 13.00;

            form.Scenario1_GuestCountInvited = 300;
            form.Scenario2_GuestCountInvited = 400;

            form.ActualSales_45 = 0;
            form.ActualSales_56 = 981.82;
            form.ActualSales_67 = 798.39;
            form.ActualSales_78 = 408.60;
            form.ActualSales_89 = 300.00;
            form.ActualGuestCount_45 = 0;
            form.ActualGuestCount_56 = 72;
            form.ActualGuestCount_67 = 67;
            form.ActualGuestCount_78 = 42;
            form.ActualGuestCount_89 = 30;
            form.PosiDonations = 15.00;
            form.Notes = "blah blah blah";

            form.MailPartnershipCheckToBV = true;

            return form;
        }

    }
}
