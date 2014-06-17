using PriceComponentManager.Cqrs.Commands;

namespace PriceComponentManager.Cqrs.Messaging
{
	public interface ICommandBus
	{
		void Send<T>(T command) where T : Command;
	}
}
