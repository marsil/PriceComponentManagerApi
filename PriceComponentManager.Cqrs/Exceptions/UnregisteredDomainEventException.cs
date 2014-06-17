﻿using System;

namespace PriceComponentManager.Cqrs.Exceptions
{
	public class UnregisteredDomainEventException : Exception
	{
		public UnregisteredDomainEventException(string message) : base(message) { }
	}
}