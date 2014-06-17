using System;
using PriceComponentManager.Database.Dto;

namespace PriceComponentManager.Cqrs.Commands
{
	public class ChangeItemCommand : Command
	{
		public EventDto EventDto { get; private set; }

		public ChangeItemCommand(Guid aggregateId, int version, EventDto eventDto)
			: base(aggregateId, version)
		{
			this.EventDto = eventDto;
		}
	}
}
