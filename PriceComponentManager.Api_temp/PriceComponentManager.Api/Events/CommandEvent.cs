using System;

namespace PriceComponentManager.Api.Events
{
	 [Serializable]
    public class CommandEvent : IEvent
    {
        public int Version;

        public Guid AggregateId { get; set; }

        public Guid Id { get; private set; }
    }
}