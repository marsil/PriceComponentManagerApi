using System.Collections.Generic;
using System.Linq;

using PriceComponentManager.Database.Dto;

namespace PriceComponentManager.Cqrs.Repositories
{
	public static class PricComponentRepository
	{
		public static List<string> GetPriceComponents()
		{

			//var priceComponents = GenericRepository.GetEntities<PriceComponentDto>();

			//return priceComponents.Select(p => p.PriceComponentCode).ToList();




			var priceComponents = new List<PriceComponentDto>() 
			{ 
				new PriceComponentDto { PriceComponentCode = "CIT" }, 
				new PriceComponentDto { PriceComponentCode = "TIT" }, 
				new PriceComponentDto { PriceComponentCode = "CRF" }, 
				new PriceComponentDto { PriceComponentCode = "CRT" }
			};

			return priceComponents.Select(p => p.PriceComponentCode).ToList();
		}
	}
}