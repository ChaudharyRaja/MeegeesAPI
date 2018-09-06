using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using application.brain.Declaration;
using application.brain.Defination;
using meegees_api.Controllers;
using meegees_api.DependencyResolver;
using meegees_api.Pushers;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using Unity;
using Unity.Injection;


namespace meegees_api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            //var cors = new System.Web.Http.Cors.EnableCorsAttribute("*", "*", "*");
            //config.EnableCors(cors);
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.

            var container = new UnityContainer();
            container.RegisterType<IInterests, Interests>();
            container.RegisterType<IExternalResources, ExternalResources>();
            container.RegisterType<ICommon, Common>();
            container.RegisterType<IUserRepository, UserRepository>();
            //container.RegisterType<IHubContext<NotificationHub>>();

            config.DependencyResolver = new UnityResolver(container);

            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
