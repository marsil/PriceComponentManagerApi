using System;
using Newtonsoft.Json;
using PriceComponentManager.Database.Dto;
using PriceComponentManger.WebApi.Configuration;

namespace PriceComponentManger.WebApi.Common
{
	public class CommonExceptionHandler
	{
		public static void LogToDatabase(Exception exception, object parameters)
		{
			var url = string.Empty;

			var exceptionDto = new ExceptionDto
			{
				UniqueId = Guid.NewGuid(),
				UserId = "2000",
				Url = url,
				Parameters = JsonConvert.SerializeObject(parameters),
				Messsage = exception.Message,
				Source = exception.Source,
				StackTrace = exception.StackTrace,
				Time = DateTime.UtcNow
			};

			ServiceProvider.Database.AddException(exceptionDto);
		}
	}
}