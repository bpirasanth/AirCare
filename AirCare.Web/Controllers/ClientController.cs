using AirCare.Web.Models;
using AirCare.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirCare.Web.Controllers
{
    public class ClientController : Controller
    {
        //
        // GET: /Client/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddPassenger()
        {
            PassengerViewModel passengerViewModel = new PassengerViewModel();
            ViewBag.IsModelValid = true;
            return View(passengerViewModel);
        }

        [HttpPost]
        public ActionResult AddPassenger(PassengerViewModel passengerViewModel)
        { 
            if(!ModelState.IsValid)
            {
                ViewBag.IsModelValid = false;
                return View(passengerViewModel);

            }

            PassengerModel passengerModel = new PassengerModel();
            passengerModel.Save(passengerViewModel);

            return   RedirectToAction("Index", "Admin");
        }
        
        

    }
}
