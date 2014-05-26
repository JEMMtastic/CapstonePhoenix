using Capstone.WebUI.Domain.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Capstone.WebUI.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    
    public class ApplicationUser : User
    {
    }

    //public class ApplicationDbContext : IdentityDbContext<User>
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

        /*public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }
         * */
    }
}