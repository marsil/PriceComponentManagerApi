using System;
using PriceComponentManager.Api.Dto;
using PriceComponentManager.Api.Models;

namespace PriceComponentManager.Api.Commands
{
	public class CarRentalSaveCommand : Command
	{
		public CarRentalSaveCommand(Guid aggregateId, int version, CarRental parameters)
			: base(aggregateId, version)
		{
			this.Parameters = parameters;
		}

		public CarRental Parameters { get; private set; }
	}
}