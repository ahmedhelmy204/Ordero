using Ordero.Core.Domain;
using Ordero.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordero.Service
{
    public partial class CodeFirstInstallationService : IInstallationService
    {
        #region Fields

        private readonly IRepository<Role> _roleRepository;

        #endregion Fields

        #region Constructor

        public CodeFirstInstallationService(IRepository<Role> roleRepository)
        {
            _roleRepository = roleRepository;
        }

        #endregion Constructor

        #region Utilities

        public void InstallRoles()
        {
            var registeredRole = new Role
            {
                Name = "Registered",
                IsActive = true,
                SystemName = SystemUserRoleNames.Registered,
            };
            var userRoles = new List<Role>
            {
                registeredRole
            };
            _roleRepository.Insert(userRoles);
        }

        #endregion Utilities

        #region Methods

        public void InstallData(bool installSampleData = true)
        {
            InstallRoles();
        }

        #endregion Methods
    }
}
