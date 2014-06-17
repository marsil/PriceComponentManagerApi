using System;
using PriceComponentManager.Cqrs.Commands;
using PriceComponentManager.Cqrs.Domain;
using PriceComponentManager.Cqrs.Storage;

namespace PriceComponentManager.Cqrs.CommandHandlers
{
	public class CreateItemCommandHandler : ICommandHandler<CreateItemCommand>
	{
		private readonly IRepository<EventAggregate> repository;

		public CreateItemCommandHandler(IRepository<EventAggregate> repository)
		{
			this.repository = repository;
		}

		public void Execute(CreateItemCommand command)
		{
			if(command == null)
			{
				throw new ArgumentNullException("command");
			}

			if(this.repository == null)
			{
				throw new InvalidOperationException("Repository is not initialized.");
			}

			var aggregate = new EventAggregate(command.UniqueId, -1, command.EventDto);

			this.repository.Save(aggregate, aggregate.Version);
		}
	}
}
