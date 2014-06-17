using PriceComponentManager.Cqrs.Events;

namespace PriceComponentManager.Cqrs.Messaging
{
	public interface IEventBus
	{
		void Publish<T>(T @event) where T : CommandEvent;
	}
}
