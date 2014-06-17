using System;
using System.Web.Http;

using PriceComponentManager.Database.Dto;
using PriceComponentManager.Database.Enums;

using PriceComponentManger.WebApi.Commands;
using PriceComponentManger.WebApi.Common;
using PriceComponentManger.WebApi.Configuration;

namespace PriceComponentManger.WebApi.Controllers
{
	public class BaseController : ApiController
	{
		protected IHttpActionResult GetData<T>(Func<T> func)
		{
			try
			{
				return this.Ok(func.Invoke());
			}
			catch(Exception exception)
			{
				return this.InternalServerError(exception);
			}
		}
		 
		protected IHttpActionResult AddData<T>(EntityType entityType, T data) where T : IHaveUniqueId
		{
			try
			{
				data.UniqueId = Guid.NewGuid();
				var eventDto = EventDtoCreator.Create(EventType.Created, entityType, data);

				ServiceProvider<T>.CommandBus.Send(new EventCommand<T>(eventDto));

				return this.Ok();
			}
			catch(Exception exception)
			{
				return this.InternalServerError(exception);
			}
		}

		protected IHttpActionResult DeleteData<T>(EntityType entityType, T data) where T : IHaveUniqueId
		{
			try
			{
				var eventDto = EventDtoCreator.Create(EventType.Deleted, entityType, data);
				ServiceProvider<T>.CommandBus.Send(new EventCommand<T>(eventDto));

				return this.Ok();
			}
			catch(Exception exception)
			{
				return this.InternalServerError(exception);
			}
		}

		protected IHttpActionResult UpdateData<T>(EntityType entityType, T data) where T : IHaveUniqueId
		{
			try
			{
				var eventDto = EventDtoCreator.Create(EventType.Updated, entityType, data);
				ServiceProvider<T>.CommandBus.Send(new EventCommand<T>(eventDto));

				return this.Ok();
			}
			catch(Exception exception)
			{
				return this.InternalServerError(exception);
			}
		}
	}
}