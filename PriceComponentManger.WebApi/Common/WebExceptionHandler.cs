using System;
using System.Net.Http;
using System.Web;
using Newtonsoft.Json;
using PriceComponentManager.Database.Dto;
using PriceComponentManger.WebApi.Configuration;

namespace PriceComponentManger.WebApi.Common
{
	public class WebExceptionHandler
	{
		public static void LogToDatabase(Exception exception, HttpRequestMessage request, object parameters)
		{
			var url = request != null ? request.RequestUri.AbsolutePath : string.Empty;
			var parametersText = parameters != null ? JsonConvert.SerializeObject(parameters) : string.Empty;
			LogToDatabase(exception, url, parametersText);
		}

		public static void LogToDatabase(Exception exception, HttpRequest request)
		{
			LogToDatabase(exception, request.Path, request.QueryString.ToString());
		}

		private static void LogToDatabase(Exception exception, string url, string parameters)
		{
			var exceptionDto = new ExceptionDto
			{
				UniqueId = Guid.NewGuid(),
				UserId = "2000",
				Url = url.Replace("/api/", string.Empty),
				Parameters = parameters,
				Messsage = exception.Message,
				Source = exception.Source,
				StackTrace = exception.StackTrace,
				Time = DateTime.UtcNow
			};

			ServiceProvider<ExceptionDto>.Database.AddException(exceptionDto);
		}
	}
}