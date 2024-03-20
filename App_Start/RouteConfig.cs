using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace KlioWebApplication
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

                routes.MapRoute(
                name: "Delete",
                url: "Home/Delete/{id}", // Replace 'ControllerName' with your actual controller name.
                defaults: new { controller = "Home", action = "Delete" }
            );


        }
    }
}
