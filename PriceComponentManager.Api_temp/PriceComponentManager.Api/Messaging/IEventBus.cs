using PriceComponentManager.Api.Events;

namespace PriceComponentManager.Api.Messaging
{
	public interface IEventBus
	{
		void Publish<T>(T @event) where T : CommandEvent;
	}
}
