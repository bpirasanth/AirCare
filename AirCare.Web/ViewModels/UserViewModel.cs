using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AirCare.Web.ViewModels
{
    public class UserViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter User Name"), Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter Password")]
        public string Password { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter First Name"), Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter Last Name"), Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Security Question")]
        public string SecurityQuestion { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter Answer")]
        public string Answer { get; set; }

        public IList<String> SecurityQuestions { get; set; }
    }
}