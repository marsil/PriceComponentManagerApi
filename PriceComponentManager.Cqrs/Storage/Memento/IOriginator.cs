using PriceComponentManager.Cqrs.Domain.Mementos;

namespace PriceComponentManager.Cqrs.Storage.Memento
{
	public interface IOriginator
	{
		BaseMemento GetMemento();

		void SetMemento(BaseMemento memento);
	}
}
