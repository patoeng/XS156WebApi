using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Microsoft.Practices.Unity;
using XS156WebApi.Helper;
using XS156WebApi.Models.Persistence;

namespace XS156WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            var json = config.Formatters.JsonFormatter;

            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            config.Formatters.Remove(config.Formatters.XmlFormatter);


            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
            name: "DefaultApiWithAction",
            routeTemplate: "api/{controller}/{action}/{id}",
            defaults: new { id = RouteParameter.Optional }
            );

            var container = new UnityContainer();
            container.RegisterType<Xs156DbContext>(
                new InjectionFactory(c => new Xs156DbContext()));
            
            container.RegisterType<IProductReferenceRepository, ProductReferenceRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IEquipmentRepository, EquipmentRepository>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);

            
        }
    }
}
