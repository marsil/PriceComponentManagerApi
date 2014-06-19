using System;
using System.Collections.Generic;
using System.Linq;
using PriceComponentManager.Database.Dto;
using PriceComponentManager.Database.Enums;
using PriceComponentManger.WebApi.Configuration;

namespace PriceComponentManger.WebApi.Storage
{
	public class EventRepository<T> : IEventRepository<T>
		where T : IHaveUniqueId
	{
		public EventRepository()
		{
			this.LoadAllEvents();
		}

		private static List<EventDto<T>> eventDtos = new List<EventDto<T>>();

		public void Add(EventDto<T> item)
		{
			eventDtos.Add(item);
		}

		public EventDto<T> GetById(Guid uniqueId)
		{
			return eventDtos.FirstOrDefault(e => e.UniqueId == uniqueId);
		}

		public List<EventDto<T>> GetEvents(EntityType entityType)
		{
			return eventDtos.Where(e => e.EntityType == entityType).ToList();
		}

		public List<T> GetItems(EntityType entityType)
		{
			return eventDtos.Where(e => e.EntityType == entityType).Select(e => e.Data).ToList();
		}

		public void LoadAllEvents()
		{
			eventDtos = ServiceProvider.Database.GetEvents<T>();
			foreach (var eventDto in eventDtos)
			{
				ServiceProvider.GetDataRepository<T>().Apply(eventDto);
			}
		}
	}
}