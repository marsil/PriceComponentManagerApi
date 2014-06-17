using System;

namespace PriceComponentManager.Database.Dto
{
	public class PriceComponentDto : IHaveUniqueId
	{
		public Guid UniqueId { get; set; }

		public string PriceComponentCode { get; set; }
		
		public bool NewRow { get; set; }

		public bool DeleteRow { get; set; }
	}
}
