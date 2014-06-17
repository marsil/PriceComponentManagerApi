using System.Collections.Generic;
using System.Linq;
using PriceComponentManager.Api.Commands;
using PriceComponentManager.Api.Configuration;
using PriceComponentManager.Api.Domain;
using PriceComponentManager.Api.Models;

namespace PriceComponentManager.Api.Repositories
{
	public class GenericRepository
	{
		public static List<T> GetEntities<T>() where T : AggragateRootImpl, new()
		{
			var entities = new List<T>();

			var events = ServiceLocator.ReportDatabase.GetItems(typeof(T).Name);

			foreach (var @event in events)
			{
				if (@event.Type == CommandType.Created)
				{
					var entity = ModelFactory.GetInstance<T>(@event.Data);

					entities.Add(entity);
				}

				if (@event.Type == CommandType.Updated)
				{
					var entity = entities.FirstOrDefault(c => c.Id == @event.Id);

					if (entity == null)
					{
						continue;
					}

					var index = entities.IndexOf(entity);
					entities.Insert(index, ModelFactory.GetInstance<T>(@event.Data));
				}

				if (@event.Type == CommandType.Deleted)
				{
					var carRental = ModelFactory.GetInstance<T>(@event.Data);

					if(carRental == null)
					{
						continue;
					}

					entities.Remove(carRental);
				}
			}

			return entities;
		}
	}
}
