﻿namespace Andriy.Mvc4Application1.App_Start
{
    using System.Web.Http;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });

            foreach (var route in config.Routes)
            {
                var x = route.RouteTemplate;
            }
        }
    }
}
