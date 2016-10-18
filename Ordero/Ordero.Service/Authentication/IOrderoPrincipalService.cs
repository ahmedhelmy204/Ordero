using Ordero.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Ordero.Service
{
    public interface IOrderoPrincipalService : IPrincipal
    {
        User User { get; }
    }
}
