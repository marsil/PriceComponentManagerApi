﻿using System;
using System.Text;
using System.Web.Http;
using PriceComponentManager.Database.Dto;
using PriceComponentManger.WebApi.Common;
using PriceComponentManger.WebApi.Configuration;

namespace PriceComponentManger.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

		protected void Application_BeginRequest(object sender, EventArgs e)
		{
			if (Request.Path == "/") return;

			var bytes = Request.BinaryRead(Request.TotalBytes);
			var data = Encoding.UTF8.GetString(bytes);

			var queryDto = new QueryDto
				        {
							UniqueId = Guid.NewGuid(),
							UserId = "2000",
							Url = RemoveApiPart(Request.Path),
							Parameters = Request.QueryString.ToString(),
							Data = data,
							StartTime = DateTime.UtcNow, 
				        };

			ServiceProvider.Database.AddQuery(queryDto);
		}

		protected void Application_EndRequest(object sender, EventArgs e)
		{
			if(Request.Path == "/") return;

			//ServiceProvider<GenericDto>.Database.AddQuery(queryDto);
		}

		protected void Application_Error(object sender, EventArgs e)
		{
			var exception = Server.GetLastError().GetBaseException();
			WebExceptionHandler.LogToDatabase(exception, Request);
		}

	    private static string RemoveApiPart(string url)
	    {
		    return url.Replace("/api/", string.Empty);
	    }
    }
}
