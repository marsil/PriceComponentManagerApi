using System.Collections.Generic;
using System.Threading.Tasks;

using PriceComponentManager.Cqrs.Configuration;
using PriceComponentManager.Database.Dto;
using PriceComponentManager.Database.Enums;

namespace PriceComponentManager.Cqrs.Queries
{
	public class PriceComponentQuery
	{
		public static async Task<List<PriceComponentDto>> GetPriceComponents()
		{
			return await ServiceProvider.Database.GetItems<PriceComponentDto>(EntityType.PriceComponent);
		}
	}
}
