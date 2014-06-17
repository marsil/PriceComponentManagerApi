using System;

using AutoMapper;

using PriceComponentManager.Api.Commands;
using PriceComponentManager.Api.Models;
using PriceComponentManager.Api.Storage;

namespace PriceComponentManager.Api.CommandHandlers
{
	public class CarRentalSaveCommandHandler : ICommandHandler<CarRentalSaveCommand>
	{
		private readonly IRepository<CarRental> repository;

		public CarRentalSaveCommandHandler(IRepository<CarRental> repository)
		{
			this.repository = repository;
		}

		public void Execute(CarRentalSaveCommand command)
		{
			if (command == null)
			{
				throw new ArgumentNullException("command");
			}

			if (this.repository == null)
			{
				throw new InvalidOperationException("Repository is not initialized.");
			}

			var aggregate = command.Parameters;
			aggregate.Version = -1;
			this.repository.Save(aggregate, aggregate.Version);
		}
	}
}
