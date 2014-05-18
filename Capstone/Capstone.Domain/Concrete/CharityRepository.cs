using Capstone.Domain.Abstract;
using Capstone.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Domain.Concrete
{
    public class CharityRepository : CharityInterface
    {

        public void AddCharity(Charity charity)
        {
            var db = new CapstoneDbContext();
            db.Charities.Add(charity);
            db.SaveChanges();
        }

        public Charity GetCharityByName(string name)
        {
            //throw new NotImplementedException();
            var db = new CapstoneDbContext();
            return (from charity in db.Charities
                    where charity.Name == name
                    select charity).FirstOrDefault();
        }

        /*public Charity GetCharityById(int id)
        {
            //throw new NotImplementedException();
            var db = new CapstoneDbContext();
            return (from charity in db.Charities
                    where charity.CharityId == id
                    select charity).FirstOrDefault();
        }*/

        public IQueryable<Charity> GetCharities()
        {
            var db = new CapstoneDbContext();
            return (from charity in db.Charities
                    select charity).AsQueryable<Charity>();
        }

        //Aka save/update charity
        public void EditCharity(Charity charity)
        {
            var db = new CapstoneDbContext();
            if (charity.CharityId == 0)
            {
                //first add any children
                //Add new user
                db.Charities.Add(charity);
            }
            else
            {
                Charity dbEntry = db.Charities.Find(charity.CharityId);
                if (dbEntry != null)
                {
                    dbEntry.Name = charity.Name;
                    dbEntry.Address = charity.Address;
                    dbEntry.City = charity.City;
                    dbEntry.Zip = charity.Zip;
                    dbEntry.Phone = charity.Phone;
                    dbEntry.FederalTaxId = charity.FederalTaxId;
                    dbEntry.TypeOfCharity = charity.TypeOfCharity;
                }
            }
            db.SaveChanges();
        }

        public Charity DeleteCharity(int charityId)  //If we decide not to allow deletion we can take this out later
        {
            var db = new CapstoneDbContext();
            Charity dbEntry = db.Charities.Find(charityId);
            if (dbEntry != null)
            {
                db.Charities.Remove(dbEntry);
                db.SaveChanges();
            }
            return dbEntry;
        }
    }
}
