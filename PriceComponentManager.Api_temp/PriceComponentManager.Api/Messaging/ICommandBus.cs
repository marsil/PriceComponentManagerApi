using PriceComponentManager.Api.Commands;

namespace PriceComponentManager.Api.Messaging
{
	public interface ICommandBus
	{
		void Send<T>(T command) where T : Command;
	}
}
