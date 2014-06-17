using System;

namespace PriceComponentManager.Cqrs.Commands
{
	public interface ICommand
	{
		Guid UniqueId { get; }
	}
}
