using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Mvc4Application1
{
    public class RouteConfig
    {
        public static readonly string[] Cultures = new[] { "en-GB", "en-US", "uk-UA" };

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Books",
                url: "Books/{id}",
                defaults: new { controller = "HelloWorld", action = "Books", id = UrlParameter.Optional },
                namespaces: new[] { "Mvc4Application1.Controllers" });

            routes.MapRoute(
                name: "Books2",
                url: "Books2/{id}",
                defaults: new { controller = "HelloWorld", action = "Books2", id = UrlParameter.Optional },
                constraints: new { id = @"\d+" },
                namespaces: new[] { "Mvc4Application1.Controllers" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Mvc4Application1.Controllers" });

            // add cultures for site as well as areas
            foreach (Route r in routes)
            {
                if (!(r.RouteHandler is SingleCultureMvcRouteHandler))
                {
                    r.RouteHandler = new MultiCultureMvcRouteHandler();
                    r.Url = "{culture}/" + r.Url;

                    // Adding default culture 
                    if (r.Defaults == null)
                    {
                        r.Defaults = new RouteValueDictionary();
                    }

                    r.Defaults.Add("culture", Cultures[0]);

                    // Adding constraint for culture param
                    if (r.Constraints == null)
                    {
                        r.Constraints = new RouteValueDictionary();
                    }

                    r.Constraints.Add("culture", new CultureConstraint(Cultures));
                }
            }
        }

        public class CultureConstraint : IRouteConstraint
        {
            private readonly string[] values;
            
            public CultureConstraint(params string[] values)
            {
                this.values = values;
            }

            public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary vals, RouteDirection routeDirection)
            {
                // Get the value called "parameterName" from the 
                // RouteValueDictionary called "value"
                string value = vals[parameterName].ToString();
                
                // Return true is the list of allowed values contains 
                // this value.
                return this.values.Contains(value);
            }
        }
    }
}