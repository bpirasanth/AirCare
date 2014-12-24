using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AirCare.Web.ViewModels
{
    public class PassengerViewModel
    {
        [Required, Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required, Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required, Display(Name = "Passport Number")]
        public string PassportNumber { get; set; }

        [Required, Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage="Invalid Email Addresss")]
        public string EmailAddress { get; set; }
    }
}