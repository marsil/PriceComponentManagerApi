using PriceComponentManager.Cqrs.Commands;

namespace PriceComponentManager.Cqrs.Utils
{
	public interface ICommandHandlerFactory
	{
		ICommandHandler<T> GetHandler<T>() where T : Command;
	}
}
