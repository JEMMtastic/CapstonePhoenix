using Capstone.WebUI.Domain.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;

namespace Capstone.WebUI.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string test1 { get; set; }
        public int test2 { get; set; }
        public decimal test3 { get; set; }
        public DateTime test4 { get; set; }
        //public Charity test5 { get; set; }
        //public BvLocation BvLocation { get; set; }
       // public string FirstName { get; set; }
      //  public string LastName { get; set; }
    }

    //public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
            : base("CapstoneDbContext")
        {

        }

        public DbSet<BvLocation> BvLocations { get; set; }
        public DbSet<Charity> Charities { get; set; }
        public DbSet<PartnershipNight> PartnershipNights { get; set; }
        public DbSet<Form> Forms { get; set; }
        //public DbSet<User> Users { get; set; }

        /*public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }
         * */
    }
}