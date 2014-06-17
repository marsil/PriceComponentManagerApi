using System;
using Newtonsoft.Json;
using PriceComponentManager.Database.Dto;
using PriceComponentManager.Database.Enums;

namespace PriceComponentManager.Api.Common
{
	public static class EventDtoCreator
	{
		public static EventDto Create(EventType envenType, EntityType entityType, IHaveUniqueId data)
		{
			return new EventDto()
				{
					Data = JsonConvert.SerializeObject(data),
					StartTime = DateTime.UtcNow,
					Type = envenType,
					EntityType = entityType,
					UniqueId = data.UniqueId,
					Version = -1
				};
			
		}
	}
}