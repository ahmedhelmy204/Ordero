using Ordero.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordero.Core.Security
{
    public class StandardPermissionProvider
    {
        //admin area permissions
        public static readonly Permission AccessAdminPanel = new Permission { Name = "Access admin area", SystemName = "AccessAdminPanel", Category = "Standard" };

        public static readonly Permission AccessSiteArea = new Permission { Name = "Access site area", SystemName = "AccessSiteArea", Category = "Standard" };

    }
}
