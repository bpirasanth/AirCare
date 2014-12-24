using AirCare.Data.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirCare.Model.Entities;
using System.Data.Entity.ModelConfiguration.Conventions;
using AirCare.Data.Configurations;

namespace AirCare.Data
{
    public class DatabaseContext : BaseContext
    {
        public DatabaseContext(string connectionStringName)
            : base(connectionStringName) { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new PathConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
        }

        public DbSet<User> User { get; set; }
        public DbSet<Airport> Airport { get; set; }
        public DbSet<Flight> Flight { get; set; }
        public DbSet<Passenger> Passenger { get; set; }
        public DbSet<Path> Path { get; set; }
        public DbSet<Schedule> Schedule { get; set; }
        public DbSet<Role> Role { get; set; }
    }
}
