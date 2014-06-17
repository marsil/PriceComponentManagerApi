using System;
using PriceComponentManager.Cqrs.Domain.Mementos;
using PriceComponentManager.Cqrs.Events;
using PriceComponentManager.Cqrs.Storage.Memento;
using PriceComponentManager.Database.Dto;

namespace PriceComponentManager.Cqrs.Domain
{
	public class EventAggregate : AggregateRoot,
		IHandle<ItemCreatedEvent>,
			IHandle<ItemDeletedEvent>,
			IHandle<ItemUpdatedEvent>,
			IOriginator
	{
		public EventAggregate()
		{
		}

		public	EventAggregate(Guid uniqueId, int version, EventDto eventDto)
		{
			this.UniqueId = uniqueId;
			this.Version = version;
			this.EventDto = eventDto;
			this.ApplyChange(new ItemCreatedEvent(uniqueId, eventDto));
		}

		public EventDto EventDto { get; private set; }

		public void Update(EventDto eventDto)
		{
			ApplyChange(new ItemUpdatedEvent(this.UniqueId, eventDto));
		}

		public void Delete()
		{
			ApplyChange(new ItemDeletedEvent(this.UniqueId));
		}

		public void Handle(ItemCreatedEvent @event)
		{
			this.EventDto = @event.EventDto;
			Version = @event.Version;
		}

		public void Handle(ItemDeletedEvent e)
		{
		}

		public void Handle(ItemUpdatedEvent @event)
		{
			this.EventDto = @event.EventDto;
		}

		public BaseMemento GetMemento()
		{
			return new EventMemento(UniqueId, Version, EventDto);
		}

		public void SetMemento(BaseMemento memento)
		{
			UniqueId = memento.UniqueId;
			Version = memento.Version;
			EventDto = ((EventMemento)memento).EventDto;
		}
	}
}
