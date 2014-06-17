using System.Collections.Generic;

using PriceComponentManager.Cqrs.Domain;

namespace PriceComponentManager.Cqrs.Repositories
{
	public class GenericRepository
	{
		public static List<T> GetEntities<T>() where T : AggragateRootBase<T>, new()
		{
			var entities = new List<T>();

			//var events = ServiceLocator.ReportDatabase.GetItems(typeof(T).Name);

			//foreach (var @event in events)
			//{
			//	if (@event.Type == EventType.Created)
			//	{
			//		var entity = ModelFactory.GetInstance<T>(@event.Data);

			//		entities.Add(entity);
			//	}

			//	if (@event.Type == EventType.Updated)
			//	{
			//		var entity = entities.FirstOrDefault(c => c.Id == @event.Id);

			//		if (entity == null)
			//		{
			//			continue;
			//		}

			//		var index = entities.IndexOf(entity);
			//		entities.Insert(index, ModelFactory.GetInstance<T>(@event.Data));
			//	}

			//	if (@event.Type == EventType.Deleted)
			//	{
			//		var carRental = ModelFactory.GetInstance<T>(@event.Data);

			//		if(carRental == null)
			//		{
			//			continue;
			//		}

			//		entities.Remove(carRental);
			//	}
			//}

			return entities;
		}
	}
}
