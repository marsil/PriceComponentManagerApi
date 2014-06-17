using System;
using PriceComponentManager.Database.Enums;

namespace PriceComponentManager.Database.Dto  
{
	public class EventDto<T> : IHaveUniqueId
	{
		public Guid UniqueId { get; set; }

		public int RowNr { get; set; }

		public EventType Type { get; set; }

		public EntityType EntityType { get; set; }

		public T Data { get; set; }

		public DateTime StartTime { get; set; }

		public DateTime? EndTime { get; set; }

		public int Version { get; set; }
	}
}
