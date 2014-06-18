using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PriceComponentManager.Database.Dto;
using PriceComponentManager.Database.Enums;
using PriceComponentManager.WebApi.Test.Extension;
using PriceComponentManager.WebApi.Test.TestData;
using PriceComponentManger.WebApi.Controllers;
using PriceComponentManger.WebApi.Models;
using PriceComponentManger.WebApi.Queries.Parameters;

namespace PriceComponentManager.WebApi.Test.Controllers
{
	[TestClass]
	public class CarRentalControllerTest
	{
		[TestMethod]
		public void AddCarRental_ShouldReturnOneCarRental()
		{
			var controller = new CarRentalController();
			var carRental = CarRentalTestData.GetCarRental();
			var resultOfAdd = controller.Add(carRental) as OkResult;

			var result = controller.Retrieve(new CarRentalQueryPararmeters()) as OkNegotiatedContentResult<CarRentalQueryData>;

			Assert.IsNotNull(resultOfAdd);
			Assert.IsNotNull(result);
			Assert.IsTrue(carRental.Compare(result.Content.CarRentals.Last()).AreEqual);
		}

		[TestMethod]
		public void DeleteCarRental_ShouldCreateDeletedEvent()
		{
			var controller = new CarRentalController();
			var resultOfAdd = controller.Add(CarRentalTestData.GetCarRental()) as OkResult;
			var resultAfterAdd = controller.All() as OkNegotiatedContentResult<List<CarRentalDto>>;
			Assert.IsNotNull(resultAfterAdd);
			var resultOfDelete = controller.Delete(resultAfterAdd.Content.Last()) as OkResult;
			
			var eventController = new EventController<CarRentalDto>();
			var eventsAfterAdd = eventController.Get(EntityType.CarRental) as OkNegotiatedContentResult<List<EventDto<CarRentalDto>>>;
			
			Assert.IsNotNull(eventsAfterAdd);
			var lastEvent = eventsAfterAdd.Content.Last();
			Assert.IsNotNull(resultOfAdd);
			Assert.IsNotNull(resultOfDelete);

			Assert.AreEqual(EntityType.CarRental, lastEvent.EntityType);
			Assert.AreEqual(EventType.Deleted, lastEvent.Type);
		}

		[TestMethod]
		public void DeleteCarRental_ShouldRemoveCarRental()
		{
			var controller = new CarRentalController();
			var carRental = CarRentalTestData.GetCarRental();
			var itemsBeforeAdd = controller.All() as OkNegotiatedContentResult<List<CarRentalDto>>;
			var resultOfAdd = controller.Add(carRental) as OkResult;
			var resultOfDelete = controller.Delete(carRental) as OkResult;
			var itemsAfterDelete = controller.All() as OkNegotiatedContentResult<List<CarRentalDto>>;

			Assert.IsNotNull(resultOfAdd);
			Assert.IsNotNull(itemsBeforeAdd);
			Assert.IsNotNull(resultOfDelete);
			Assert.IsNotNull(itemsAfterDelete);
			Assert.AreEqual(itemsBeforeAdd.Content.Count, itemsAfterDelete.Content.Count());
		}
	}
}
