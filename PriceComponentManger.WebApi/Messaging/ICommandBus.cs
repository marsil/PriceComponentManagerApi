using PriceComponentManger.WebApi.Commands.Base;

namespace PriceComponentManger.WebApi.Messaging
{
	public interface ICommandBus
	{
		void Send<T>(T command) where T : ICommand;
	}
}
