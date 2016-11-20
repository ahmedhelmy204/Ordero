using Ordero.Core.Basis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordero.Core.Domain
{
    public class Order : AuditableEntity
    {
        public int? UserId { get; set; }
        public int? RestaurantId { get; set; }
        public int? MenuId { get; set; }
        public int TotalPrice { get; set; }

        public User User { get; set; }
        public Restaurant Restaurant { get; set; }
        public Menu Menu { get; set; }
    }
}
