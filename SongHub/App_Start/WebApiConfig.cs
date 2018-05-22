using Newtonsoft.Json.Serialization;
using System.Web.Http;

namespace SongHub
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //Code to use camelCase on javascript
            var settings = GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            settings.Formatting = Newtonsoft.Json.Formatting.Indented;
            //Finished


            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
