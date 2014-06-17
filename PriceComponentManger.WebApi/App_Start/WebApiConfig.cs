﻿using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
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

	        config.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
	        config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

	        //config.Routes.MapHttpRoute(
	        //	name: "DefaultApi",
	        //	routeTemplate: "api/{controller}/{id}",
	        //	defaults: new { id = RouteParameter.Optional });
        }
    }
}
