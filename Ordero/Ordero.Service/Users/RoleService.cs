using Ordero.Core.Caching;
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
    /// Role service
    /// </summary>
    public class RoleService : IRoleService
    {
        #region Constants

        /// <summary>
        /// Key for caching
        /// </summary>
        private const string ROLES_BY_SYSTEMNAME_KEY = "ordero.role.systemname";

        #endregion Constants

        #region Fields

        private readonly IOrderoRepository<Role> _roleRepository;
        private readonly ICacheManager _cacheManager;

        #endregion Fields

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="roleRepository"></param>
        /// <param name="cacheManager"></param>
        public RoleService(IOrderoRepository<Role> roleRepository,
            ICacheManager cacheManager)
        {
            _roleRepository = roleRepository;

            _cacheManager = cacheManager;
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// Get a role
        /// </summary>
        /// <param name="systemName">Role system name</param>
        /// <returns>Role</returns>
        public Role GetRoleBySystemName(string systemName)
        {
            if (String.IsNullOrEmpty(systemName))
                return null;

            return _cacheManager.Get(ROLES_BY_SYSTEMNAME_KEY, () =>
            {
                var query = from r in _roleRepository.Table
                            orderby r.Id
                            where r.SystemName == systemName
                            select r;

                return query.FirstOrDefault();
            });
        }

        #endregion Methods
    }
}
