using System;

namespace PriceComponentManager.Api.Exceptions
{
	public class UnregisteredDomainCommandException : Exception
	{
		public UnregisteredDomainCommandException(string message) : base(message) { }
	}
}