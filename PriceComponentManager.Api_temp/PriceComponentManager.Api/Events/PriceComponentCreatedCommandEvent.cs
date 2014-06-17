using System;
using PriceComponentManager.Api.Models;

namespace PriceComponentManager.Api.Events
{
	public class PriceComponentCreatedCommandEvent : CommandEvent
	{
		private readonly PriceComponent priceComponent;

		public PriceComponentCreatedCommandEvent(Guid aggregateId, PriceComponent priceComponent)
		{
			this.priceComponent = priceComponent;
			AggregateId = aggregateId;
		}

		public PriceComponent PriceComponent
		{
			get
			{
				return this.priceComponent;
			}
		}
	}
}