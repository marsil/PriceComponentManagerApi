using System;
using System.Collections.Generic;
using System.Linq;
using PriceComponentManager.Cqrs.Models;
using PriceComponentManager.Database.Dto;

namespace PriceComponentManager.Api.Test.TestData
{
	public class CarRentalTestData
	{
		public static CarRentalQueryData GetCarRentalQueryData()
		{
			return new CarRentalQueryData
			{
				PriceComponents = GetPriceComponents(),
				CarRentals = GetCarRentals()
			};
		}

		private static List<CarRentalDto> GetCarRentals()
		{
			return new List<CarRentalDto>
				       {
					       new CarRentalDto()
						       {
							       MarketUnitCode = "VS",
							       PriceComponentCode = "CRT",
							       PriceComponentInstanceId = 1,
							       PriceComponentAmountId = 1,
							       Destination = "IBZ",
							       Category = "A",
							       Duration = "2",
							       Amount = 900,
							       DateFrom = new DateTime(2014, 1, 10),
							       DateTo = new DateTime(2014, 2, 10),
							       ContractCost = 500,
							       CurrencyCode = "EUR",
							       Cost = "500",
							       NewRow = false,
								   DeleteRow = false
						       }
				       };
		}

		private static List<PriceComponentDto> GetPriceComponents()
		{
			return new List<PriceComponentDto>() 
			{ 
				new PriceComponentDto { PriceComponentCode = "CIT" }, 
				new PriceComponentDto { PriceComponentCode = "TIT" }, 
				new PriceComponentDto { PriceComponentCode = "CRF" }, 
				new PriceComponentDto { PriceComponentCode = "CRT" }
			};
		}
	}
}
