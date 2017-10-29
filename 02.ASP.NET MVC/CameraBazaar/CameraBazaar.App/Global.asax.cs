namespace CameraBazaar.App
{
    using AutoMapper;
    using CameraBazaar.Models.BindingModels.Users;
    using CameraBazaar.Models.EntityModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ConfigAutomapper();
        }

        private static void ConfigAutomapper()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<RegisterUserBindingModel, User>();

            });
            
        }
    }
}
