using System;

namespace PriceComponentManager.Database.Dto
{
	public class PriceComponentDto : IHaveUniqueId
	{
		public Guid UniqueId { get; set; }

		public string PriceComponentCode { get; set; }
	}
}
