using System;

namespace PriceComponentManager.Cqrs.Exceptions
{
	public class UnregisteredDomainCommandException : Exception
	{
		public UnregisteredDomainCommandException(string message) : base(message) { }
	}
}