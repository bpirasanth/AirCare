using AirCare.Data;
using AirCare.Data.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirCare.Web.Core
{
    public class BaseController : Controller
    {
        protected IUnitOfWork UnitOfWork { get; set; }
        
        public BaseController()
        {
            UowFactory.ConnectionString = UowFactory.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            UnitOfWork = UowFactory.Create();
        }

        /// <summary>
        /// Dispose the unit of work on controller disposal
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            UnitOfWork.Dispose();
            base.Dispose(disposing);
        }

    }
}
