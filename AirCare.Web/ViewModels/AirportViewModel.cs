using AirCare.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AirCare.Web.ViewModels
{
    public class AirportViewModel
    {
        [Required, Display(Name = "Airport Name")]
        public string Name { get; set; }
        [Required, Display(Name = "Airport Location")]
        public string Location { get; set; }
        [Required, Display(Name = "Latitude")]
        public double Latitude { get; set; }
        [Required, Display(Name = "Longitude")]
        public double Longitude { get; set; }


    }
}