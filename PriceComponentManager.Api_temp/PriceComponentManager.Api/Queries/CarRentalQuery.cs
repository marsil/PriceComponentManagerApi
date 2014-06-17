using PriceComponentManager.Api.Models;
using PriceComponentManager.Api.Repositories;

namespace PriceComponentManager.Api.Queries
{
	public class CarRentalQuery
	{
		public static CarRentalQueryData GetCarRentalQueryData()
		{
			return new CarRentalQueryData
			{
				PriceComponents = PricComponentRepository.GetPriceComponents(),
				CarRentals = CarRentalRepository.GetCarRentals()
			};
		}
	}
}