using System.Collections.Generic;
using System.Threading.Tasks;
using PriceComponentManager.Database.Dto;
using PriceComponentManager.Database.Enums;

namespace PriceComponentManager.Database
{
	public interface IDatabase
	{
		Task<int> AddEvent<T>(EventDto<T> eventDto);

		Task<List<EventDto<T>>> GetEvents<T>(EntityType entityType);

		Task<List<EventDto<T>>> GetAllEvents<T>();

		Task<int> AddQuery<TParameter, TData>(QueryDto<TParameter, TData> queryDto);
	}
}
