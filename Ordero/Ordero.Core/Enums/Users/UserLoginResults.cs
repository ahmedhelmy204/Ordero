using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordero.Core.Enums
{
    /// <summary>
    /// Represents the user login result enumeration
    /// </summary>
    public enum UserLoginResults
    {
        /// <summary>
        /// Login successful
        /// </summary>
        Successful = 1,
        /// <summary>
        /// User dies not exist (email or username)
        /// </summary>
        UserNotExist = 2,
        /// <summary>
        /// Wrong password
        /// </summary>
        WrongPassword = 3,
        /// <summary>
        /// Account has not been activated
        /// </summary>
        NotActive = 4,
        /// <summary>
        /// User has been deleted
        /// </summary>
        Deleted = 5,
        /// <summary>
        /// User not registered
        /// </summary>
        NotRegistered = 6
    }
}
