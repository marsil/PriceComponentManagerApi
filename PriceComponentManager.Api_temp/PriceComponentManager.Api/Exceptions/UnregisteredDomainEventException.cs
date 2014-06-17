using System;

namespace PriceComponentManager.Api.Exceptions
{
	public class UnregisteredDomainEventException : Exception
	{
		public UnregisteredDomainEventException(string message) : base(message) { }
	}
}