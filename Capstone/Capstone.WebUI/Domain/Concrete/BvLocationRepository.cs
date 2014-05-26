﻿using Capstone.WebUI.Domain.Abstract;
using Capstone.WebUI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.WebUI.Domain.Concrete
{
    public class BvLocationRepository: BvLocationInterface
    {

        public Entities.BvLocation GetBvLocation(int bvLocationId)
        {
            var db = new OldCapstoneDbContext();
            return (from l in db.BvLocations
                    where l.BvLocationId == bvLocationId
                    select l).FirstOrDefault();
        }

        public IQueryable<BvLocation> GetBvLocations()
        {
            var db = new OldCapstoneDbContext();
            return (from l in db.BvLocations
                    select l).AsQueryable<BvLocation>();
        }

        public BvLocation GetBvLocation(string storeNum)
        {
            var db = new OldCapstoneDbContext();
            return (from l in db.BvLocations
                    where l.BvStoreNum == storeNum
                    select l).FirstOrDefault();
        }

        public void AddBvLocation(BvLocation bvLocation)
        {
            var db = new OldCapstoneDbContext();
            db.BvLocations.Add(bvLocation);
            db.SaveChanges(); ;
        }

        public BvLocation DeleteBvLocation(int bvLocationId)
        {
            var db = new OldCapstoneDbContext();
            BvLocation dbEntry = db.BvLocations.Find(bvLocationId);
            if (dbEntry != null)
            {
                db.BvLocations.Remove(dbEntry);
                db.SaveChanges();
            }
            return dbEntry;
        }

        public void SaveBvLocation(BvLocation l)
        {
            var db = new OldCapstoneDbContext();
            if (l.BvLocationId == 0)
                db.BvLocations.Add(l);
            else
            {
                BvLocation dbEntry = db.BvLocations.Find(l.BvLocationId);
                if (dbEntry != null)
                {
                    dbEntry.Address = l.Address;
                    dbEntry.BvStoreNum = l.BvStoreNum;
                    dbEntry.City = l.City;
                    dbEntry.Phone = l.Phone;
                    dbEntry.Zip = l.Zip;
                }

            }
            db.SaveChanges();
        }

        public List<PartnershipNight> GetPartnershipNights(BvLocation l)
        {
            var db = new OldCapstoneDbContext();
            List<PartnershipNight> partnershipnights = (from c in db.PartnershipNights.Include("BvLocation").Include("Charity")
                                                        where c.BVLocation.BvLocationId == l.BvLocationId
                                                        select c).ToList<PartnershipNight>();
            return partnershipnights;
        }

    }
}
