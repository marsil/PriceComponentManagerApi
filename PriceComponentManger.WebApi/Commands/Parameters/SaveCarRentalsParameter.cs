using System.Collections.Generic;
using PriceComponentManager.Database.Dto;

namespace PriceComponentManger.WebApi.Commands.Parameters
{
	public class SaveCarRentalsParameter
	{
		public List<CarRentalDto> CarRentals { get; set; }

		public string PriceComponentCode { get; set; }

		public string UserId { get; set; }
	}
}