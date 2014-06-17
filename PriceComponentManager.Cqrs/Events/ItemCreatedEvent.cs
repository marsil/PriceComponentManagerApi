using System;
using PriceComponentManager.Database.Dto;

namespace PriceComponentManager.Cqrs.Events
{
	public class ItemCreatedEvent : CommandEvent
	{
		public ItemCreatedEvent(Guid aggregateId, EventDto eventDto)
		{
			AggregateId = aggregateId;
			Version = eventDto.Version;
			this.EventDto = eventDto;
		}

		public EventDto EventDto { get; set; }
	}
}
