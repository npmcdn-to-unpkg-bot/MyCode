using System.Web.Http;
using System.Web.Http.Cors;

namespace TLMManager
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // TODO: Add any additional configuration code.

            // Web API routes
            config.MapHttpAttributeRoutes();

            // enable cors
            var cors = new EnableCorsAttribute("http://127.0.0.1:8020", "*", "*");
            config.EnableCors(cors);

            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{action}/{id}",
                new { id = RouteParameter.Optional }
                );
        }
    }
}