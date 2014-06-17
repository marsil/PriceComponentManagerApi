﻿using System;
using PriceComponentManager.Cqrs.Domain;

namespace PriceComponentManager.Cqrs.Storage
{
	public interface IRepository<T> where T : AggregateRoot, new()
	{
		void Save(AggregateRoot aggregate, int expectedVersion);

		T GetById(Guid id);
	}
}
