using System;

namespace PriceComponentManger.WebApi.Queries.Parameters
{
	public class CarRentalQueryPararmeters
	{
		public string PriceComponentCodes { get; set; }

		public string MarketUnitCode { get; set; }

		public DateTime? FromDate { get; set; }

		public DateTime? ToDate { get; set; }

		public string UserId { get; set; }
	}
}