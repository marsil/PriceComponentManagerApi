using PriceComponentManager.Database.Dto;

namespace PriceComponentManager.WebApi.Test.TestData
{
	public class PriceComponentTestData
	{
		public static PriceComponentDto GetPriceComponent()
		{
			return new PriceComponentDto { PriceComponentCode = "CIT" };
		}
	}
}
