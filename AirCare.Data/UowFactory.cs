using AirCare.Data.Core;
using AirCare.Data.Seed;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace AirCare.Data
{
    public static class UowFactory
    {
        public static string ConnectionString = string.Empty;

        static UowFactory()
        {
            // Disable EF code first approach by looking at the web.config parameter [WARNING!!]
            var DisableEfCodeFirst = ConfigurationManager.AppSettings["DisableEfCodeFirst"];
            if (DisableEfCodeFirst.Equals("true"))
            {
                // Do nothing, If the database is not handled properly, this will cause issues
            }
            else
            {
                Database.SetInitializer(new DropIfChanged(new List<ISeed> { 
                new SeedBaseData(), 
                new SeedSampleData()}));
            }
        }

        public static IUnitOfWork Create()
        {
            //Name or Connection String can be passed in to EF DbContext
            var context = new DatabaseContext(ConnectionString);
            var uow = new UnitOfWork(context);

            return uow;
        }
    }
}
