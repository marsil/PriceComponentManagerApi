using PriceComponentManager.Cqrs.Events;
using PriceComponentManager.Cqrs.Utils;

namespace PriceComponentManager.Cqrs.Messaging
{
	public class EventBus : IEventBus
	{
		private readonly IEventHandlerFactory eventHandlerFactory;

		public EventBus(IEventHandlerFactory eventHandlerFactory)
		{
			this.eventHandlerFactory = eventHandlerFactory;
		}

		public void Publish<T>(T @event) where T : CommandEvent
		{
			var handlers = this.eventHandlerFactory.GetHandlers<T>();
			foreach (var eventHandler in handlers)
			{
				eventHandler.Handle(@event);
			}
		}
	}
}