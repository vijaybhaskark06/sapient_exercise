using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.Practices.Unity;
using GM_MVC_API.Controllers;
using GM_MVC_API.Models;
using GM_MVC_API.Helper;
using System.Data.Entity;

namespace GM_MVC_API
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        void ConfigureApi(HttpConfiguration config)
        {
            var unity = new UnityContainer();
            unity.RegisterType<ProductsController>();
            unity.RegisterType<IProductRepository, ProductRepository>(
                new HierarchicalLifetimeManager());
            config.DependencyResolver = new IoCContainer(unity);
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ConfigureApi(GlobalConfiguration.Configuration);
            Database.SetInitializer(new ProductInitializer());
        }
    }
}