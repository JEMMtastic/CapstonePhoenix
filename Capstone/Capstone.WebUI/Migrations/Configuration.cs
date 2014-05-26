namespace Capstone.WebUI.Migrations
{
    using Capstone.WebUI.Domain.Entities;
    using Capstone.WebUI.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Capstone.WebUI.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Capstone.WebUI.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //data to get db up and running -- delete when done
            //add a location
            context.BvLocations.AddOrUpdate(
                l => l.BvLocationId,
                    new BvLocation { BvLocationId = 1, Address = "333 N Main St", City = "Bobville", BvStoreNum = "BV99", Phone = "839-839-8393", Zip = "88898" }
                );
            //BvLocation loc1 = new BvLocation { Address = "333 N Main St", City = "BobVille", BvStoreNum = "BV99", Phone = "839-839-8393", Zip = "88898" };
            //lRepo.AddBvLocation(loc1);

            //add a user
            context.Users.AddOrUpdate(
                  u => u.UserName,
                  new ApplicationUser { UserName = "turtles", PasswordHash = "1234567".GetHashCode().ToString(), Email = "me2@you.com", EmailConfirmed = true, BvLocation = context.BvLocations.Find(1), FName = "Moo", LName = "Cow"  },
                  new ApplicationUser { UserName = "User2", PasswordHash = "password123".GetHashCode().ToString(), Email = "me@you.com", EmailConfirmed = true, BvLocation = context.BvLocations.Find(1), FName = "Joe", LName = "Joebert" }
                );
            /*CUser u1 = new CUser { Username = "turtles", UserFName = "Bob", UserLName = "Bobberson", AccessLevel = 1, BvLocation = loc1, Password = "bobshere", UserEmail = "bob@bob.com", PhoneNumber = "541-389-8293" };
            uRepo.AddUser(u1);*/

            // add a charity
            context.Charities.AddOrUpdate(
                c => c.CharityId,
                new Charity { CharityId = 1, Address = "8939 S Seventh", City = "CharityVille", FederalTaxId = "893018X", Name = "HopeForBob", Phone = "893-829-8393", TypeOfCharity = "Helpful", Zip = "83928"}
                );
            //Charity c1 = new Charity { Address = "8939 S Seventh", City = "CharityVille", FederalTaxId = "893018XS", Name = "HopeForBob", Phone = "893-829-8393", TypeOfCharity = "Helpful", Zip = "83928" };
            //cRepo.AddCharity(c1);

            //add a partnership night
            context.PartnershipNights.AddOrUpdate(
                    pn => pn.PartnershipNightId,
                    new PartnershipNight { PartnershipNightId = 1, AfterTheEventFinished = false, BeforeTheEventFinished = true, BVLocation = context.BvLocations.Find(1), Charity = context.Charities.Find(1), CheckRequestFinished = false, Comments = "blah blah", StartDate = DateTime.Parse("05/30/2014"), EndDate = DateTime.Parse("05/30/2014"), CheckRequestId = 1, EventLength = 25 }
                );
            //PartnershipNight pn1 = new PartnershipNight { AfterTheEventFinished = false, BeforeTheEventFinished = true, BVLocation = loc1, Charity = c1, CheckRequestFinished = false, Comments = "blah blah", Date = DateTime.Parse("05/30/2014") };
            //pnRepo.AddPartnershipNight(pn1);

            //add a form
            context.Forms.AddOrUpdate(
                f => f.FormId,
                new Form { FormId = 1, ActualGcEight = 2, ActualGcFive = 5, ActualGcFour = 32, ActualGcSeven = 33, ActualGcSix = 345, ActualSalesEight = 555, ActualSalesFive = 345, ActualSalesFour = 36, ActualSalesSeven = 999, ActualSalesSix = 22, Contact = "Bob", NewPartner = false, LWkAvgChkEight = 10.5M, LWkAvgChkFive = 43.2M, LWkAvgChkFour = 2M, LWkAvgChkSeven = 34M, LWkAvgChkSix = 543M, Notes = "This form is long", PosiDonations = 25.6M, Purpose = "To Wreak Havoc", Scenario1Gc = 32, Scenario2Gc = 88, Wk1EightGc = 345, Wk1FiveGc = 54, Wk1FourGc = 77, Wk1SevenGc = 66, Wk1SixGc = 55, Wk1Year = 4000, Wk2EightGc = 36, Wk2FiveGc = 22, Wk2FourGc = 12, Wk2SixGc = 44, Wk2Year = 1000, Wk3EightGc = 43, Wk3FiveGc = 43, Wk3FourGc = 34, Wk3SevenGc = 34, Wk3SixGc = 43, Wk3Year = 3000, WkSevenGc = 25}
                );
        }
    }
}
