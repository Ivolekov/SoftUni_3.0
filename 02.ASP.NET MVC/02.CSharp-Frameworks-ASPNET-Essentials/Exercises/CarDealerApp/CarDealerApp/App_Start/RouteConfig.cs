using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CarDealerApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();
            //
            //routes.MapRoute(
            //    name: "Customers All",
            //    url: "customers/all/{order}",
            //    defaults: new
            //    {
            //        controller = "Customers",
            //        action = "Index",
            //        order = "all"
            //    }
            //);
            //routes.MapRoute(
            //    name: "Customers Sales",
            //    url: "customers/{id}",
            //    defaults: new
            //    {
            //        controller = "Customers",
            //        action = "Sales",
            //        id = 1
            //    }
            //);
            // routes.MapRoute(
            //    name: "Cars",
            //    url: "cars/{make}",
            //    defaults: new
            //    {
            //        controller = "Cars",
            //        action = "Index",
            //        make = ""
            //    }
            //);
            //  routes.MapRoute(
            //    name: "Cars Parts",
            //    url: "Cars/{id}/Parts",
            //    defaults: new
            //    {
            //        controller = "Cars",
            //        action = "Parts",
            //        id = 1
            //    }
            //);
            // routes.MapRoute(
            //    name: "Supplyers",
            //    url: "suppliers/{supplyerType}",
            //    defaults: new
            //    {
            //        controller = "Suppliers",
            //        action = "Index",
            //        supplyerType = ""
            //    }
            //);
            // routes.MapRoute(
            //    name: "Sales All",
            //    url: "Sales",
            //    defaults: new
            //    {
            //        controller = "Sales",
            //        action = "Index"
            //    }
            //);
            // routes.MapRoute(
            //    name: "Sales Details",
            //    url: "Sales/{id}",
            //    defaults: new
            //    {
            //        controller = "Sales",
            //        action = "Details",
            //        id = UrlParameter.Optional
            //    }
            //);
            // routes.MapRoute(
            //    name: "Discount Sales",
            //    url: "Sales/Discount/{percent}",
            //    defaults: new
            //    {
            //        controller = "Sales",
            //        action = "Discount",
            //        percent = UrlParameter.Optional
            //    }
            //);
            // routes.MapRoute(
            //    name: "Discount Sales All",
            //    url: "Sales/Discount",
            //    defaults: new
            //    {
            //        controller = "Sales",
            //        action = "Discount",
            //        percent = UrlParameter.Optional
            //    }
            //);
            //

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
