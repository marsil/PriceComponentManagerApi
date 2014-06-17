using System;
using System.Web.Http;
using PriceComponentManager.Database.Dto;
using PriceComponentManager.Database.Enums;
using PriceComponentManger.WebApi.Configuration;
using PriceComponentManger.WebApi.Queries;

namespace PriceComponentManger.WebApi.Controllers
{
	public class CarRentalController : BaseController
	{
		public IHttpActionResult Get(string priceComponentCodes = "", string marketUnitCode = "", DateTime? fromDate = null, DateTime? toDate = null, string userId = "")
		{
			//ServiceProvider<CarRentalDto>.Database.AddQuery()
			return this.GetData(CarRentalQuery.GetCarRentalQueryData);
		}

		[HttpGet]
		public IHttpActionResult All()
		{
			return this.Ok(ServiceProvider<CarRentalDto>.DataRepository.GetItems());
		}

		[HttpPost]
		public IHttpActionResult Add(CarRentalDto carRentalDto)
		{
			return this.AddData(EntityType.CarRental, carRentalDto);
		}

		[HttpPost]
		public IHttpActionResult Delete(CarRentalDto carRentalDto)
		{
			return this.DeleteData(EntityType.CarRental, carRentalDto);
		}

		[HttpPost]
		public IHttpActionResult Update(CarRentalDto carRentalDto)
		{
			return this.UpdateData(EntityType.CarRental, carRentalDto);
		}
	}
}