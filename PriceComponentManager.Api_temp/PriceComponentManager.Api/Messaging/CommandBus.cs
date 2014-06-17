using PriceComponentManager.Api.Commands;
using PriceComponentManager.Api.Exceptions;
using PriceComponentManager.Api.Utils;

namespace PriceComponentManager.Api.Messaging
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