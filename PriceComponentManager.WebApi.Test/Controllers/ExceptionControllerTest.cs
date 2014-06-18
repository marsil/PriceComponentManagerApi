using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PriceComponentManager.Database.Dto;
using PriceComponentManger.WebApi.Controllers;

namespace PriceComponentManager.WebApi.Test.Controllers
{
	[TestClass]
	public class ExceptionControllerTest
	{
		[TestMethod]
		public void AddCarRentalWithError_ShouldGenerateExceptionLog()
		{
			var exceptionController = new ExceptionController();
			var exceptionResult = exceptionController.TestOfException() as ExceptionResult;
			Assert.IsNotNull(exceptionResult);

			var result = exceptionController.Get(1) as OkNegotiatedContentResult<List<ExceptionDto>>;

			Assert.IsNotNull(result);
			var exception = result.Content.First();
			Assert.AreEqual("TestOfException", exception.Messsage);
			Assert.AreNotEqual(string.Empty, exception.StackTrace);
			Assert.IsTrue(exception.Time > DateTime.UtcNow.AddSeconds(-1));
		}
	}
}
