using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PriceComponentManager.Database.Dto;
using PriceComponentManager.Database.Enums;
using PriceComponentManager.WebApi.Test.Infrastucture;
using PriceComponentManager.WebApi.Test.TestData;
using PriceComponentManger.WebApi.Controllers;

namespace PriceComponentManager.WebApi.Test.Controllers
{
	[TestClass]
	public class EventControllerTest
	{
		[Ignore]
		[TestMethod]
		public void AddEntityUsingPost_ShouldCreateAddEvent()
		{
			var result = WebRequestExecutor.PostData("carRental/Add", CarRentalTestData.GetCarRental());
			var obj = WebRequestExecutor.SendRequest<CarRentalDto>("carRental/All");
			//new CarRentalController().Add(CarRentalTestData.GetCarRental());

			//var result = new EventController<CarRentalDto>().Get(EntityType.CarRental) as OkNegotiatedContentResult<List<EventDto<CarRentalDto>>>;

			//AssertEvent(result, EventType.Created);
		}

		[TestMethod]
		public void AddEntity_ShouldCreateAddEvent()
		{
			new CarRentalController().Add(CarRentalTestData.GetCarRental());

			var result = new EventController<CarRentalDto>().Get(EntityType.CarRental) as OkNegotiatedContentResult<List<EventDto<CarRentalDto>>>;

			AssertEvent(result, EventType.Created);
		}

		[TestMethod]
		public void AddEntity_ShouldCreateUpdateEvent()
		{
			var carRental = CarRentalTestData.GetCarRental();
			var carRentalController = new CarRentalController();
			carRentalController.Add(carRental);
			carRental.Cost = "6000";
			carRentalController.Update(carRental);

			var result = new EventController<CarRentalDto>().Get(EntityType.CarRental) as OkNegotiatedContentResult<List<EventDto<CarRentalDto>>>;

			AssertEvent(result, EventType.Updated);
		}

		[TestMethod]
		public void AddEntity_ShouldCreateDeleteEvent()
		{
			var carRental = CarRentalTestData.GetCarRental();
			var carRentalController = new CarRentalController();
			carRentalController.Add(carRental);
			carRentalController.Delete(carRental);
		
			var result = new EventController<CarRentalDto>().Get(EntityType.CarRental) as OkNegotiatedContentResult<List<EventDto<CarRentalDto>>>;

			AssertEvent(result, EventType.Deleted);
		}

		private static void AssertEvent<T>(OkNegotiatedContentResult<List<EventDto<T>>> result, EventType eventType)
		{
			Assert.IsNotNull(result);
			var lastEvent = result.Content.Last();
			Assert.AreEqual(EntityType.CarRental, lastEvent.EntityType);
			Assert.AreEqual(eventType, lastEvent.Type);
		}
	}
}
