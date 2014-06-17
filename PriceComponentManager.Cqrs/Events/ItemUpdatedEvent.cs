using System;
using PriceComponentManager.Database.Dto;

namespace PriceComponentManager.Cqrs.Events
{
	public class ItemUpdatedEvent<T> : CommandEvent
	{
		public EventDto<T> EventDto { get; private set; }

		public ItemUpdatedEvent(Guid aggregateId, EventDto<T> eventDto)
		{
			AggregateId = aggregateId;
			Version = eventDto.Version;
			this.EventDto = eventDto;
		}
	}
}
