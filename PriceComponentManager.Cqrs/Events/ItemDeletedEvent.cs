using System;

namespace PriceComponentManager.Cqrs.Events
{
	public class ItemDeletedEvent : CommandEvent
	{
		public ItemDeletedEvent(Guid aggregateId)
		{
			AggregateId = aggregateId;
		}
	}
}
