using Ordero.Core.Basis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordero.Core.Domain
{
    public partial class Permission : AuditableEntity
    {
        public Permission()
        {
            this.PermissionRoles = new HashSet<PermissionRole>();
        }

        public string Name { get; set; }
        public string SystemName { get; set; }
        public string Category { get; set; }

        public virtual ICollection<PermissionRole> PermissionRoles { get; set; }
    }
}
