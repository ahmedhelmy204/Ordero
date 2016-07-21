using Ordero.Core.Basis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordero.Core.Domain.Users
{
    /// <summary>
    /// Represents a user
    /// </summary>
    public partial class User : AuditableEntity
    {
        /// <summary>
        /// Gets or sets username
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets email address
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets password salt
        /// </summary>
        public string PasswordSalt { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user is active
        /// </summary>
        /// <remarks>true: if user is active, false: otherwise</remarks>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user has been deleted
        /// </summary>
        /// <remarks>true: if user has been deleted, false: otherwise</remarks>
        public bool IsDeleted { get; set; }
    }
}
