using System;

namespace PriceComponentManager.Api.Events
{
	public interface IEvent
	{
		Guid Id { get; }
	}
}
