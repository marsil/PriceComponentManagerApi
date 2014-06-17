﻿using System;

namespace PriceComponentManager.Api.Dto
{
	public class CarRentalDto
	{
		public string MarketUnitCode { get; set; }

		public string PriceComponentCode { get; set; }

		public int PriceComponentInstanceId { get; set; }

		public int PriceComponentAmountId { get; set; }

		public string Destination { get; set; }

		public string Category { get; set; }

		public string Duration { get; set; }

		public int Amount { get; set; }

		public DateTime DateFrom { get; set; }

		public DateTime DateTo { get; set; }

		public int ContractCost { get; set; }

		public string CurrencyCode { get; set; }

		public string Cost { get; set; }

		public bool NewCarRental { get; set; }
	}
}