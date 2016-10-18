using Ordero.Core;
using Ordero.Core.Domain;
using Ordero.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Ordero.Web.Framework
{
    public class WebWorkContext : IWorkContext
    {
        #region Fields
        
        private readonly IAuthenticationService _authenticationService;

        private readonly HttpContextBase _httpContext;
        

        #endregion Fields

        public WebWorkContext(IAuthenticationService authenticationService,
             HttpContextBase httpContext)
        {
            _authenticationService = authenticationService;
            _httpContext = httpContext;
        }

        //protected virtual void SetUserCookie()

        /// <summary>
        /// Gets or sets the current user
        /// </summary>
        public virtual User CurrentUser
        {
            get
            {
                User user = null;

                // registerd user
                if (user == null || user.IsDeleted || !user.IsActive)
                {
                    user = _authenticationService.GetAuthenticatedUser();
                }

                // if cached return the cached one
                user = _authenticationService.GetAuthenticatedUser();
                return user;
            }

            set
            {
                // TODO Set current user
                throw new NotImplementedException();
            }
        }
        
    }
}
