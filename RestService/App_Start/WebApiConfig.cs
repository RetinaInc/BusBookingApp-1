using System.Linq;
using System.Web.Http;
using Microsoft.Practices.Unity;
using RestService.DependencyResolver;
using Service.Bus;

namespace RestService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "service/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // remove xml
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(
                config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml"));

            // dependency resolver
            var container = new UnityContainer();
            container.RegisterType<IBusService, BusService>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new ScopeContainer(container);

    
        }
    }
}
