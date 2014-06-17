using System;

using PriceComponentManager.Api.Domain;
using PriceComponentManager.Api.Domain.Mementos;
using PriceComponentManager.Api.Events;
using PriceComponentManager.Api.Storage.Memento;

namespace PriceComponentManager.Api.Models
{
	public class PriceComponent : AggragateRootImpl,
		IHandle<PriceComponentCreatedCommandEvent>,
		IOriginator
	{
		public string PriceComponentCode { get; set; }

		public void Handle(PriceComponentCreatedCommandEvent @event)
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