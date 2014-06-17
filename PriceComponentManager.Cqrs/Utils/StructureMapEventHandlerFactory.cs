using System;
using System.Collections.Generic;
using System.Linq;

using PriceComponentManager.Cqrs.EventHandlers;
using PriceComponentManager.Cqrs.Events;

using StructureMap;

namespace PriceComponentManager.Cqrs.Utils
{
	public class StructureMapEventHandlerFactory : IEventHandlerFactory
	{
		public IEnumerable<IEventHandler<T>> GetHandlers<T>() where T : CommandEvent
		{
			var handlers = GetHandlerType<T>();

			var lstHandlers = handlers.Select(handler => (IEventHandler<T>)ObjectFactory.GetInstance(handler)).ToList();
			return lstHandlers;
		}

		private static IEnumerable<Type> GetHandlerType<T>() where T : CommandEvent
		{/*
            var handlers = typeof(IEventHandler<T>).Assembly.GetExportedTypes()
                .Where(x => x.GetInterfaces()
                    .Any(a => a.IsGenericType && a.GetGenericTypeDefinition() == typeof(IEventHandler<>)));
            return handlers;*/

			var handlers = typeof(IEventHandler<>).Assembly.GetExportedTypes()
				.Where(x => x.GetInterfaces()
					.Any(a => a.IsGenericType && a.GetGenericTypeDefinition() == typeof(IEventHandler<>))).Where(h => h.GetInterfaces().Any(ii => ii.GetGenericArguments().Any(aa => aa == typeof(T)))).ToList();


			return handlers;
		}
	}
}