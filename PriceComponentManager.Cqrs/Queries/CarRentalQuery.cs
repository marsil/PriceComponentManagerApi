using System.Linq;
using System.Threading.Tasks;

using PriceComponentManager.Cqrs.Configuration;
using PriceComponentManager.Cqrs.Models;
using PriceComponentManager.Database.Dto;
using PriceComponentManager.Database.Enums;

namespace PriceComponentManager.Cqrs.Queries
{
	public class CarRentalQuery
	{
		public async static Task<CarRentalQueryData> GetCarRentalQueryData()
		{
			var carRentals = await ServiceProvider.Database.GetItems<CarRentalDto>(EntityType.CarRental);
			var priceComponents = await ServiceProvider.Database.GetItems<PriceComponentDto>(EntityType.PriceComponent);
			
			return new CarRentalQueryData
			{
				PriceComponents = priceComponents,
				CarRentals = carRentals
			};
		}
	}
}