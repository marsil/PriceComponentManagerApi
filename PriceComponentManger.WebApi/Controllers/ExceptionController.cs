using System;
using System.Web.Http;
using PriceComponentManager.Database.Dto;
using PriceComponentManger.WebApi.Common;
using PriceComponentManger.WebApi.Configuration;

namespace PriceComponentManger.WebApi.Controllers
{
	public class ExceptionController : BaseController
	{
		public IHttpActionResult Get(int? top = null)
		{
			try
			{
				return this.Ok(ServiceProvider<ExceptionDto>.Database.GetExceptions(top));
			}
			catch(Exception exception)
			{
				return this.InternalServerError(exception);
			}
		}

		public IHttpActionResult TestOfException()
		{
			try
			{
				throw new Exception("TestOfException");
			}
			catch(Exception exception)
			{
				WebExceptionHandler.LogToDatabase(exception, this.Request, null);
				return this.InternalServerError(exception);
			}
		}
	}
}