using AirCare.Data;
using AirCare.Data.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace AirCare.Web.Models
{
    public class BaseModel : IDisposable
    {
        // Instance of the unit of work class to be used in the model.
        protected IUnitOfWork UnitOfWork;

        public BaseModel()
        {
            UowFactory.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            // Initialize the UnitOfWork from the factory.
            UnitOfWork = UowFactory.Create();
        }

        public void Dispose()
        {
            // Check if the UnitOfWork has been initialized and dispose of it if it has.
            if (UnitOfWork != null)
            {
                UnitOfWork.Dispose();
            }
        }
    }
}