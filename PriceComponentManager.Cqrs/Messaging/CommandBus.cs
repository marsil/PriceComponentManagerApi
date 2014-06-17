using PriceComponentManager.Cqrs.Commands;
using PriceComponentManager.Cqrs.Exceptions;
using PriceComponentManager.Cqrs.Utils;

namespace PriceComponentManager.Cqrs.Messaging
{
	public class CommandBus : ICommandBus
	{
		private readonly ICommandHandlerFactory _commandHandlerFactory;

		public CommandBus(ICommandHandlerFactory commandHandlerFactory)
		{
			_commandHandlerFactory = commandHandlerFactory;
		}

		public void Send<T>(T command) where T : Command
		{
			var handler = _commandHandlerFactory.GetHandler<T>();
			if(handler != null)
			{
				handler.Execute(command);
			}
			else
			{
				throw new UnregisteredDomainCommandException("no handler registered");
			}
		}
	}
}