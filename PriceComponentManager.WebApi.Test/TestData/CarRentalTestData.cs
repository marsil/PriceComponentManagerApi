using System;
using PriceComponentManager.Database.Dto;

namespace PriceComponentManager.WebApi.Test.TestData
{
	public class CarRentalTestData
	{
		public static CarRentalDto GetCarRental()
		{
			var date = DateTime.Today.AddDays(-(new Random()).Next(1, 1000));
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
					       DateFrom = date,
					       DateTo = date.AddDays(7),
					       ContractCost = 500,
					       CurrencyCode = "EUR",
					       Cost = "500",
					       NewRow = false,
					       DeleteRow = false
				       };
		}
	}
}
