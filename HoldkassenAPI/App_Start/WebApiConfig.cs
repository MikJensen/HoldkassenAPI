using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using HoldkassenAPI.Shared.Filters;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using Spring.Context.Support;
using Spring.Web.Mvc;

namespace HoldkassenAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));
            config.Filters.Add(new ExceptionFilter());
            config.Filters.Add(new ValidateFilter());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{id}",
                new { id = RouteParameter.Optional }
            );

            // Configuration of Spring injection.
            config.DependencyResolver = new SpringWebApiDependencyResolver(ContextRegistry.GetContext());
        }
    }
}
