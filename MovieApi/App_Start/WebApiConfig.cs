using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MovieApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "MovieApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Ensures that the API only responds in JSON format
            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}
