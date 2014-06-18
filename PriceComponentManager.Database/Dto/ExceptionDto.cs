using System;

namespace PriceComponentManager.Database.Dto
{
	public class ExceptionDto : IHaveUniqueId
	{
		public Guid UniqueId { get; set; }

		public int RowNr { get; set; }

		public string UserId { get; set; }

		public string Url { get; set; }

		public string Parameters { get; set; }

		public string Messsage { get; set; }

		public string Source { get; set; }

		public string StackTrace { get; set; }

		public DateTime Time { get; set; }
	}
}
