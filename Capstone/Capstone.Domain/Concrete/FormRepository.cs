using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Domain.Abstract;
using Capstone.Domain.Entities;

namespace Capstone.Domain.Concrete
{
    public class FormRepository : FormInterface
    {

        public void AddForm(Form form)
        {
            var db = new CapstoneDbContext();

            db.Forms.Add(form);
        }

        public Form GetFormById(int id)
        {
            var db = new CapstoneDbContext();

            return (from form in db.Forms
                    where form.FormId == id
                    select form).FirstOrDefault();
        }

        public IQueryable<Entities.Form> GetForms()
        {
            var db = new CapstoneDbContext();

            return (from form in db.Forms
                    select form).AsQueryable<Form>();
        }

        public void UpdateForm(Entities.Form form)
        {
           var db = new CapstoneDbContext();

           if (form.FormId == 0)
           {
               db.Forms.Add(form);
           }
           else
           {
               var dbEntry = db.Forms.Find(form.FormId);
               if (dbEntry != null)
               {
                   //dbEntry.ActualSalesFour = form.ActualSalesFour;
                   //dbEntry.ActualSalesFive = form.ActualSalesFive;
                   //dbEntry.ActualSalesSix = form.ActualSalesSix;
                   //dbEntry.ActualSalesSeven = form.ActualSalesSeven;
                   //dbEntry.ActualSalesEight = form.ActualSalesEight;
                   //dbEntry.ActualGcFour = form.ActualGcFour;
                   //dbEntry.ActualGcFive = form.ActualGcFive;
                   //dbEntry.ActualGcSix = form.ActualGcSix;
                   //dbEntry.ActualGcSeven = form.ActualGcSeven;
                   //dbEntry.ActualGcEight = form.ActualGcEight;
                   //dbEntry.PosiDonations = form.PosiDonations;
                   //dbEntry.Notes = form.Notes;
               }
               db.SaveChanges();
           }
        }

        public Form DeleteForm(int id)
        {
            var db = new CapstoneDbContext();
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
