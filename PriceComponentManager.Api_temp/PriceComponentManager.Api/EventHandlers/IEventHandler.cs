using PriceComponentManager.Api.Events;

namespace PriceComponentManager.Api.EventHandlers
{
	public interface IEventHandler<in TEvent> where TEvent : CommandEvent
	{
		void Handle(TEvent handle);
	}
}
