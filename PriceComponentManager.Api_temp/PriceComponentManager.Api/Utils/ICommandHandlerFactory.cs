using PriceComponentManager.Api.Commands;

namespace PriceComponentManager.Api.Utils
{
	public interface ICommandHandlerFactory
	{
		ICommandHandler<T> GetHandler<T>() where T : Command;
	}
}
