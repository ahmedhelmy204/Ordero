using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordero.Service
{
    public partial interface IInstallationService
    {
        void InstallData(bool installSampleData = true);
    }
}
