using System;

namespace PriceComponentManager.Api.Commands
{
	public interface ICommand
	{
		Guid Id { get; }
	}
}
