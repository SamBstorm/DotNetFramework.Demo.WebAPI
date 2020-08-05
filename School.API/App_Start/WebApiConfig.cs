﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace School.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuration et services API Web

            // Itinéraires de l'API Web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "Test",
                routeTemplate: "apiTest/{controller}/{action}/{id}",
                defaults: new { controller = "Student", action = "Get", id = RouteParameter.Optional }
                );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
