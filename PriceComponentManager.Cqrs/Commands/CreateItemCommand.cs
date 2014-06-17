using System;
using PriceComponentManager.Database.Dto;

namespace PriceComponentManager.Cqrs.Commands
{
	public class CreateItemCommand<T> : Command
	{
		public EventDto<T> EventDto { get; private set; }

		public CreateItemCommand(Guid aggregateId, int version, EventDto<T> eventDto)
			: base(aggregateId, version)
		{
			this.EventDto = eventDto;
		}
	}
}
