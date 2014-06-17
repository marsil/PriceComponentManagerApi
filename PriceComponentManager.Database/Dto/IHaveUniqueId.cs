using System;

namespace PriceComponentManager.Database.Dto
{
	public interface IHaveUniqueId
	{
		Guid UniqueId { get; set; }
	}
}
