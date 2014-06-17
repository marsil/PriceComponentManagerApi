using System;
using System.Web.Http;
using PriceComponentManager.Api.Commands;
using PriceComponentManager.Api.Configuration;
using PriceComponentManager.Api.Models;
using PriceComponentManager.Api.Queries;

namespace PriceComponentManager.Api.Controllers
{
	public class CarRentalController : ApiController
	{
		public IHttpActionResult Get(string priceComponentCodes = "", string marketUnitCode = "", DateTime? fromDate = null, DateTime? toDate = null, string userId = "")
		{
			return this.Ok(CarRentalQuery.GetCarRentalQueryData());
		}

		[HttpPost]
		public IHttpActionResult Add(CarRental carRental)
		{
			ServiceLocator.CommandBus.Send(new CarRentalSaveCommand(Guid.NewGuid(), -1, carRental));

			return this.Ok();
		}
	}
}
