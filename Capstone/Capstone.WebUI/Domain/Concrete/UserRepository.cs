using Capstone.WebUI.Domain.Abstract;
using Capstone.WebUI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.WebUI.Domain.Concrete
{
    public class UserRepository : UserInterface
    {
        //TEMPORARILY REMOVING WHILE WE GET IDENTITY TO HANDLE USER CRUD
        /*
        public void AddUser(Entities.User u)
        {
          try
          {
            var db = new OldCapstoneDbContext();
            db.Users.Add(u);

                db.SaveChanges();
          }
          catch (System.Data.Entity.Validation.DbEntityValidationException dbEx) //Catches errors in creating the db User table for the first time
          {
              Exception raise = dbEx;
              foreach (var validationErrors in dbEx.EntityValidationErrors)
              {
                  foreach (var validationError in validationErrors.ValidationErrors)
                  {
                      string message = string.Format("{0}:{1}",
                          validationErrors.Entry.Entity.ToString(),
                          validationError.ErrorMessage);
                      // raise a new exception nesting
                      // the current instance as InnerException
                      raise = new InvalidOperationException(message, raise);
                  }
              }
              throw raise;
          }
        }

        public Entities.User GetUser(int userId)
        {
            var db = new OldCapstoneDbContext();
            return (from u in db.Users.Include("BvLocation")
                    where u.Id == userId.ToString()
                    select u).FirstOrDefault();
        }

        public User DeleteUser(int userId)
        {

            var db = new OldCapstoneDbContext();
            User dbEntry = db.Users.Find(userId);
            if (dbEntry != null)
            {
                db.Users.Remove(dbEntry);
                db.SaveChanges();
            }
            return dbEntry;
        }

        public void SaveUser(User u)
        {
            var db = new OldCapstoneDbContext();
            if (u.Id == 0.ToString())
            {
                db.BvLocations.Find(u.BvLocation.BvLocationId);

                db.Users.Add(u);
            }
            else
            {
                User dbEntry = db.Users.Find(u.Id);
                if (dbEntry != null)
                {
                    dbEntry.FName = u.FName;
                    dbEntry.LName = u.LName;
                    dbEntry.Email = u.Email;
                    dbEntry.PhoneNumber = u.PhoneNumber;
                    //dbEntry.AccessLevel = u.AccessLevel;
                    dbEntry.BvLocation = db.BvLocations.Find(u.BvLocation.BvLocationId);
                }

            }
            db.SaveChanges();
        }

         */
    }

}
