using System;
using System.Web.Http;
using PriceComponentManger.WebApi.Configuration;

namespace PriceComponentManger.WebApi.Controllers
{
	public class QueryController : BaseController
	{
		public IHttpActionResult Get(int? top = null)
		{
			try
			{
				return this.Ok(ServiceProvider.Database.GetQueries(top));
			}
			catch(Exception exception)
			{
				return this.InternalServerError(exception);
			}
		}
	}
}