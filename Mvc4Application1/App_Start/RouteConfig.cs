namespace Andriy.Mvc4Application1
{
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;

    using Andriy.Mvc4Application1.RouteHandlers;

    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Books",
                url: "Books/{id}",
                defaults: new { controller = "HelloWorld", action = "Books", id = UrlParameter.Optional },
                namespaces: new[] { "Andriy.Mvc4Application1.Controllers" });

            routes.MapRoute(
                name: "Books2",
                url: "Books2/{id}",
                defaults: new { controller = "HelloWorld", action = "Books2", id = UrlParameter.Optional },
                constraints: new { id = @"\d+" },
                namespaces: new[] { "Andriy.Mvc4Application1.Controllers" });

            routes.MapRoute(
                name: "Default",
                url: "{culture}/{controller}/{action}/{id}",
                defaults: new
                {
                    culture = Localization.Culture.Cultures.First().Key,
                    controller = "Home", 
                    action = "Index", id = UrlParameter.Optional
                },
                namespaces: new[] { "Andriy.Mvc4Application1.Controllers" },
                constraints: new RouteValueDictionary { { "culture", new CultureConstraint(Localization.Culture.Cultures.Select(c => c.Key).ToArray()) } })
                .RouteHandler = new MultiCultureMvcRouteHandler();
            

            // Add cultures for site as well as areas
            // adds routes where not appropriate
            ////foreach (Route r in routes)
            ////{
            ////    if (!(r.RouteHandler is SingleCultureMvcRouteHandler) 
            ////        && !r.Url.StartsWith("api/"))
            ////    {
            ////        r.RouteHandler = new MultiCultureMvcRouteHandler();
            ////        r.Url = "{culture}/" + r.Url;

            ////        // Adding default culture 
            ////        if (r.Defaults == null)
            ////        {
            ////            r.Defaults = new RouteValueDictionary();
            ////        }

            ////        r.Defaults.Add("culture", Cultures[0]);

            ////        // Adding constraint for culture param
            ////        if (r.Constraints == null)
            ////        {
            ////            r.Constraints = new RouteValueDictionary();
            ////        }

            ////        r.Constraints.Add("culture", new CultureConstraint(Cultures));
            ////    }
            ////}
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