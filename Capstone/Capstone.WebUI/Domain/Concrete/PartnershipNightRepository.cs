using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Capstone.WebUI.Domain.Entities;
using Capstone.WebUI.Domain.Abstract;
using Capstone.WebUI.Models;
using System.Globalization;

namespace Capstone.WebUI.Domain.Concrete
{
    public class PartnershipNightRepository : PartnershipNightInterface
    {
        public void AddPartnershipNight(PartnershipNight pn)
        {
            //throw new NotImplementedException();
            var db = new ApplicationDbContext();
            db.PartnershipNights.Add(pn);
            db.SaveChanges();
            //TODO: Add in error handling
        }

        public PartnershipNight GetPartnershipNightById(int partnershipNightId)
        {
            var db = new ApplicationDbContext();
            return (from pnight in db.PartnershipNights.Include("Charity").Include("BVLocation")
                    where pnight.PartnershipNightId == partnershipNightId
                    select pnight).FirstOrDefault();
        }

        public PartnershipNight GetPartnershipNightByDate(DateTime date, BvLocation loc)
        {
            var db = new ApplicationDbContext();
            return (from pnight in db.PartnershipNights.Include("Charity").Include("BVLocation")
                    where pnight.StartDate == date && pnight.BVLocation == loc
                    select pnight).FirstOrDefault();
        }

        public IQueryable<PartnershipNight> GetPartnershipNights()  //Doing it this way as per suggestion. Seems highly inefficient to me to grab all partnership nights en masse, would prefer to narrow them via some criteria. Options commented out below for the future, should we decide to implement them.
        {
            var db = new ApplicationDbContext();
            return (from pnight in db.PartnershipNights.Include("Charity").Include("BVLocation")
                    select pnight).AsQueryable<PartnershipNight>();
        }
       
        public void UpdatePartnershipNight(PartnershipNight pn)
        {
            var db = new ApplicationDbContext();
            if (pn.PartnershipNightId == 0)
                db.PartnershipNights.Add(pn);
            else
            {
                PartnershipNight dbEntry = db.PartnershipNights.Find(pn.PartnershipNightId);
                if (dbEntry != null)
                {
                    dbEntry.StartDate = pn.StartDate;
                    dbEntry.EndDate = pn.EndDate;
                    dbEntry.Comments = pn.Comments;
                    dbEntry.Charity = db.Charities.Find(pn.Charity.CharityId);
                    dbEntry.BVLocation = db.BvLocations.Find(pn.BVLocation.BvLocationId);
                }
            }
            db.SaveChanges();
        }
        
        public PartnershipNight DeletePartnershipNight(int id) //should this take a partnership night or id as parameter?
        {
            //throw new NotImplementedException();
            var db = new ApplicationDbContext();
            PartnershipNight dbEntry = db.PartnershipNights.Find(id);
            if (dbEntry != null)
            {
                db.PartnershipNights.Remove(dbEntry);
                db.SaveChanges();
            }
            return dbEntry;
            //TODO: Add in error handling
        }


        public void UpdatePartnershipNight(int id, string NewEventStart, string NewEventEnd)
        {
            // EventStart comes ISO 8601 format, eg:  "2000-01-10T10:00:00Z" - need to convert to DateTime
            using (var db = new ApplicationDbContext())
            {
                var rec = db.PartnershipNights.FirstOrDefault(s => s.PartnershipNightId == id);
                if (rec != null)
                {
                    DateTime DateTimeStart = DateTime.Parse(NewEventStart, null, DateTimeStyles.RoundtripKind).ToLocalTime(); // and convert offset to localtime
                    rec.StartDate = DateTimeStart;
                    DateTime DateTimeEnd = DateTime.Parse(NewEventEnd, null, DateTimeStyles.RoundtripKind).ToLocalTime();
                    rec.EndDate = DateTimeEnd;
                    db.SaveChanges();
                }
            }
        }

        public bool CreateNewEvent(string Title, int id ,string NewStartDate, string NewStartTime, string NewEndDt, string NewEndTime)
        {
            try
            {
                var db = new ApplicationDbContext();
                PartnershipNight rec = new PartnershipNight();
                rec.Charity = db.Charities.Find(Title);
                rec.BVLocation = db.BvLocations.Find(id);
                rec.StartDate = DateTime.ParseExact(NewStartDate + " " + NewStartTime, "MM/dd/yyyy HH:mm tt", CultureInfo.InvariantCulture);
                rec.EndDate = DateTime.ParseExact(NewEndDt + " " + NewEndTime, "MM/dd/yyyy H:mm tt", CultureInfo.InvariantCulture);
                db.PartnershipNights.Add(rec);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }


       
    }
}
