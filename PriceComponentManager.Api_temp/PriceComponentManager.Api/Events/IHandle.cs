namespace PriceComponentManager.Api.Events
{
	public interface IHandle<in TEvent> where TEvent : CommandEvent
	{
		void Handle(TEvent @event);
	}
}
