using System.Collections.Generic;
using PriceComponentManager.Database.Dto;

namespace PriceComponentManger.WebApi.Storage
{
	public interface IDataRepository<T> where T : IHaveUniqueId
	{
		List<T> GetItems();

		void Apply(EventDto<T> eventDto);
	}
}
