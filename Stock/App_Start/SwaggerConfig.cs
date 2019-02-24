using System.Web.Http;
using WebActivatorEx;
using Stock;
using Swashbuckle.Application;
using Stock.GlobalClass;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace Stock
{
    /// <summary>
    /// Configure Swagger
    /// </summary>
    public class SwaggerConfig
    {
        /// <summary>
        /// Register Swagger configuration
        /// </summary>
        public static void Register()
        {
            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.RootUrl(req =>
                        {
                            var url = req.RequestUri.Scheme + "://" + req.RequestUri.Authority;
                            return url;
                        });
                        c.SingleApiVersion("v1", "Stock");
                        c.PrettyPrint();
                        c.IncludeXmlComments(Constant.XMLDocPath);
                        c.DescribeAllEnumsAsStrings();
                    })
                .EnableSwaggerUi(c => { c.DisableValidator(); });
        }
    }
}
