using System;

namespace PriceComponentManager.Cqrs.Exceptions
{
	public class AggregateNotFoundException : Exception
	{
		public AggregateNotFoundException(string message) : base(message) { }
	}
}