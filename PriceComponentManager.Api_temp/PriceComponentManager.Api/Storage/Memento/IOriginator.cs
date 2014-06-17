using PriceComponentManager.Api.Domain.Mementos;

namespace PriceComponentManager.Api.Storage.Memento
{
	public interface IOriginator
	{
		BaseMemento GetMemento();

		void SetMemento(BaseMemento memento);
	}
}
