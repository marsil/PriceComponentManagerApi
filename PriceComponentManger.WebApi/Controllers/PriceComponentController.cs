using System.Web.Http;
using PriceComponentManager.Database.Dto;
using PriceComponentManager.Database.Enums;
using PriceComponentManger.WebApi.Configuration;

namespace PriceComponentManger.WebApi.Controllers
{
	public class PriceComponentController : BaseController
	{
		public IHttpActionResult GetAll()
		{
			return this.Ok(ServiceProvider<PriceComponentDto>.DataRepository.GetItems());
		}

		[HttpPost]
		public IHttpActionResult Add(PriceComponentDto priceComponentDto)
		{
			return this.AddData(EntityType.PriceComponent, priceComponentDto);
		}
	}
}