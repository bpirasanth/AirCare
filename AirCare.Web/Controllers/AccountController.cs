using AirCare.Model.Entities;
using AirCare.Web.Core;
using AirCare.Web.Models;
using AirCare.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirCare.Web.Controllers
{
    public class AccountController : Controller
    {     
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult SignUp()
        {
            UserViewModel model = new UserViewModel();
            ViewBag.IsModelValid = true;
            model.SecurityQuestions = new List<String>(Constant.SECURITY_QUESTIONS);

            return View(model);
        }

        [HttpPost]
        public ActionResult SignUp(UserViewModel vModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.IsModelValid = false;
                vModel.SecurityQuestions = new List<String>(Constant.SECURITY_QUESTIONS);
                return View(vModel);
            }

            UserModel model = new UserModel();
            model.Save(vModel);
            
            return RedirectToAction("Index", "Client");
        }

    }
}
