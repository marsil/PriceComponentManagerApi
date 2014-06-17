using System;
using System.Collections.Generic;
using PriceComponentManager.Cqrs.Domain;
using PriceComponentManager.Cqrs.Domain.Mementos;
using PriceComponentManager.Cqrs.Events;

namespace PriceComponentManager.Cqrs.Storage
{
	public interface IEventStorage
	{
		IEnumerable<CommandEvent> GetEvents(Guid aggregateId);

		void Save(AggregateRoot aggregate);
		
		T GetMemento<T>(Guid aggregateId) where T : BaseMemento;
		
		void SaveMemento(BaseMemento memento);
	}
}
