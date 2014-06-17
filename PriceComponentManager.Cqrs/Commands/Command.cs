using System;

namespace PriceComponentManager.Cqrs.Commands
{
	public class Command : ICommand
	{
		public Command(Guid uniqueId, int version)
		{
			this.UniqueId = uniqueId;
			this.Version = version;
		}

		public Guid UniqueId { get; private set; }
		
		public int Version { get; private set; }
	}
}