using System;
using System.Collections.Generic;
using PriceComponentManager.Database.Dto;
using PriceComponentManager.Database.Enums;

namespace PriceComponentManger.WebApi.Storage
{
	public interface IEventRepository<T>
	{
		void Add(EventDto<T> eventDto);

		EventDto<T> GetById(Guid uniqueId);

		List<EventDto<T>> GetEvents(EntityType entityType);

		List<T> GetItems(EntityType entityType);

		void LoadAllEvents();
	}
}
