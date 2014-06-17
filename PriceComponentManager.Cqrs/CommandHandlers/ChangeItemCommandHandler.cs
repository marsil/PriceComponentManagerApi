using System;
using PriceComponentManager.Cqrs.Commands;
using PriceComponentManager.Cqrs.Domain;
using PriceComponentManager.Cqrs.Storage;

namespace PriceComponentManager.Cqrs.CommandHandlers
{
	public class ChangeItemCommandHandler : ICommandHandler<ChangeItemCommand>
	{
		private readonly IRepository<EventAggregate> repository;

		public ChangeItemCommandHandler(IRepository<EventAggregate> repository)
		{
			this.repository = repository;
		}

		public void Execute(ChangeItemCommand command)
		{
			if(command == null)
			{
				throw new ArgumentNullException("command");
			}
			if(this.repository == null)
			{
				throw new InvalidOperationException("Repository is not initialized.");
			}

			var aggregate = this.repository.GetById(command.UniqueId);

			aggregate.Update(command.EventDto);

			this.repository.Save(aggregate, command.Version);
		}
	}
}
