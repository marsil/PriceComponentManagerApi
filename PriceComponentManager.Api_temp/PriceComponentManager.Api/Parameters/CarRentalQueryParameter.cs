using System;

namespace PriceComponentManager.Api.Parameters
{
	public class CarRentalQueryParameter
	{
		//public IEnumerable<string> PriceComponentCodes { get; set; }

		public string MarketUnitCode { get; set; }

		public DateTime FromDate { get; set; }

		public DateTime ToDate { get; set; }

		public string UserId { get; set; }
	}
}