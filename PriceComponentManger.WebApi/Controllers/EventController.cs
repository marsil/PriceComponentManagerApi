using System;
using System.Web.Http;

using PriceComponentManager.Database.Dto;
using PriceComponentManager.Database.Enums;
using PriceComponentManger.WebApi.Configuration;

namespace PriceComponentManger.WebApi.Controllers
{
	public class EventController<T> : BaseController
		where T : IHaveUniqueId
	{
		public IHttpActionResult Get(EntityType entityType)
		{
			try
			{
				return this.Ok(ServiceProvider<T>.EventRepository.GetEvents(entityType));
			}
			catch(Exception exception)
			{
				return this.InternalServerError(exception);
			}
		}
	}
}