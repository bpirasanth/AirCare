using AirCare.Data;
using AirCare.Model.Entities;
using AirCare.Web.Core;
using AirCare.Web.Models;
using AirCare.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace AirCare.Web.Controllers
{
    public class AccountController : Controller
    {
        [AllowAnonymous]
        public ActionResult Login()
        {
            ViewBag.IsModelValid = true;
            bool IsLoggedIn = (System.Web.HttpContext.Current.User != null) &&
                      System.Web.HttpContext.Current.User.Identity.IsAuthenticated &&
                      !String.IsNullOrWhiteSpace(UowFactory.ConnectionString);

            if (IsLoggedIn)
            {
                return RedirectToAction("Index", "Client");
            }
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.IsModelValid = false;
                ModelState.AddModelError("", "Username or pasword you provided is not valid.");
                return View(model);
            }

            if (!WebSecurity.Login(model.UserName, model.Password, persistCookie: false))
            {
                ViewBag.IsModelValid = false;
                ModelState.AddModelError("", "The user name or password provided is incorrect.");
                return View(model);
            }

            return RedirectToAction("Home", "Client");
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
            vModel.Roles = new List<Role>() { model.GetClientRole() };
            model.Save(vModel);

            return RedirectToAction("Index", "Client");
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult LogOut()
        {
            WebSecurity.Logout();
            Session.RemoveAll();
            Session.Abandon();
            return RedirectToAction("Index", "Client");
        }

    }
}
