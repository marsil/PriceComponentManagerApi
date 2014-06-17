using System;

namespace PriceComponentManager.Cqrs.Exceptions
{
	public class ConcurrencyException : Exception
	{
		public ConcurrencyException(string message) : base(message) { }
	}
}