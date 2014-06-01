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
            return View("Edit", new Form());
        }

        public ActionResult Edit(int formId)
        {
            // Get the correct charity
            Form f = formRepo.GetForms().FirstOrDefault(s => s.FormId == formId);

            return View(f);
        }

        [HttpPost]
        public ActionResult Edit(Form f)
        {
            if (ModelState.IsValid)
            {
                // Save the changes to the partnership night 
                formRepo.UpdateForm(f);
                // TODO: Fix this. Partnership Night was removed from Form class
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

        public ActionResult Print(Form form)
        {
            return View(form);
        }

    }
}
