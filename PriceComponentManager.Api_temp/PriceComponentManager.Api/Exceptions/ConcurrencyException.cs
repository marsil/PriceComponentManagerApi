using System;

namespace PriceComponentManager.Api.Exceptions
{
	public class ConcurrencyException : Exception
	{
		public ConcurrencyException(string message) : base(message) { }
	}
}