using System;
using PriceComponentManager.Api.Domain;

namespace PriceComponentManager.Api.Storage
{
	public interface IRepository<T> where T : AggregateRoot, new()
	{
		void Save(AggregateRoot aggregate, int expectedVersion);

		T GetById(Guid id);
	}
}
