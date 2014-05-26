using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.WebUI.Domain.Entities;
using System.Data.Entity;

namespace Capstone.WebUI.Domain.Concrete
{
    public class OldCapstoneDbContext : DbContext
    {
        public DbSet<BvLocation> BvLocations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Charity> Charities { get; set; }
        public DbSet<PartnershipNight> PartnershipNights { get; set; }
        public DbSet<Form> Forms { get; set; }
    }
}
