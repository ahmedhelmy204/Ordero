using Ordero.Core;
using Ordero.Core.Domain;
using Ordero.Core.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Ordero.Service
{
    /// <summary>
    /// Permission service
    /// </summary>
    public class PermissionService : IPermissionService
    {
        protected readonly IWorkContext _workContext;
        protected readonly HttpContextBase _httpContext;

        public PermissionService(IWorkContext workContext,
            HttpContextBase httpContext)
        {
            _workContext = workContext;
            _httpContext = httpContext;
        }

        public bool Authorize()
        {
            //var identity=_httpContext.User.Identity;

            return _httpContext.User.IsInRole(StandardPermissionProvider.AccessAdminPanel.SystemName) ||
                _httpContext.User.IsInRole(StandardPermissionProvider.AccessSiteArea.SystemName) ||
                   _httpContext.User.IsInRole(SystemUserRoleNames.Registered) ||
                   _httpContext.User.IsInRole(SystemUserRoleNames.Administrator);
        }

        /// <summary>
        /// Authorize permission
        /// </summary>
        /// <param name="permission">Permission record</param>
        /// <returns>true - authorized; otherwise, false</returns>
        public bool Authorize(Permission permission)
        {
            return Authorize(permission, _workContext.CurrentUser);
        }

        /// <summary>
        /// Authorize permission
        /// </summary>
        /// <param name="permission">Permission record</param>
        /// <param name="user">User</param>
        /// <returns>true - authorized; otherwise, false</returns>
        public bool Authorize(Permission permission, User user)
        {
            if (permission == null)
                return false;

            if (user == null)
                return false;

            return Authorize(permission.SystemName, user);
        }

        /// <summary>
        /// Authorize permission
        /// </summary>
        /// <param name="permissionRecordSystemName">Permission record system name</param>
        /// <param name="user">User</param>
        /// <returns>true - authorized; otherwise, false</returns>
        public bool Authorize(string permissionRecordSystemName, User user)
        {
            if (String.IsNullOrEmpty(permissionRecordSystemName))
                return false;

            //var userRoles = user.UserRoles.Where(ur => ur.Role.IsActive);
            //foreach (var role in userRoles)
            //{
            //    if (Authorize(permissionRecordSystemName, role.Role))
            //        return true;
            //}

            if (!user.Role.IsActive)
                return false;

            return Authorize(permissionRecordSystemName, user.Role);

            //return false;
        }

        /// <summary>
        /// Authorize permission
        /// </summary>
        /// <param name="permissionRecordSystemName">Permission record system name</param>
        /// <param name="role">Role</param>
        /// <returns>true - authorized; otherwise, false</returns>
        protected virtual bool Authorize(string permissionRecordSystemName, Role role)
        {
            if (String.IsNullOrEmpty(permissionRecordSystemName))
                return false;

            foreach (var permission in role.PermissionRecordRoles)
            {
                if (permission.Permission.SystemName.Equals(permissionRecordSystemName, StringComparison.InvariantCultureIgnoreCase))
                    return true;
            }

            return false;
        }
    }
}
