using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PriceComponentManager.Api.Controllers;
using PriceComponentManager.Api.Test.TestData;
using PriceComponentManager.Cqrs.Models;
using PriceComponentManager.Database.Dto;

namespace PriceComponentManager.Api.Test.Controllers
{
	[TestClass]
	public class CarRentalControllerTest
	{
		[TestMethod]
		public void AddCarRental_ShouldReturnOneCarRental()
		{
			var controller = new CarRentalController();
			var carRentalQueryData = CarRentalTestData.GetCarRentalQueryData();
			var resultAdd = controller.Add(carRentalQueryData.CarRentals.First()) as OkResult;

			var result = controller.Get() as OkNegotiatedContentResult<CarRentalQueryData>;

			Assert.IsNotNull(resultAdd);
			Assert.IsNotNull(result);
			Assert.IsTrue(carRentalQueryData.CarRentals.First().Compare(result.Content.CarRentals.Last()).AreEqual);
		}

		[TestMethod]
		public void DeleteCarRental_ShouldNotContainAddedCarRental()
		{
			var controller = new CarRentalController();
			var carRentalQueryData = CarRentalTestData.GetCarRentalQueryData();
			var resultAdd = controller.Add(carRentalQueryData.CarRentals.First());
			
			var resultAfterAdd = controller.Get() as OkNegotiatedContentResult<CarRentalQueryData>;
			controller.Delete(resultAfterAdd.Content.CarRentals.Last());

			var result = controller.Get() as OkNegotiatedContentResult<CarRentalQueryData>;

			Assert.IsNotNull(resultAdd);
			Assert.IsNotNull(result);
			Assert.AreEqual(resultAfterAdd.Content.CarRentals.Count - 1, result.Content.CarRentals.Count);
			Assert.IsFalse(result.Content.CarRentals.Contains(carRentalQueryData.CarRentals.First()));
		}

		[TestMethod]
		public void AddCarPriceComponent_ShouldReturnOnePriceComponent()
		{
			var controller = new PriceComponentController();
			var carRentalQueryData = CarRentalTestData.GetCarRentalQueryData();
			var resultAdd = controller.Add(carRentalQueryData.PriceComponents.First());

			var result = controller.Get() as OkNegotiatedContentResult<List<PriceComponentDto>>;

			Assert.IsNotNull(resultAdd);
			Assert.IsNotNull(result);
			Assert.IsTrue(carRentalQueryData.PriceComponents.First().Compare(result.Content.Last()).AreEqual);
		}
	}
}
