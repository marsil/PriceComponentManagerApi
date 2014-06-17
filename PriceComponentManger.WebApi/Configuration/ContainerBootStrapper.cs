using PriceComponentManager.Database;
using PriceComponentManger.WebApi.Messaging;
using PriceComponentManger.WebApi.Storage;
using StructureMap;

namespace PriceComponentManger.WebApi.Configuration
{
	public static class ContainerBootstrapper
	{
		public static void BootstrapStructureMap()
		{
			ObjectFactory.Initialize(x =>
			{
				x.For(typeof(IEventRepository<>)).Singleton().Use(typeof(EventRepository<>));
				x.For(typeof(IDataRepository<>)).Singleton().Use(typeof(DataRepository<>));
				x.For<ICommandBus>().Use<CommandBus>();
				x.For<IDatabase>().Use<PriceComponentManagerDatabase>();
			});
		}
	}
}