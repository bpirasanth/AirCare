using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirCare.Web.ViewModels
{
    public class UserViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SequrityQuestion { get; set; }
        public string Answer { get; set; }
    }
}