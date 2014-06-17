using System;

namespace PriceComponentManager.Api.Exceptions
{
	public class AggregateNotFoundException : Exception
	{
		public AggregateNotFoundException(string message) : base(message) { }
	}
}