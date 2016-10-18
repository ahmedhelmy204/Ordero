using Ordero.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordero.Data
{
    public class DbInitializer : CreateDatabaseIfNotExists<OrderoEntities>
    {
        protected override void Seed(OrderoEntities context)
        {
            IList<Role> defaultRoles = new List<Role>();

            defaultRoles.Add(new Role() { Name = "Registered", SystemName = "Registered", InsertedOn = DateTime.Now, IsActive = true });

            //IList<Standard> defaultStandards = new List<Standard>();

            //defaultStandards.Add(new Standard() { StandardName = "Standard 1", Description = "First Standard" });
            //defaultStandards.Add(new Standard() { StandardName = "Standard 2", Description = "Second Standard" });
            //defaultStandards.Add(new Standard() { StandardName = "Standard 3", Description = "Third Standard" });

            //foreach (Standard std in defaultStandards)
            //    context.Standards.Add(std);

            base.Seed(context);
        }
    }
}
