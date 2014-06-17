using System;

namespace PriceComponentManager.Cqrs.Commands
{
	public class DeleteItemCommand : Command
	{
		public DeleteItemCommand(Guid uniqueId, int version)
			: base(uniqueId, version)
		{
		}
	}
}
