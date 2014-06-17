using System;
using PriceComponentManager.Cqrs.Commands;
using PriceComponentManager.Cqrs.Domain;
using PriceComponentManager.Cqrs.Storage;

namespace PriceComponentManager.Cqrs.CommandHandlers
{
	public class DeleteItemCommandHandler : ICommandHandler<DeleteItemCommand>
	{
		private readonly IRepository<EventAggregate> repository;

		public DeleteItemCommandHandler(IRepository<EventAggregate> repository)
		{
			this.repository = repository;
		}

		public void Execute(DeleteItemCommand command)
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
			aggregate.Delete();
			this.repository.Save(aggregate, aggregate.Version);
		}
	}
}
