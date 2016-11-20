using Ordero.Core.Basis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordero.Core.Domain
{
    public class OrderDetail : AuditableEntity
    {
        public int OrderId { get; set; }
        public int MenuItemId { get; set; }

        public Order Order { get; set; }
        public MenuItem MenuItem { get; set; }
    }
}
