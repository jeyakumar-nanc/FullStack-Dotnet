using System.Web.Http;
using System.Web.Http.Cors;

namespace ProjManagerSvc
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                    "DefaultApi",
                    "{controller}/{action}/{id}",
                    new
                    {
                        action = RouteParameter.Optional,
                        id = RouteParameter.Optional
                    }
            );

            EnableCorsAttribute cors = new EnableCorsAttribute("http://localhost:4200", "*", "GET,POST,PUT,DELETE");
            config.EnableCors(cors);
        }
    }
}
