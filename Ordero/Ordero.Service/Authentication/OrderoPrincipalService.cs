using Ordero.Core;
using Ordero.Core.Domain;
using Ordero.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Ordero.Service
{
    public class OrderoPrincipalService : GenericPrincipal, IOrderoPrincipalService
    {
        #region Fields

        private readonly IOrderoRepository<PermissionRole> _prrRepository;
        private readonly HttpContextBase _httpContext;
        private readonly IWorkContext _workContext;

        #endregion Fields


        public OrderoPrincipalService(string[] roles, IOrderoRepository<PermissionRole> prrRepository,
            HttpContextBase httpContext,
            IWorkContext workContext)
            : base(httpContext.User.Identity, roles)
        {
            _prrRepository = prrRepository;

            _httpContext = httpContext;
            _workContext = workContext;

            Identity = _httpContext.User.Identity;
            User = _workContext.CurrentUser;
        }

        public override IIdentity Identity
        {
            get;
        }

        /// <summary>
        /// indicate whether the current user identity in role
        /// by role name or id
        /// </summary>
        /// <param name="roleName">Role name</param>
        /// <returns>true: if user in role, false: otherwise</returns>
        public override bool IsInRole(string roleName)
        {
            if (Identity == null)
                return false;

            if (!Identity.IsAuthenticated)
                return false;

            if (User == null)
                return false;

            if (User.Role == null)
                return false;

            long roleId = 0;
            if (long.TryParse(roleName, out roleId))
            { return IsInRole(roleId); }
            else
            {

                //var roles = _userRoleRepository.Table
                //  .Where(ur => ur.UserId == User.Id && ur.Role.SystemName == roleName);

                // if (roles.Count() > 0)
                //   return true;

                bool isInRole = (User.Role.PermissionRecordRoles.Any(prr => prr.Permission.SystemName.ToLower() == roleName.ToLower()) ||
                                 User.Role.SystemName.ToLower() == roleName.ToLower());

                return isInRole;
            }

            //return false;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the user has been deleted
        /// indicate whether the current user identity in role
        /// by role id
        /// </summary>
        /// <param name="roleId">Role Id</param>
        /// <returnstrue: if user in role, false: otherwise></returns>
        private bool IsInRole(long roleId)
        {
            // may have performance issue
            // var roles = _prrRepository.Table
            //   .Where(prr => prr.PermissionRecordId == roleId && prr.Role.Users.Contains(User));

            //if (roles.Count() > 0)
            //  return true;

            bool isInRole = (User.Role.PermissionRecordRoles.Any(prr => prr.PermissionRecordId == roleId));

            return isInRole;
        }

        public User User
        {
            get;
        }
    }
}
