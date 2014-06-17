using System.Collections.Generic;
using PriceComponentManager.Database.Dto;

namespace PriceComponentManger.WebApi.Models
{
	public class CarRentalQueryData
	{
		public List<string> PriceComponents { get; set; }

		public List<CarRentalDto> CarRentals { get; set; }
	}
}