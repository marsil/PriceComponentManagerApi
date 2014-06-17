using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using Newtonsoft.Json.Serialization;

namespace PriceComponentManger.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

	        config.Routes.MapHttpRoute(
		        name: "API Default",
		        routeTemplate: "api/{controller}/{action}/{id}",
		        defaults: new { id = RouteParameter.Optional });

			var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
			jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

	        //config.Routes.MapHttpRoute(
	        //	name: "DefaultApi",
	        //	routeTemplate: "api/{controller}/{id}",
	        //	defaults: new { id = RouteParameter.Optional });
        }
    }
}
