using AirCare.Model.Entities;
using AirCare.Web.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace AirCare.Web.Models
{
    public class FlightModel:BaseModel
    {
        public void Save(FlightViewModel flightViewModel)
        {
            Flight flight = new Flight();
            Mapper.CreateMap<FlightViewModel, Flight>();
            flight = Mapper.Map<FlightViewModel, Flight>(flightViewModel);
            UnitOfWork.GetEntityRepository<Flight>().InsertOrUpdate(flight);
            UnitOfWork.Commit();

        }
    }
}