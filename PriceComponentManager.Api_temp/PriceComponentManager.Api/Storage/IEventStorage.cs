using System;
using System.Collections.Generic;

using PriceComponentManager.Api.Domain;
using PriceComponentManager.Api.Domain.Mementos;
using PriceComponentManager.Api.Events;

namespace PriceComponentManager.Api.Storage
{
	public interface IEventStorage
	{
		IEnumerable<CommandEvent> GetEvents(Guid aggregateId);

		void Save(AggregateRoot aggregate);
		
		T GetMemento<T>(Guid aggregateId) where T : BaseMemento;
		
		void SaveMemento(BaseMemento memento);
	}
}
