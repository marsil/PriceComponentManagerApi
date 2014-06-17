using System;
using System.Web.Http;

using PriceComponentManager.Cqrs.Queries;
using PriceComponentManager.Database.Dto;
using PriceComponentManager.Database.Enums;

using PriceComponentManger.WebApi.Queries;

namespace PriceComponentManager.Api.Controllers
{
	public class CarRentalController : BaseController
	{
		public IHttpActionResult Get(string priceComponentCodes = "", string marketUnitCode = "", DateTime? fromDate = null, DateTime? toDate = null, string userId = "")
		{
			return this.GetData(CarRentalQuery.GetCarRentalQueryData);
		}

		[HttpPost]
		public IHttpActionResult Add(CarRentalDto carRentalDto)
		{
			return this.AddData(EntityType.CarRental, carRentalDto);
		}

		[HttpPost]
		public IHttpActionResult Delete(CarRentalDto carRentalDto)
		{
			return this.DeleteData(carRentalDto);
		}
	}
}
