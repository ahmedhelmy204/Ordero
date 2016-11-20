using Ordero.Core.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordero.Core.Domain
{
    public static class UserExtensions
    {
        /// <summary>
        /// Gets a value indicating whether user is in a certain user role
        /// </summary>
        /// <param name="user">User</param>
        /// <param name="userRoledSystemName">User role system name</param>
        /// <param name="onlyActiveUserRoles">A value indicating whether we should look only in active customer roles</param>
        /// <returns>Result</returns>
        public static bool IsInUserRole(this User user, string userRoledSystemName, bool onlyActiveUserRoles = true)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            if (string.IsNullOrEmpty(userRoledSystemName))
                throw new ArgumentNullException("userRoledSystemName");

            //var result = user.UserRoles
            //    .FirstOrDefault(ur => (!onlyActiveUserRoles || ur.Role.IsActive) && (ur.Role.SystemName == userRoledSystemName)) != null;

            bool result = false;

            if (user.Role == null)
                return false;

            if (!onlyActiveUserRoles || user.Role.IsActive)
            {
                result = ((user.Role.SystemName == userRoledSystemName) ||
                    (user.Role.PermissionRecordRoles.Any(prr => prr.Permission.SystemName == userRoledSystemName)));
            }

            return result;
        }

        /// <summary>
        /// Gets a value indicating whether user is registerd
        /// </summary>
        /// <param name="user">User</param>
        /// <param name="onlyActiveUserRoles">A value indicating whther we should look only in active user roles</param>
        /// <returns>Result</returns>
        public static bool IsRegistered(this User user, bool onlyActiveUserRoles = true)
        {
            return IsInUserRole(user, StandardPermissionProvider.AccessSiteArea.SystemName, onlyActiveUserRoles);
        }


        public static string GetUsername(this User user)
        {
            if (!String.IsNullOrEmpty(user.Username))
                return user.Username;

            if (!String.IsNullOrEmpty(user.Email))
                return user.Email;

            if (!String.IsNullOrEmpty(user.Id.ToString()))
                return user.Id.ToString();


            return "";
        }


    }
}
