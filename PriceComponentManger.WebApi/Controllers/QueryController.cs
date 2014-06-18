using System;
using System.Web.Http;
using PriceComponentManager.Database.Dto;
using PriceComponentManger.WebApi.Configuration;

namespace PriceComponentManger.WebApi.Controllers
{
	public class QueryController : BaseController
	{
		public IHttpActionResult Get(int? top = null)
		{
			try
			{
				return this.Ok(ServiceProvider<QueryDto>.Database.GetQueries(top));
			}
			catch(Exception exception)
			{
				return this.InternalServerError(exception);
			}
		}
	}
}