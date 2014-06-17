using System;
using PriceComponentManager.Api.Domain;
using PriceComponentManager.Api.Domain.Mementos;
using PriceComponentManager.Api.Events;
using PriceComponentManager.Api.Storage.Memento;

namespace PriceComponentManager.Api.Models
{
	public class CarRental : AggragateRootImpl,
		IHandle<CarRentalCreatedCommandEvent>,
		IOriginator
	{
		public string MarketUnitCode { get; set; }
		
		public string PriceComponentCode { get; set; }
		
		public int PriceComponentInstanceId { get; set; }
		
		public int PriceComponentAmountId { get; set; }
		
		public string Destination { get; set; }
		
		public string Category { get; set; }
		
		public string Duration { get; set; }
		
		public int Amount { get; set; }
		
		public DateTime DateFrom { get; set; }
		
		public DateTime DateTo { get; set; }
		
		public int ContractCost { get; set; }
		
		public string CurrencyCode { get; set; }
		
		public string Cost { get; set; }
		
		public bool NewCarRental { get; set; }

		public void Handle(CarRentalCreatedCommandEvent @event)
		{
			throw new NotImplementedException();
		}

		public BaseMemento GetMemento()
		{
			throw new NotImplementedException();
		}

		public void SetMemento(BaseMemento memento)
		{
			throw new NotImplementedException();
		}
	}
}