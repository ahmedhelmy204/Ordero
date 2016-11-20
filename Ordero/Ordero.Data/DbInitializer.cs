using Ordero.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordero.Data
{
    public class DbInitializer: DropCreateDatabaseIfModelChanges<OrderoEntities>
    {
        public DbInitializer()
        {
           
        }

        protected override void Seed(OrderoEntities context)
        {
            IList<Role> defaultRoles = new List<Role>();

            defaultRoles.Add(new Role() { Name = "Registered", SystemName = "Registered", InsertedOn = DateTime.Now, IsActive = true });

           
            context.Roles.AddRange(defaultRoles);
            base.Seed(context);
        }
    }
}
