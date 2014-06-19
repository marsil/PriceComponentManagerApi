using System.Linq;
using PriceComponentManager.Database.Dto;
using PriceComponentManger.WebApi.Configuration;
using PriceComponentManger.WebApi.Models;
using PriceComponentManger.WebApi.Queries.Parameters;

namespace PriceComponentManger.WebApi.Queries
{
	public class CarRentalQuery
	{
		public static CarRentalQueryData GetCarRentalQueryData(CarRentalQueryPararmeters pararmeters)
		{
			var carRentals = ServiceProvider.GetDataRepository<CarRentalDto>().GetItems();
			var priceComponents = ServiceProvider.GetDataRepository<PriceComponentDto>().GetItems();

			return new CarRentalQueryData
			{
				PriceComponents = priceComponents.Select(p => p.PriceComponentCode).ToList(),
				CarRentals = carRentals
			};
		}
	}
}