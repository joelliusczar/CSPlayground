using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Autho
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
        }

        public static void RegisterExtraRoutes()
        {
            RazorViewEngine viewEngine = (RazorViewEngine)ViewEngines.Engines
                .Where(e => e.GetType() == typeof(RazorViewEngine)).FirstOrDefault();
            string[] extraViewPaths = new[] {
                "~/Views/Home/BundleExps/{0}.cshtml"
            };
            viewEngine.ViewLocationFormats = viewEngine.ViewLocationFormats.Union(extraViewPaths).ToArray();
        }
    }
}
