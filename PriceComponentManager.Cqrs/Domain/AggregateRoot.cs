using System;
using System.Collections.Generic;
using System.Linq;
using PriceComponentManager.Cqrs.Events;
using PriceComponentManager.Cqrs.Utils;

namespace PriceComponentManager.Cqrs.Domain
{
	public abstract class AggregateRoot : IEventProvider
	{
		private readonly List<CommandEvent> _changes;

		public Guid UniqueId { get; internal set; }

		public int Version { get; internal set; }
		
		public int EventVersion { get; protected set; }

		protected AggregateRoot()
		{
			_changes = new List<CommandEvent>();
		}

		public IEnumerable<CommandEvent> GetUncommittedChanges()
		{
			return _changes;
		}

		public void MarkChangesAsCommitted()
		{
			_changes.Clear();
		}

		public void LoadsFromHistory(IEnumerable<CommandEvent> history)
		{
			foreach(var e in history) ApplyChange(e, false);
			Version = history.Last().Version;
			EventVersion = Version;
		}

		protected void ApplyChange(CommandEvent commandEvent)
		{
			ApplyChange(commandEvent, true);
		}

		private void ApplyChange(CommandEvent commandEvent, bool isNew)
		{
			dynamic d = this;

			d.Handle(Converter.ChangeTo(commandEvent, commandEvent.GetType()));
			if(isNew)
			{
				_changes.Add(commandEvent);
			}
		}
	}
}