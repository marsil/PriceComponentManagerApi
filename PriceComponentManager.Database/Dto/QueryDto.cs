﻿using System;

namespace PriceComponentManager.Database.Dto
{
	public class QueryDto : IHaveUniqueId
	{
		public Guid UniqueId { get; set; }

		public int RowNr { get; set; }

		public string UserId { get; set; }

		public string Url { get; set; }

		public string Parameters { get; set; }

		public string Data { get; set; }

		public DateTime StartTime { get; set; }

		public DateTime? EndTime { get; set; }
	}
}
