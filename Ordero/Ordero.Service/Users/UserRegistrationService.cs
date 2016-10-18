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
    /// User registration service
    /// </summary>
    public partial class UserRegistrationService : IUserRegistrationService
    {
        #region Fields

        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly IOrderoResult _orderoResult;
        private readonly IEncryptionService _encryptionService;
        //..

        #endregion Fields

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="userService">User service</param>
        /// <param name="roleService">Role service</param>
        /// <param name="soaalyResult">Soaaly Result</param>
        /// <param name="encryptionService">Encryption service</param>
        public UserRegistrationService(IUserService userService,
            IRoleService roleService,
            IOrderoResult orderoResult,
            IEncryptionService encryptionService)
        {
            _userService = userService;
            _roleService = roleService;

            _orderoResult = orderoResult;
            _encryptionService = encryptionService;
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// Validate user
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// <returns>Result</returns>
        public UserLoginResults ValidateUser(string username, string password)
        {
            User user = _userService.GetUserByUsername(username);

            if (user == null)
                return UserLoginResults.UserNotExist;
            if (user.IsDeleted)
                return UserLoginResults.Deleted;
            if (!user.IsActive)
                return UserLoginResults.NotActive;
            // only registered can login
            if (!user.IsRegistered())
                return UserLoginResults.NotRegistered;

            string hashedPassword = _encryptionService.CreatePasswordHash(password, user.PasswordSalt);
            bool isValid = hashedPassword == user.Password;
            if (!isValid)
                return UserLoginResults.WrongPassword;

            // TODO: save last login date

            return UserLoginResults.Successful;
        }

        /// <summary>
        /// Register user
        /// </summary>
        /// <param name="user">User</param>
        /// <returns>Result</returns>
        public virtual IOrderoResult RegisterUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            //var result = new UserRegistrationResult();

            if (user.IsRegistered())
            {
                _orderoResult.AddError("User is already registered.");
                return _orderoResult;
            }

            if (string.IsNullOrEmpty(user.Username))
            {
                _orderoResult.AddError("Username is not provided");
                return _orderoResult;
            }



            if (string.IsNullOrEmpty(user.Email))
            {
                _orderoResult.AddError("Email is not provided");
                return _orderoResult;
            }

            // TODO: check valid email address

            if (string.IsNullOrEmpty(user.Password))
            {
                _orderoResult.AddError("Password is not provided");
                return _orderoResult;
            }

            // TODO: validate unique username
            // TODO: validate unique email

            string saltKey = _encryptionService.CreateSaltKey(5);
            user.PasswordSalt = saltKey;
            user.Password = _encryptionService.CreatePasswordHash(user.Password, saltKey);

            // TODO: register roles
            var registeredRole = _roleService.GetRoleBySystemName(SystemUserRoleNames.Registered);

            if (registeredRole == null)
                throw new Exception("'Registered' role could not be loaded.");
            //UserRole userRole = new UserRole()
            //{
            //    RoleId = registeredRole.Id,
            //    UserId = user.Id,
            //    InsertedOn = DateTime.Now
            //};

            //user.UserRoles.Add(userRole);
            user.RoleId = registeredRole.Id;

            // Add reward points for user registration (if enabled)

            //user.UserRoles.Add()

            _userService.RegisterUser(user);

            return _orderoResult;
        }

        /// <summary>
        /// Change password
        /// </summary>
        /// <param name="user">User</param>
        /// <returns>Result</returns>
        public IOrderoResult ChangePassword(ChangePasswordRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            // errors may be localized

            if (String.IsNullOrWhiteSpace(request.Email))
            {
                _orderoResult.AddError("Email is not provided");
                return _orderoResult;
            }

            if (String.IsNullOrWhiteSpace(request.NewPassword))
            {
                _orderoResult.AddError("Password is not provided");
                return _orderoResult;
            }

            var user = _userService.GetUserByEmail(request.Email);

            if (user == null)
            {
                _orderoResult.AddError("Email not found");
                return _orderoResult;
            }

            var requestIsValid = false;
            if (request.ValidateRequest)
            {
                // password
                string oldPassword = "";
                oldPassword = _encryptionService.CreatePasswordHash(request.OldPassword, user.PasswordSalt);

                bool oldPasswordIsValid = oldPassword == user.Password;
                if (!oldPasswordIsValid)
                    _orderoResult.AddError("Old password does not match");

                if (oldPasswordIsValid)
                    requestIsValid = true;
            }
            else
                requestIsValid = true;

            // at this point request is valid
            if (requestIsValid)
            {
                string saltKey = _encryptionService.CreateSaltKey(5);
                user.PasswordSalt = saltKey;
                user.Password = _encryptionService.CreatePasswordHash(request.NewPassword, saltKey);

                _userService.UpdateUser(user);
            }

            return _orderoResult;
        }

        #endregion Methods


    }
}
