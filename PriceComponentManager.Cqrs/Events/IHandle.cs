namespace PriceComponentManager.Cqrs.Events
{
	public interface IHandle<in TEvent> where TEvent : CommandEvent
	{
		void Handle(TEvent @event);
	}
}
