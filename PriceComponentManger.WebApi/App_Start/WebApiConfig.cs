using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json.Serialization;
using PriceComponentManger.WebApi.Validation;

namespace PriceComponentManger.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));

            // Web API routes
            config.MapHttpAttributeRoutes();

	        config.Routes.MapHttpRoute(
		        name: "API Default",
		        routeTemplate: "api/{controller}/{action}/{id}",
		        defaults: new { id = RouteParameter.Optional });

			var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
			jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

	        config.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
	        config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

			config.Filters.Add(new ValidateModelAttribute());
        }
    }
}
