using System;
using System.Collections.Generic;
using System.Linq;
using PriceComponentManager.Api.Events;
using PriceComponentManager.Api.Utils;

namespace PriceComponentManager.Api.Domain
{
	public abstract class AggregateRoot : IEventProvider
	{
		private readonly List<CommandEvent> _changes;

		public Guid Id { get; set; }

		//public Guid Id { get; internal set; }

		public int Version { get; internal set; }
		
		public int EventVersion { get; protected set; }

		public AggregateRoot()
		{
			_changes = new List<CommandEvent>();
		}
		//protected AggregateRoot()
		//{
		//	_changes = new List<CommandEvent>();
		//}

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