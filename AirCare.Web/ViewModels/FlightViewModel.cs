using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AirCare.Web.ViewModels
{
    public class FlightViewModel
    {

        [Required, Display(Name = "Airline Name")]
        public string Airline { get; set; }
        [Required, Display(Name = "Flight No.")]
        public string FlightNumber { get; set; }

    }
}