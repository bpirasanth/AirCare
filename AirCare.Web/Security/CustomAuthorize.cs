using AirCare.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AirCare.Web.Security
{
    public class CustomAuthorize : AuthorizeAttribute
    {
        protected virtual PrincipalUser CurrentUser
        {
            get { return PrincipalUser.GetCurrentUser() as PrincipalUser; }
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.Request.IsAuthenticated)
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Account", action = "Login", ReturnUrl = filterContext.HttpContext.Request.Url.LocalPath }));
            if (filterContext.HttpContext.Request.IsAuthenticated)
            {
                if (!String.IsNullOrEmpty(Roles))
                {
                    if (!CurrentUser.IsInRole(Roles))
                    {
                        filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Error", action = "AccessDenied" }));

                    }
                }
            }
        }
    }
}