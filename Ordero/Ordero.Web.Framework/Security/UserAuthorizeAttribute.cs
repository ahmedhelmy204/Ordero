using Ordero.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Ordero.Web.Framework.Security
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class UserAuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new HttpUnauthorizedResult();
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext == null)
                throw new ArgumentNullException("filterContext");

            if (filterContext.HttpContext.User == null)
                throw new ArgumentNullException("filterContext.HttpContext.User");

            //// don't apply filter to child methods
            //if (filterContext.IsChildAction)
            //    return;

            // only redirect for GET requests,
            // otherwise the browser might not propagate the verb and request body correctly.
            if (!string.Equals(filterContext.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
                return;



            var _principalService = DependencyResolver.Current.GetService<IOrderoPrincipalService>();

            //var _permissionService = DependencyResolver.Current.GetService<IPermissionService>();

            //if (!_permissionService.Authorize())
            //{
            //    this.HandleUnauthorizedRequest(filterContext);
            //}






            if (_principalService.User == null)
                this.HandleUnauthorizedRequest(filterContext);

            if (!_principalService.Identity.IsAuthenticated)
                this.HandleUnauthorizedRequest(filterContext);


            filterContext.HttpContext.User = _principalService;

            // if using Authorize attribute only
            base.OnAuthorization(filterContext);


        }
    }
}
