using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace PrudWeatherApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                            name: "WeatherService",
                            routeTemplate: "{controller}/{action}/{id}",
                            defaults: new { controller = "Weather", action = "GetCityWiseWeatherData", id = RouteParameter.Optional });
        }
    }
}
