using Ordero.Core.Basis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordero.Core.Domain
{
    public partial class Role : AuditableEntity
    {
        public Role()
        {
            this.PermissionRecordRoles = new HashSet<PermissionRole>();
            this.Users = new HashSet<User>();
        }

        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string SystemName { get; set; }

        public virtual ICollection<PermissionRole> PermissionRecordRoles { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
