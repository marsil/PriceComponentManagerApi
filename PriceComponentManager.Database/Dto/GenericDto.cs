using System;

namespace PriceComponentManager.Database.Dto
{
	public class GenericDto : IHaveUniqueId
	{
		public Guid UniqueId { get; set; }
	}
}
