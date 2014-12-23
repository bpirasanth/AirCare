using AirCare.Model.Entities;
using AirCare.Web.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirCare.Web.Models
{
    public class UserModel : BaseModel
    {

        public void Save(UserViewModel userViewModel)
        {
            User user = new User();
            Mapper.CreateMap<UserViewModel, User>();

            user = Mapper.Map<UserViewModel, User>(userViewModel);

            UnitOfWork.GetEntityRepository<User>().InsertOrUpdate(user);
            UnitOfWork.Commit();

        }
    }
}