using PriceComponentManager.Api.Database;
using PriceComponentManager.Api.Messaging;
using PriceComponentManager.Api.Storage;
using PriceComponentManager.Api.Utils;
using StructureMap;

namespace PriceComponentManager.Api.Configuration
{
	public static class ContainerBootstrapper
	{
		public static void BootstrapStructureMap()
		{

			ObjectFactory.Initialize(x =>
				{
					x.For(typeof(IRepository<>)).Singleton().Use(typeof(Repository<>));
					x.For<IEventStorage>().Singleton().Use<InMemoryEventStorage>();
					x.For<IEventBus>().Use<EventBus>();
					x.For<ICommandHandlerFactory>().Use<StructureMapCommandHandlerFactory>();
					x.For<IEventHandlerFactory>().Use<StructureMapEventHandlerFactory>();
					x.For<ICommandBus>().Use<CommandBus>();
					x.For<IEventBus>().Use<EventBus>();
					x.For<IDatabase>().Use<PriceComponentManagerDatabase>();
				});
		}
	}
}