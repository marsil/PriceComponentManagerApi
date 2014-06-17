using System.Collections.Generic;

using PriceComponentManager.Cqrs.EventHandlers;
using PriceComponentManager.Cqrs.Events;

namespace PriceComponentManager.Cqrs.Utils
{
	public interface IEventHandlerFactory
	{
		IEnumerable<IEventHandler<T>> GetHandlers<T>() where T : CommandEvent;
	}
}
