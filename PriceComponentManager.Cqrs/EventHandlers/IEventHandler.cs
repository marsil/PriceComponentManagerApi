using PriceComponentManager.Cqrs.Events;

namespace PriceComponentManager.Cqrs.EventHandlers
{
	public interface IEventHandler<in TEvent> where TEvent : CommandEvent
	{
		void Handle(TEvent handle);
	}
}
