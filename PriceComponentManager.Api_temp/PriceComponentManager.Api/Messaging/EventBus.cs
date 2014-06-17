using PriceComponentManager.Api.Events;
using PriceComponentManager.Api.Utils;

namespace PriceComponentManager.Api.Messaging
{

	public class EventBus : IEventBus
	{
		private IEventHandlerFactory _eventHandlerFactory;

		public EventBus(IEventHandlerFactory eventHandlerFactory)
		{
			_eventHandlerFactory = eventHandlerFactory;
		}

		public void Publish<T>(T @event) where T : CommandEvent
		{
			var handlers = _eventHandlerFactory.GetHandlers<T>();
			foreach (var eventHandler in handlers)
			{
				eventHandler.Handle(@event);
			}
		}
	}
}