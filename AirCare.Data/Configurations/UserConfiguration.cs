using AirCare.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirCare.Data.Configurations
{
    class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            HasMany(u => u.Roles).WithMany(r => r.Users).Map
                (m =>
                {
                    m.ToTable("UserRole");
                    m.MapLeftKey("UserId");
                    m.MapRightKey("RoleId");
                });
        }
    }
}
