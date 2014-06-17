﻿using System;
using System.Collections.Generic;
using System.Linq;
using PriceComponentManager.Cqrs.Domain;
using PriceComponentManager.Cqrs.Domain.Mementos;
using PriceComponentManager.Cqrs.Events;
using PriceComponentManager.Cqrs.Exceptions;
using PriceComponentManager.Cqrs.Storage.Memento;

namespace PriceComponentManager.Cqrs.Storage
{
	public class Repository<T> : IRepository<T> where T : AggregateRoot, new()
	{
		private readonly IEventStorage _storage;

		private static object _lockStorage = new object();

		public Repository(IEventStorage storage)
		{
			_storage = storage;
		}

		public void Save(AggregateRoot aggregate, int expectedVersion)
		{
			if(aggregate.GetUncommittedChanges().Any())
			{
				lock(_lockStorage)
				{
					var item = new T();

					if(expectedVersion != -1)
					{
						item = GetById(aggregate.UniqueId);
						if(item.Version != expectedVersion)
						{
							throw new ConcurrencyException(string.Format("Aggregate {0} has been previously modified",
																		 item.UniqueId));
						}
					}

					_storage.Save(aggregate);
				}
			}
		}

		public T GetById(Guid id)
		{
			IEnumerable<CommandEvent> events;
			var memento = _storage.GetMemento<BaseMemento>(id);
			if(memento != null)
			{
				events = _storage.GetEvents(id).Where(e => e.Version >= memento.Version);
			}
			else
			{
				events = _storage.GetEvents(id);
			}
			var obj = new T();
			if(memento != null)
				((IOriginator)obj).SetMemento(memento);

			obj.LoadsFromHistory(events);
			return obj;
		}
	}
}