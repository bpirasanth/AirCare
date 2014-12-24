using AirCare.Model.Entities;
using AirCare.Web.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirCare.Web.Models
{
    public class PassengerModel:BaseModel
    {
        public void Save(PassengerViewModel passengerViewModel)
        {
            Passenger passenger = new Passenger();
            Mapper.CreateMap<PassengerViewModel, Passenger>();
            passenger = Mapper.Map<PassengerViewModel, Passenger>(passengerViewModel);
            UnitOfWork.GetEntityRepository<Passenger>().InsertOrUpdate(passenger);
            UnitOfWork.Commit();
        
        
        }
    }
}