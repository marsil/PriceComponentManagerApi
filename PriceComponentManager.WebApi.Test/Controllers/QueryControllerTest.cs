using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PriceComponentManager.Database.Dto;
using PriceComponentManager.WebApi.Test.Infrastucture;
using PriceComponentManager.WebApi.Test.TestData;
using PriceComponentManger.WebApi.Controllers;

namespace PriceComponentManager.WebApi.Test.Controllers
{
	[TestClass]
	public class QueryControllerTest
	{
		[TestMethod]
		public void AddCarRental_ShouldGenerateQueryLog()
		{
			var addResult = WebRequestExecutor.PostData("carRental/Add", CarRentalTestData.GetCarRental());
			var result = new QueryController().Get() as OkNegotiatedContentResult<List<QueryDto>>;
			
			Assert.IsNotNull(result);
			var query = result.Content.First();
			Assert.AreEqual(string.Empty, query.Parameters);
			Assert.AreEqual("carRental/Add", query.Url);
			Assert.IsTrue(query.StartTime > DateTime.UtcNow.AddSeconds(-1));
		}
	}
}
