using PriceComponentManager.Cqrs.Events;
using PriceComponentManager.Database;

namespace PriceComponentManager.Cqrs.EventHandlers
{
	public class ItemCreatedEventHandler : IEventHandler<ItemCreatedEvent>
	{
		private readonly IDatabase reportDatabase;

		public ItemCreatedEventHandler(IDatabase reportDatabase)
		{
			this.reportDatabase = reportDatabase;
		}

		public void Handle(ItemCreatedEvent handle)
		{
			this.reportDatabase.Add(handle.EventDto);
		}
	}
}
