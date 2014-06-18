using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PriceComponentManager.Database.Dto;
using PriceComponentManager.WebApi.Test.Extension;
using PriceComponentManager.WebApi.Test.TestData;
using PriceComponentManger.WebApi.Controllers;

namespace PriceComponentManager.WebApi.Test.Controllers
{
	[TestClass]
	public class PriceComponentControllerTest
	{
		[TestMethod]
		public void AddPriceComponent_ShouldReturnPriceComponent()
		{
			var controller = new PriceComponentController();
			var priceComponent = PriceComponentTestData.GetPriceComponent();
			var resultOfAdd = controller.Add(priceComponent) as OkResult;

			var result = controller.Get() as OkNegotiatedContentResult<List<PriceComponentDto>>;

			Assert.IsNotNull(resultOfAdd);
			Assert.IsNotNull(result);
			Assert.IsTrue(priceComponent.Compare(result.Content.Last()).AreEqual);
		}
	}
}
