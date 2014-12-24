using AirCare.Data;
using AirCare.Data.Core;
using AirCare.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Web;

namespace AirCare.Web.Models
{
    public class PrincipalUser : IPrincipal
    {
        public IIdentity Identity { get; private set; }
        public List<string> Roles { get; private set; }

        public PrincipalUser(IIdentity identity, List<string> roles)
        {
            Identity = identity;
            Roles = roles;
        }

        public static PrincipalUser GetCurrentUser()
        {
            PrincipalUser user = HttpContext.Current.User as PrincipalUser;
            if (user == null)
            {
                IUnitOfWork UnitOfWork = UowFactory.Create();
                user = PrincipalUser.GetPrincipalUser(UnitOfWork, HttpContext.Current.User.Identity);
                HttpContext.Current.User = user;
            }
            return user;
        }

        public static PrincipalUser GetPrincipalUser(IUnitOfWork UnitOfWork, IIdentity identity)
        {
            var user = UnitOfWork.GetEntityRepository<User>().GetAll()
               .FirstOrDefault(p => p.UserName == identity.Name);

            if (user == null)
                throw new HttpException((int)HttpStatusCode.Unauthorized, "Unautherized User");

            PrincipalUser mdl = new PrincipalUser(identity, user.Roles.Select(p => p.Name).ToList());
            return mdl;
        }


        public bool IsInRole(string role)
        {
            return Roles.Contains(role);
        }
    }
}