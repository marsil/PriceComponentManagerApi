using System.Collections.Generic;
using PriceComponentManager.Database.Dto;
using PriceComponentManager.Database.Enums;

namespace PriceComponentManager.Database
{
	public interface IDatabase
	{
		void AddEvent<T>(EventDto<T> eventDto);

		List<EventDto<T>> GetEvents<T>(EntityType entityType);

		List<EventDto<T>> GetAllEvents<T>();

		void AddQuery(QueryDto queryDto);

		void AddException(ExceptionDto exceptionDto);
	}
}
