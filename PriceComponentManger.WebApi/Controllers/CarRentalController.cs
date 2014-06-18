using System.Collections.Generic;
using System.Web.Http;
using PriceComponentManager.Database.Dto;
using PriceComponentManager.Database.Enums;
using PriceComponentManger.WebApi.Configuration;
using PriceComponentManger.WebApi.Queries;
using PriceComponentManger.WebApi.Queries.Parameters;

namespace PriceComponentManger.WebApi.Controllers
{
	public class CarRentalController : BaseController
	{
		public IHttpActionResult Get(CarRentalQueryPararmeters parameters)
		{
			return this.GetData(CarRentalQuery.GetCarRentalQueryData, parameters);
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