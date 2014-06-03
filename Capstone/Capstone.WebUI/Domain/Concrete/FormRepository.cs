using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.WebUI.Domain.Abstract;
using Capstone.WebUI.Domain.Entities;
using Capstone.WebUI.Models;

namespace Capstone.WebUI.Domain.Concrete
{
    public class FormRepository : FormInterface
    {

        public void AddForm(Form form)
        {
            var db = new ApplicationDbContext();

            db.Forms.Add(form);
        }

        public Form GetFormById(int id)
        {
            var db = new ApplicationDbContext();

            return (from form in db.Forms
                    where form.FormId == id
                    select form).FirstOrDefault();
        }

        public IQueryable<Entities.Form> GetForms()
        {
            var db = new ApplicationDbContext();

            return (from form in db.Forms
                    select form).AsQueryable<Form>();
        }

        public void UpdateForm(Entities.Form form)
        {
           var db = new ApplicationDbContext();

           if (form.FormId == 0)
           {
               db.Forms.Add(form);
           }
           else
           {
               var dbEntry = db.Forms.Find(form.FormId);
               if (dbEntry != null)
               {
                   dbEntry = form;
               }               
           }

           db.SaveChanges();
        }

        public Form DeleteForm(int id)
        {
            var db = new ApplicationDbContext();
            var dbEntry = db.Forms.Find(id);
            if (dbEntry != null)
            {
                db.Forms.Remove(dbEntry);
                db.SaveChanges();
            }
            return dbEntry;
        }
    }
}
