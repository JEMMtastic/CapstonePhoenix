using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Domain.Entities;
using System.Data.Entity;

namespace Capstone.Domain.Concrete
{
    public class CapstoneDbContext : DbContext
    {
        public DbSet<BvLocation> BvLocations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Charity> Charities { get; set; }
        public DbSet<PartnershipNight> PartnershipNights { get; set; }
        public DbSet<Form> Forms { get; set; }
    }
}
