using System.Collections.Generic;

using PriceComponentManager.Api.EventHandlers;
using PriceComponentManager.Api.Events;

namespace PriceComponentManager.Api.Utils
{
	public interface IEventHandlerFactory
	{
		IEnumerable<IEventHandler<T>> GetHandlers<T>() where T : CommandEvent;
	}
}
