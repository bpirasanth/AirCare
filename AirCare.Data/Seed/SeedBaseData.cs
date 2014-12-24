using AirCare.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirCare.Data.Seed
{
    class SeedBaseData : ISeed
    {
        public void Seed(DatabaseContext context)
        {
            context.Role.Add(new Role { Name = "Client", Description = "Client" });
            context.Role.Add(new Role { Name = "Admin", Description = "Administrator" });
            context.SaveChanges();

            context.User.Add(new User { FirstName = "Admin", LastName = "Admin", UserName = "admin", Password = "admin", SecurityQuestion = "What is your pet name?", Answer = "jimbo", Roles = new List<Role>() { context.Role.FirstOrDefault(p => p.Name == "Admin") } });

        }
    }
}
