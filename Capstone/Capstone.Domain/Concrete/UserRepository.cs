using Capstone.Domain.Abstract;
using Capstone.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Domain.Concrete
{
    public class UserRepository : UserInterface
    {


        public void AddUser(Entities.User u)
        {
          try
          {
            var db = new CapstoneDbContext();
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
            var db = new CapstoneDbContext();
            return (from u in db.Users.Include("BvLocation")
                    where u.UserId == userId
                    select u).FirstOrDefault();
        }

        public User DeleteUser(int userId)
        {

            var db = new CapstoneDbContext();
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
            var db = new CapstoneDbContext();
            if (u.UserId == 0)
                db.Users.Add(u);
            else
            {
                User dbEntry = db.Users.Find(u.UserId);
                if (dbEntry != null)
                {
                    dbEntry.UserFName = u.UserFName;
                    dbEntry.UserLName = u.UserLName;
                    dbEntry.UserEmail = u.UserEmail;
                    dbEntry.PhoneNumber = u.PhoneNumber;
                    dbEntry.AccessLevel = u.AccessLevel;
                    dbEntry.BvLocation = u.BvLocation;
                }

            }
            db.SaveChanges();
        }
    }
}
