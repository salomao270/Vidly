using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Vidly
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "MoviesByReleaseDate",
                "movies/released/{year}/{month}",
                new { controller = "Movies", action = "ByReleaseDate"},
                // new { year = "\\d{4}", month = "\\d{2}" });      // without @"" must insert one more \ just like: \\d instead of \d
                // new { year = @"\d{4}", month = @"\d{2}" });      // Regular Expression, \d represents digit number
                new { year = @"2015|2016", month = @"\d{2}" });         // limiting year parameter from 2015 to 2016

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}