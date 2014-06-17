using System;

namespace PriceComponentManager.Api.Commands
{
	public class Command : ICommand
	{
		public Command(Guid id, int version)
		{
			Id = id;
			Version = version;
		}

		public Guid Id { get; private set; }
		
		public int Version { get; private set; }
	}
}