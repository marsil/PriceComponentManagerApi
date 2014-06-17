using System;
using PriceComponentManager.Database.Dto;
using PriceComponentManager.Database.Enums;

namespace PriceComponentManger.WebApi.Common
{
	public static class EventDtoCreator
	{
		public static EventDto<T> Create<T>(EventType envenType, EntityType entityType, T data)
		{
			return new EventDto<T>
				{
					UniqueId = Guid.NewGuid(),
					UserId = "2000",
					Data = data,
					StartTime = DateTime.UtcNow,
					Type = envenType,
					EntityType = entityType,
					Version = -1
				};
			
		}
	}
}