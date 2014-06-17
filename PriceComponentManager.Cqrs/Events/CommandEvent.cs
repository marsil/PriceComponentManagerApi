using System;

namespace PriceComponentManager.Cqrs.Events
{
	[Serializable]
    public class CommandEvent
    {
		public int Version { get; set; }

		public Guid AggregateId { get; set; }
    }
}