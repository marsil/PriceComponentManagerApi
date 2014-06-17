using System;
using PriceComponentManager.Database.Enums;

namespace PriceComponentManager.Database.Dto
{
	public class QueryDto<TParameter, TData>
	{
		public Guid UniqueId { get; set; }

		public int RowNr { get; set; }

		public EntityType EntityType { get; set; }

		public TParameter Parameters { get; set; }

		public string Url { get; set; }

		public TData Data { get; set; }

		public DateTime StartTime { get; set; }

		public DateTime? EndTime { get; set; }
	}
}
