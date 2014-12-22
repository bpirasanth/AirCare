using AirCare.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirCare.Data.Configurations
{
    class PathConfiguration : EntityTypeConfiguration<Path>
    {
        public PathConfiguration()
        {
            HasRequired<Airport>(p => p.AirportIn)
            .WithMany(a => a.InPaths);

            HasRequired<Airport>(p => p.AirportOut)
            .WithMany(a => a.OutPaths);

        }
    }
}
