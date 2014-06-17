using PriceComponentManager.Database.Dto;

namespace PriceComponentManger.WebApi.Storage
{
	public interface IQueryRepository
	{
		void Add(QueryDto queryDto);
	}
}