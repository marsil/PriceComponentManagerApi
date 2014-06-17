using System.Collections.Generic;

namespace PriceComponentManager.Api.Models
{
	public class CarRentalQueryData
	{
		public List<string> PriceComponents { get; set; }

		public List<CarRental> CarRentals { get; set; }
	}
}