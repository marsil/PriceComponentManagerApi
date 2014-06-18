using System.Linq;
using PriceComponentManager.Database.Dto;
using PriceComponentManager.Database.Enums;
using PriceComponentManger.WebApi.Configuration;
using PriceComponentManger.WebApi.Models;
using PriceComponentManger.WebApi.Queries.Parameters;

namespace PriceComponentManger.WebApi.Queries
{
	public class CarRentalQuery
	{
		public static CarRentalQueryData GetCarRentalQueryData(CarRentalQueryPararmeters pararmeters)
		{
			var carRentals = ServiceProvider<CarRentalDto>.EventRepository.GetItems(EntityType.CarRental);
			var priceComponents = ServiceProvider<PriceComponentDto>.EventRepository.GetItems(EntityType.PriceComponent);

			return new CarRentalQueryData
			{
				PriceComponents = priceComponents.Select(p => p.PriceComponentCode).ToList(),
				CarRentals = carRentals
			};
		}
	}
}