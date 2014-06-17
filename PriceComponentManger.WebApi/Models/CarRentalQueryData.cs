using System.Collections.Generic;
using PriceComponentManager.Database.Dto;

namespace PriceComponentManger.WebApi.Models
{
	public class CarRentalQueryData
	{
		public List<PriceComponentDto> PriceComponents { get; set; }

		public List<CarRentalDto> CarRentals { get; set; }
	}
}