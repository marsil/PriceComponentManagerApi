using System.Collections.Generic;

using PriceComponentManager.Database.Dto;

namespace PriceComponentManager.Cqrs.Repositories
{
	public static class CarRentalRepository
	{
		public static List<CarRentalDto> GetCarRentals()
		{
			return new List<CarRentalDto>();
			//return GenericRepository.GetEntities<CarRentalDto>();

			//return new List<CarRentalModel>
			//					 {
			//						 new CarRentalModel()
			//							 {
			//								 MarketUnitCode = "VS",
			//								 PriceComponentCode = "CRT",
			//								 PriceComponentInstanceId = 1,
			//								 PriceComponentAmountId = 1,
			//								 Destination = "IBZ",
			//								 Category = "A",
			//								 Duration = "2",
			//								 Amount = 900,
			//								 DateFrom = new DateTime(2014, 1, 10),
			//								 DateTo = new DateTime(2014, 2, 10),
			//								 ContractCost = 500,
			//								 CurrencyCode = "EUR",
			//								 Cost = "500",
			//								 NewCarRental = false
			//							 }
			//					 };
		}
	}
}