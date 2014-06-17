using System;

namespace PriceComponentManager.Cqrs.Domain.Mementos
{
	public class BaseMemento
	{
		public Guid UniqueId { get; internal set; }

		public int Version { get; set; }
	}
}