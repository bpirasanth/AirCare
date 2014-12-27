using AirCare.Model.Entities;
using AirCare.Web.Common;
using AirCare.Web.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace AirCare.Web.Models
{
    public class UserModel : BaseModel
    {

        public void Save(UserViewModel userViewModel)
        {
            User user = new User();
            Mapper.CreateMap<UserViewModel, User>();
            if (UnitOfWork.GetEntityRepository<User>().GetAll().Count(p => p.UserName.Equals(userViewModel.UserName)) > 0)
                throw new ArgumentException("User name already exists. Please enter a different user name.");

            SHA1CryptoServiceProvider sha1csp = new SHA1CryptoServiceProvider();
            user = Mapper.Map<UserViewModel, User>(userViewModel);
            user.Sha1Password = sha1csp.ComputeHash(Encoding.Unicode.GetBytes(userViewModel.Password));

            UnitOfWork.GetEntityRepository<User>().InsertOrUpdate(user);
            UnitOfWork.Commit();

        }

        public Role GetClientRole()
        {
            return UnitOfWork.GetEntityRepository<Role>().GetAll()
                    .FirstOrDefault(p => p.Name == EnumRoles.Client);
        }
    }
}