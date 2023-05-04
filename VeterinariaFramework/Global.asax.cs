using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Unity;
using Unity.AspNet.Mvc;
using Unity.Lifetime;
using VeterinariaFramework.Interfaz;
using VeterinariaFramework.Models;

namespace VeterinariaFramework
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var container = new UnityContainer();
            container.RegisterType<IVeterinariaDbContext, VeterinariaDbContext>(new HierarchicalLifetimeManager());

            // Registra aqu� las dem�s dependencias que necesites

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            // Configuraci�n de Web API y otros middlewares aqu�
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
