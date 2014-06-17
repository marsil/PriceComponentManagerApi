using System;
using System.Collections.Generic;
using System.Linq;
using PriceComponentManager.Cqrs.Domain;
using PriceComponentManager.Cqrs.Domain.Mementos;
using PriceComponentManager.Cqrs.Events;
using PriceComponentManager.Cqrs.Exceptions;
using PriceComponentManager.Cqrs.Messaging;
using PriceComponentManager.Cqrs.Storage.Memento;
using PriceComponentManager.Cqrs.Utils;

namespace PriceComponentManager.Cqrs.Storage
{
	public class DatabaseEventStorage : IEventStorage
	{
		private List<CommandEvent> _events;
		private List<BaseMemento> _mementos;

		private readonly IEventBus _eventBus;

		public DatabaseEventStorage(IEventBus eventBus)
		{
			_events = new List<CommandEvent>();
			_mementos = new List<BaseMemento>();
			_eventBus = eventBus;
		}

		public IEnumerable<CommandEvent> GetEvents(Guid aggregateId)
		{
			var events = _events.Where(p => p.AggregateId == aggregateId).Select(p => p);
			if(!events.Any())
			{
				throw new AggregateNotFoundException(string.Format("Aggregate with Id: {0} was not found", aggregateId));
			}
			return events;
		}

		public void Save(AggregateRoot aggregate)
		{
			var uncommittedChanges = aggregate.GetUncommittedChanges();
			var version = aggregate.Version;

			foreach(var @event in uncommittedChanges)
			{
				version++;
				if(version > 2)
				{
					if(version % 3 == 0)
					{
						var originator = (IOriginator)aggregate;
						var memento = originator.GetMemento();
						memento.Version = version;
						SaveMemento(memento);
					}
				}

				@event.Version = version;
				_events.Add(@event);
			}

			foreach(var @event in uncommittedChanges)
			{
				var desEvent = Converter.ChangeTo(@event, @event.GetType());
				_eventBus.Publish(desEvent);
			}
		}

		public T GetMemento<T>(Guid aggregateId) where T : BaseMemento
		{
			var memento = _mementos.Where(m => m.UniqueId == aggregateId).Select(m => m).LastOrDefault();
			if (memento != null)
			{
				return (T)memento;
			}
				
			return null;
		}

		public void SaveMemento(BaseMemento memento)
		{
			_mementos.Add(memento);
		}
	}
}