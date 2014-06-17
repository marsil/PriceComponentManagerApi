using System.Collections.Generic;
using PriceComponentManager.Api.Events;

namespace PriceComponentManager.Api.Domain
{
	public interface IEventProvider
	{
		void LoadsFromHistory(IEnumerable<CommandEvent> history);

		IEnumerable<CommandEvent> GetUncommittedChanges();
	}
}
