using System.Collections.Generic;
using PriceComponentManager.Database.Dto;
using PriceComponentManager.Database.Enums;

namespace PriceComponentManager.Database
{
	public interface IDatabase
	{
		void AddEvent<T>(EventDto<T> eventDto);

		List<EventDto<T>> GetEvents<T>(EntityType entityType);

		List<EventDto<T>> GetEvents<T>();

		void AddQuery(QueryDto queryDto);

		List<QueryDto> GetQueries(); 

		void AddException(ExceptionDto exceptionDto);

		List<ExceptionDto> GetExceptions();
	}
}
