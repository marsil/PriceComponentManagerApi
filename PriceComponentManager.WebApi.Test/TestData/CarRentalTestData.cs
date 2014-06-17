using System;
using PriceComponentManager.Database.Dto;

namespace PriceComponentManager.WebApi.Test.TestData
{
	public class CarRentalTestData
	{
		public static CarRentalDto GetCarRental()
		{
			return new CarRentalDto
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
				       };
		}
	}
}
