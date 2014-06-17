using System;
using System.Web.Http;
using PriceComponentManager.Api.Common;
using PriceComponentManager.Cqrs.Commands;
using PriceComponentManager.Cqrs.Configuration;
using PriceComponentManager.Database.Dto;
using PriceComponentManager.Database.Enums;

namespace PriceComponentManager.Api.Controllers
{
	public class BaseController : ApiController
	{
		public IHttpActionResult GetData<T>(Func<T> func)
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

		public IHttpActionResult AddData(EntityType entityType, IHaveUniqueId data)
		{
			try
			{
				var eventDto = EventDtoCreator.Create(EventType.Created, entityType, data);

				ServiceProvider.CommandBus.Send(new CreateItemCommand(eventDto.UniqueId, eventDto.Version, eventDto));

				return this.Ok();
			}
			catch(Exception exception)
			{
				return this.InternalServerError(exception);
			}
		}

		public IHttpActionResult DeleteData(IHaveUniqueId data)
		{
			try
			{
				ServiceProvider.CommandBus.Send(new DeleteItemCommand(data.UniqueId, 0));

				return this.Ok();
			}
			catch(Exception exception)
			{
				return this.InternalServerError(exception);
			}
		}
	}
}