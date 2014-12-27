using AirCare.Data;
using AirCare.Model.Entities;
using AirCare.Web.Core;
using AirCare.Web.Models;
using AirCare.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace AirCare.Web.Controllers
{
    public class AccountController : Controller
    {
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.IsModelValid = true;
            bool IsLoggedIn = (System.Web.HttpContext.Current.User != null) &&
                      System.Web.HttpContext.Current.User.Identity.IsAuthenticated &&
                      !String.IsNullOrWhiteSpace(UowFactory.ConnectionString);

            if (IsLoggedIn)
            {
                return RedirectToAction("Index", "Client");
            }

            ViewBag.ReturnUrl = String.IsNullOrWhiteSpace(returnUrl) ? "/Client/Index" : returnUrl;

            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginModel model, string returnUrl)
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

            return RedirectToLocal(returnUrl);
        }

        public string Decrypt(string encryptedString)
        {
            DESCryptoServiceProvider desProvider = new DESCryptoServiceProvider();
            desProvider.Mode = CipherMode.ECB;
            desProvider.Padding = PaddingMode.PKCS7;
            string key = "abcd1234";
            desProvider.Key = Encoding.ASCII.GetBytes(key);
            using (MemoryStream stream = new MemoryStream(Convert.FromBase64String(encryptedString)))
            {
                using (CryptoStream cs = new CryptoStream(stream, desProvider.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    using (StreamReader sr = new StreamReader(cs, Encoding.ASCII))
                    {
                        return sr.ReadToEnd();
                    }
                }
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Client");
            }
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

            try
            {
                UserModel model = new UserModel();
                vModel.Roles = new List<Role>() { model.GetClientRole() };
                model.Save(vModel);
            }
            catch (ArgumentException e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                ViewBag.IsModelValid = false;
                vModel.SecurityQuestions = new List<String>(Constant.SECURITY_QUESTIONS);
                return View(vModel);
            }

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
