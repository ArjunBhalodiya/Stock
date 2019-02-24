using System.Net.Http.Headers;
using System.Web.Http;
using Stock.Repositories;
using Unity;
using Unity.Lifetime;

namespace Stock
{
    /// <summary>
    /// Configure Web API
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Register base configuration of API
        /// </summary>
        /// <param name="config"></param>
        public static void Register(HttpConfiguration config)
        {
            // Initialize unity container
            var container = new UnityContainer();

            // Register all interfaces
            container.RegisterType<ICompanyDetailRepository, CompanyDetailRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IStockPriceRepository, StockPriceRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IImportFile, ImportFile>(new HierarchicalLifetimeManager());

            // Resolve dependency
            config.DependencyResolver = new UnityResolver(container);

            // Set JSON as default formatter
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));

            // Map all http routes
            config.MapHttpAttributeRoutes();
        }
    }
}
