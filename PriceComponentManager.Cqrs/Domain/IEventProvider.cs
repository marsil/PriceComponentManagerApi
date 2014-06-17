using System.Collections.Generic;

using PriceComponentManager.Cqrs.Events;

namespace PriceComponentManager.Cqrs.Domain
{
	public interface IEventProvider
	{
		void LoadsFromHistory(IEnumerable<CommandEvent> history);

		IEnumerable<CommandEvent> GetUncommittedChanges();
	}
}
