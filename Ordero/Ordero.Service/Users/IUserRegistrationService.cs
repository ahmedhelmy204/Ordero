using Ordero.Core.Domain;
using Ordero.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordero.Service
{
    /// <summary>
    /// User registration service interface
    /// </summary>
    public partial interface IUserRegistrationService
    {
        /// <summary>
        /// Validate user
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// <returns>Result</returns>
        UserLoginResults ValidateUser(string username, string password);

        /// <summary>
        /// Register user
        /// </summary>
        /// <param name="user">User</param>
        /// <returns>Result</returns>
        IOrderoResult RegisterUser(User user);

        /// <summary>
        /// Change password
        /// </summary>
        /// <param name="request">Request</param>
        /// <returns>Result</returns>
        IOrderoResult ChangePassword(ChangePasswordRequest request);
    }
}
