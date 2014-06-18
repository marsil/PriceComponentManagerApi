using System;
using System.Web.Http;
using PriceComponentManager.Database.Dto;
using PriceComponentManager.Database.Enums;
using PriceComponentManger.WebApi.Commands.Parameters;
using PriceComponentManger.WebApi.Common;
using PriceComponentManger.WebApi.Configuration;
using PriceComponentManger.WebApi.Queries;
using PriceComponentManger.WebApi.Queries.Parameters;

namespace PriceComponentManger.WebApi.Controllers
{
	public class CarRentalController : BaseController
	{
		//public IHttpActionResult Retrieve(string priceComponentCodes, string marketUnitCode, DateTime? fromDate, DateTime toDate, string userId)
		//{
		//	var carRentalQueryPararmeters = new CarRentalQueryPararmeters
		//				{
		//					PriceComponentCodes = priceComponentCodes,
		//					MarketUnitCode = marketUnitCode,
		//					FromDate = fromDate,
		//					ToDate = toDate,
		//					UserId = userId
		//				};

		//	return this.GetData(CarRentalQuery.GetCarRentalQueryData, carRentalQueryPararmeters);
		//}

		[HttpPost]
		public IHttpActionResult Retrieve(CarRentalQueryPararmeters carRentalQueryPararmeters)
		{
			return this.GetData(CarRentalQuery.GetCarRentalQueryData, carRentalQueryPararmeters);
		}

		[HttpPost]
		public IHttpActionResult Save(SaveCarRentalsParameter saveCarRentalsParameter)
		{
			try
			{
				foreach (var carRentalDto in saveCarRentalsParameter.CarRentals)
				{
					if (carRentalDto.NewRow)
					{
						carRentalDto.PriceComponentAmountId = 1;
						carRentalDto.NewRow = false;
						this.AddData(EntityType.CarRental, carRentalDto);
					}
					if (carRentalDto.DeleteRow)
					{
						carRentalDto.DeleteRow = false;
						this.DeleteData(EntityType.CarRental, carRentalDto);
					}
					else this.UpdateData(EntityType.CarRental, carRentalDto);
				}

				return this.Ok();
			}
			catch(Exception exception)
			{
				WebExceptionHandler.LogToDatabase(exception, this.Request, saveCarRentalsParameter);
				return this.InternalServerError(exception);
			}
		}

		[HttpGet]
		public IHttpActionResult All()
		{
			return this.GetData(ServiceProvider<CarRentalDto>.DataRepository.GetItems);
		}

		[HttpPost]
		public IHttpActionResult Add([FromBody]CarRentalDto carRentalDto)
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