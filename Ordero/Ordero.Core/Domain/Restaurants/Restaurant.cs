using Ordero.Core.Basis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordero.Core.Domain
{
    public class Restaurant : AuditableEntity
    {
        public Restaurant()
        {
            this.Menus = new HashSet<Menu>();
        }

        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Menu> Menus { get; set; }
    }
}
