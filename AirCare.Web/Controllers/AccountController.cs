using AirCare.Model.Entities;
using AirCare.Web.Core;
using AirCare.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirCare.Web.Controllers
{
    public class AccountController : BaseController
    {     
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult SignUp()
        {
            SignUpViewModel model = new SignUpViewModel();
            ViewBag.IsModelValid = true;
            model.SecurityQuestions = new List<String>(Constant.SECURITY_QUESTIONS);

            return View(model);
        }

        [HttpPost]
        public ActionResult SignUp(SignUpViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.IsModelValid = false;
                model.SecurityQuestions = new List<String>(Constant.SECURITY_QUESTIONS);
                return View(model);
            }
            User user = new User();
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.UserName = model.UserName;
            user.Password = model.Password;
            user.SequrityQuestion = model.SecurityQuestion;
            user.Answer = model.Answer;


            UnitOfWork.GetEntityRepository<User>().InsertOrUpdate(user);
            UnitOfWork.Commit();
            return RedirectToAction("Index", "Client");
        }

    }
}
