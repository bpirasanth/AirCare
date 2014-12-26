using AirCare.Web.Models;
using AirCare.Web.Security;
using AirCare.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirCare.Web.Controllers
{
    [CustomAuthorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        //
        // GET: /Flight/


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddFlight()
        {
            FlightViewModel flightViewModel = new FlightViewModel();
            ViewBag.IsModelValid = true;
            return View(flightViewModel);
        }

        [HttpPost]
        public ActionResult AddFlight(FlightViewModel flightViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.IsModelValid = false;
                return View(flightViewModel);
            }
            FlightModel flightModel = new FlightModel();
            flightModel.Save(flightViewModel);
            return RedirectToAction("Index", "Admin");
        }


        public ActionResult AddAirport()
        {
            AirportViewModel airportViewModel = new AirportViewModel();
            ViewBag.IsModelValid = true;
            return View(airportViewModel);
        }
        [HttpPost]
        public ActionResult AddAirport(AirportViewModel airportViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.IsModelValid = false;
                return View(airportViewModel);
            }

            AirportModel airportModel = new AirportModel();
            airportModel.Save(airportViewModel);
            return RedirectToAction("Index", "Admin");
        }

        [HttpPost]
        public JsonResult GetAirportsByFilter(string filter)
        {
            AirportModel airportModel = new AirportModel();
            return Json(airportModel.GetAirportsByFilter(filter).Select(a => a.Name));
        }


        [HttpPost]
        public JsonResult GetSchedulesByFilter(string origin, string destination, string departureDate, string arrivalDate)
        {
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
    }
}
