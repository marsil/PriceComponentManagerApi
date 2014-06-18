using PriceComponentManger.WebApi.Commands.Base;

namespace PriceComponentManger.WebApi.Messaging
{
	public class CommandBus : ICommandBus
	{
		public void Send<T>(T command) where T : ICommand
		{
			command.Execute();
		}
	}
}