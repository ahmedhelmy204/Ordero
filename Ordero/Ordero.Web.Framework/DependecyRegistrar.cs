using Microsoft.Practices.Unity;
using Ordero.Core;
using Ordero.Core.Caching;
using Ordero.Data;
using Ordero.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Unity.Mvc5;

namespace Ordero.Web.Framework
{
    /// <summary>
    /// Dependency registrar
    /// </summary>
    public static class DependecyRegistrar
    {
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            return container;
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            //// dependencies
            //var config = ConfigurationManager.GetSection("SoaalyConfig") as SoaalyConfig;
            //var typeFinder = new WebAppTypeFinder(config);
            //container.RegisterInstance(typeof(SoaalyConfig), config);
            ////container.RegisterInstance<IEngine>(this);
            //container.RegisterInstance<ITypeFinder>(typeFinder);

            // e.g. container.RegisterType<ITestService, TestService>();    
            RegisterTypes(container);

            //RegisterSettings(container, typeFinder);

            return container;
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<HttpContextBase>(new InjectionFactory(c => new HttpContextWrapper(HttpContext.Current)));
            //        container.RegisterType<HttpRequestBase>(new InjectionFactory(_ =>
            //new HttpRequestWrapper(HttpContext.Current.Request)));

            //        container.RegisterType<HttpResponseBase>(new InjectionFactory(_ =>
            //            new HttpResponseWrapper(HttpContext.Current.Response)));

            container.RegisterType<IWorkContext, WebWorkContext>();
            //container.RegisterType<ICacheManager, WebCacheManager>();
            container.RegisterType<ICacheManager, PerRequestCacheManager>();

            // configurations

            // helpers
            //container.RegisterType<IWebHelper, WebHelper>();

            // context
            container.RegisterType<IDbContext, OrderoEntities>(new PerResolveLifetimeManager());
            container.RegisterType<IDbOrderoContext, OrderoEntities>(new PerResolveLifetimeManager());

            // repository
            container.RegisterType(typeof(IRepository<>), typeof(EfRepository<>));
            container.RegisterType(typeof(IOrderoRepository<>), typeof(EfOrderoRepository<>));

            // authentication
            container.RegisterType<IAuthenticationService, FormsAuthenticationService>();
            container.RegisterType<IOrderoPrincipalService, OrderoPrincipalService>();

            // security
            container.RegisterType<IEncryptionService, EncryptionService>();
            container.RegisterType<IPermissionService, PermissionService>();

            // common
            container.RegisterType<IOrderoResult, OrderoResult>();

            // users
            container.RegisterType<IUserRegistrationService, UserRegistrationService>();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IRoleService, RoleService>();

            // localization

            // seo

            // logging

            // media

            // routes

            // search

        }
    }
}
