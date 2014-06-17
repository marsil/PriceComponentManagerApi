using System;
using PriceComponentManager.Database.Dto;

namespace PriceComponentManager.Cqrs.Domain.Mementos
{
	public class EventMemento<T> : BaseMemento
	{
		public EventDto EventDto { get; private set; }

		public EventMemento(Guid uniqueId, int version, EventDto eventDto)
		{
			this.UniqueId = uniqueId;
			Version = version;
			EventDto = eventDto;
		}
	}
}
