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

        public void AddForm(Form sec3)
        {
            var db = new CapstoneDbContext();

            db.Forms.Add(sec3);
        }

        public Form GetFormById(int id)
        {
            var db = new CapstoneDbContext();

            return (from sec3 in db.Forms
                    where sec3.FormId == id
                    select sec3).FirstOrDefault();
        }

        public IQueryable<Entities.Form> GetForms()
        {
            var db = new CapstoneDbContext();

            return (from sec3 in db.Forms
                    select sec3).AsQueryable<Form>();
        }

        public void UpdateForm(Entities.Form sec3)
        {
           var db = new CapstoneDbContext();

           if (sec3.FormId == 0)
           {
               db.Forms.Add(sec3);
           }
           else
           {
               var dbEntry = db.Forms.Find(sec3.FormId);
               if (dbEntry != null)
               {
                   dbEntry.ActualSalesFour = sec3.ActualSalesFour;
                   dbEntry.ActualSalesFive = sec3.ActualSalesFive;
                   dbEntry.ActualSalesSix = sec3.ActualSalesSix;
                   dbEntry.ActualSalesSeven = sec3.ActualSalesSeven;
                   dbEntry.ActualSalesEight = sec3.ActualSalesEight;
                   dbEntry.ActualGcFour = sec3.ActualGcFour;
                   dbEntry.ActualGcFive = sec3.ActualGcFive;
                   dbEntry.ActualGcSix = sec3.ActualGcSix;
                   dbEntry.ActualGcSeven = sec3.ActualGcSeven;
                   dbEntry.ActualGcEight = sec3.ActualGcEight;
                   dbEntry.PosiDonations = sec3.PosiDonations;
                   dbEntry.Notes = sec3.Notes;
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
