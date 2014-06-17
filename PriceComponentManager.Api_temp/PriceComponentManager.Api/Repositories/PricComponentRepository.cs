using System.Collections.Generic;
using System.Linq;
using PriceComponentManager.Api.Models;

namespace PriceComponentManager.Api.Repositories
{
	public static class PricComponentRepository
	{
		public static List<string> GetPriceComponents()
		{
			var priceComponents = GenericRepository.GetEntities<PriceComponent>();

			return priceComponents.Select(p => p.PriceComponentCode).ToList();

			//var priceComponents = new List<PriceComponent>() 
			//{ 
			//	new PriceComponent { PriceComponentCode = "CIT" }, 
			//	new PriceComponent { PriceComponentCode = "TIT" }, 
			//	new PriceComponent { PriceComponentCode = "CRF" }, 
			//	new PriceComponent { PriceComponentCode = "CRT" }
			//};

			//return priceComponents.Select(p => p.PriceComponentCode).ToList();
		}
	}
}