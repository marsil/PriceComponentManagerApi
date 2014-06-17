using System;
using PriceComponentManager.Api.Models;

namespace PriceComponentManager.Api.Events
{
	public class CarRentalCreatedCommandEvent : CommandEvent
	{
		private readonly CarRental carRental;

		public CarRentalCreatedCommandEvent(Guid aggregateId, CarRental carRental)
		{
			this.carRental = carRental;
			AggregateId = aggregateId;
		}

		public CarRental CarRental
		{
			get
			{
				return this.carRental;
			}
		}
	}
}