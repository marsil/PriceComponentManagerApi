using System;

namespace PriceComponentManager.Api.Domain
{
	public interface IHaveId
	{
		Guid Id { get; set; }
	}
}
