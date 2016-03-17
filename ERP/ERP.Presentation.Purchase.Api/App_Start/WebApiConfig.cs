using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ERP.Services.PurchaseServices.DependencyInjector;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;

namespace ERP.Presentation.Purchase.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();
            container = DependencyInjectorManager.RegisterDependencies(container);
            //container.Verify();
            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
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
