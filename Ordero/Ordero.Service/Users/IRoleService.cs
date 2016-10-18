using Ordero.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordero.Service
{
    /// <summary>
    /// Role service interface
    /// </summary>
    public interface IRoleService
    {
        /// <summary>
        /// Get a Role
        /// </summary>
        /// <param name="systemName">Role system name</param>
        /// <returns>Role</returns>
        Role GetRoleBySystemName(string systemName);
    }
}
