using System;
using System.Web.Http;

using PriceComponentManager.Cqrs.Queries;
using PriceComponentManager.Database.Dto;
using PriceComponentManager.Database.Enums;

namespace PriceComponentManager.Api.Controllers
{
	public class PriceComponentController : BaseController
	{
		public IHttpActionResult Get(string priceComponentCodes = "", string marketUnitCode = "", DateTime? fromDate = null, DateTime? toDate = null, string userId = "")
		{
			return this.GetData(PriceComponentQuery.GetPriceComponents);
		}

		[HttpPost]
		public IHttpActionResult Add(PriceComponentDto priceComponentDto)
		{
			return this.AddData(EntityType.PriceComponent, priceComponentDto);
		}
	}
}