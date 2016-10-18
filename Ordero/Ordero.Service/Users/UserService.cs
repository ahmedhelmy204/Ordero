using Ordero.Core.Domain;
using Ordero.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordero.Service
{
    /// <summary>
    /// User service
    /// </summary>
    public class UserService : IUserService
    {
        #region Fields

        private readonly IOrderoRepository<User> _userRepository;
        private readonly IEncryptionService _encryptionService;

        #endregion Fields

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="userRepository"></param>
        /// <param name="encryptionService"></param>
        public UserService(IOrderoRepository<User> userRepository,
            IEncryptionService encryptionService)
        {
            _userRepository = userRepository;

            _encryptionService = encryptionService;
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// Gets a user by identifier
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns>User</returns>
        public User GetUserById(object id)
        {
            return _userRepository.GetById(id);
        }

        /// <summary>
        /// Get user by username
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>User</returns>
        public User GetUserByUsername(string username)
        {
            User user = _userRepository.Table.Where(u => u.Username == username).SingleOrDefault();
            return user;
        }

        /// <summary>
        /// Get user by email
        /// </summary>
        /// <param name="email">Email</param>
        /// <returns>User</returns>
        public User GetUserByEmail(string email)
        {
            return _userRepository.Table.Where(u => u.Email == email).SingleOrDefault();
        }

        /// <summary>
        /// Insert a user
        /// </summary>
        /// <param name="user">User</param>
        public void InsertUser(User user)
        {
            string saltKey = _encryptionService.CreateSaltKey(5);
            user.PasswordSalt = saltKey;
            user.Password = _encryptionService.CreatePasswordHash(user.Password, saltKey);

            _userRepository.Insert(user);
        }

        public void RegisterUser(User user)
        {
            _userRepository.Insert(user);
        }

        public void UpdateUser(User user)
        {
            _userRepository.Update(user);
        }

        #endregion Methods
    }
}
