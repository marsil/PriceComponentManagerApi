namespace PriceComponentManager.Cqrs.Commands
{
	public interface ICommandHandler<in TCommand> where TCommand : Command
	{
		void Execute(TCommand command);
	}
}
