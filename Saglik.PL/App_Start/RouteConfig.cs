using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Saglik.PL.App_Start
{

    namespace Blog.PL
    {
        public class RouteConfig
        {
            public static void RegisterRoutes(RouteCollection routes)
            {
                routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

                routes.MapRoute(
                    name: "Default",
                    url: "{controller}/{action}/{id}",
                    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                    namespaces: new[] { "Saglik.PL.Controllers" });

                routes.MapRoute(
                    name: "DefaultID",
                    url: "{controller}/{action}/{katid}/{altkatid}",
                    defaults: new
                    {
                        controller = "Home",
                        action = "Index",
                        katid = UrlParameter.Optional,
                        altkatid = UrlParameter.Optional
                    }
            );
            }
        }
    }
}



