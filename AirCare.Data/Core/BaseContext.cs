using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace AirCare.Data.Core
{
    public class BaseContext : DbContext
    {
        public BaseContext(string connectionStringName) : base(connectionStringName) { }

        public void ChangeObjectState(object entity, EntityState entityState)
        {
            ((IObjectContextAdapter)this).ObjectContext.ObjectStateManager.ChangeObjectState(entity, entityState);
        }
    }
}
