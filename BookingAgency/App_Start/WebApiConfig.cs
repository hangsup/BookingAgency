using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BookingAgency {
    public static class WebApiConfig {
        public static void Register(HttpConfiguration config) {
            // Enable CORS for the entire API
            config.EnableCors();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            //config.MapHttpAttributeRoutes();
        }
    }
}