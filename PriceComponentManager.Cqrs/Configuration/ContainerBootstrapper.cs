using PriceComponentManager.Cqrs.Messaging;
using PriceComponentManager.Cqrs.Storage;
using PriceComponentManager.Cqrs.Utils;
using PriceComponentManager.Database;
using StructureMap;

namespace PriceComponentManager.Cqrs.Configuration
{
	public static class ContainerBootstrapper
	{
		public static void BootstrapStructureMap()
		{
			ObjectFactory.Initialize(x =>
				{
					x.For(typeof(IRepository<>)).Singleton().Use(typeof(Repository<>));
					x.For<IEventStorage>().Singleton().Use<DatabaseEventStorage>();
					x.For<ICommandHandlerFactory>().Use<StructureMapCommandHandlerFactory>();
					x.For<IEventHandlerFactory>().Use<StructureMapEventHandlerFactory>();
					x.For<ICommandBus>().Use<CommandBus>();
					x.For<IEventBus>().Use<EventBus>();
					x.For<IDatabase>().Use<PriceComponentManagerDatabase>();
				});
		}
	}
}