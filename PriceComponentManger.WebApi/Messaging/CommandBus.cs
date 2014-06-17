using PriceComponentManger.WebApi.Commands;

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