using Ordero.Core.Basis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordero.Core.Domain
{
    public class Menu : AuditableEntity
    {
        public string Name { get; set; }
        public bool IsCurrent { get; set; }
        public int RestaurantId { get; set; }

        public Restaurant Restaurant { get; set; }
        public ICollection<MenuItem> MenuItems { get; set; }
    }
}
