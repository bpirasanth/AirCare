using AirCare.Model.Entities;
using AirCare.Web.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirCare.Web.Models
{
    public class AirportModel:BaseModel
    {
        public void Save(AirportViewModel airportViewModel)
        {
            Airport airport = new Airport();
            Mapper.CreateMap<AirportViewModel, Airport>();
            airport = Mapper.Map<AirportViewModel, Airport>(airportViewModel);
            UnitOfWork.GetEntityRepository<Airport>().InsertOrUpdate(airport);
            UnitOfWork.Commit();

        }
    }
}