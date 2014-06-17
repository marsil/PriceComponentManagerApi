using PriceComponentManager.Database;
using PriceComponentManager.Database.Dto;

using PriceComponentManger.WebApi.Messaging;
using PriceComponentManger.WebApi.Storage;
using StructureMap;

namespace PriceComponentManger.WebApi.Configuration
{
	public sealed class ServiceProvider<T>
		where T : IHaveUniqueId
	{
		private static readonly ICommandBus CommandBusInstance;
		private static readonly IDatabase DatabaseInstance;
		private static readonly bool IsInitialized;
		private static readonly object LockThis = new object();
		private static readonly IEventRepository<T> EventRepositoryInstance;
		private static readonly IDataRepository<T> DataRepositoryInstance;

		static ServiceProvider()
		{
			if(!IsInitialized)
			{
				lock(LockThis)
				{
					ContainerBootstrapper.BootstrapStructureMap();
					CommandBusInstance = ObjectFactory.GetInstance<ICommandBus>();
					DatabaseInstance = ObjectFactory.GetInstance<IDatabase>();
					EventRepositoryInstance = ObjectFactory.GetInstance<IEventRepository<T>>();
					DataRepositoryInstance = ObjectFactory.GetInstance<IDataRepository<T>>();
					//EventRepository.LoadAllEvents();
					IsInitialized = true;
				}
			}
		}

		public static ICommandBus CommandBus
		{
			get { return CommandBusInstance; }
		}

		public static IDatabase Database
		{
			get { return DatabaseInstance; }
		}

		public static IEventRepository<T> EventRepository
		{
			get { return EventRepositoryInstance; }
		}

		public static IDataRepository<T> DataRepository
		{
			get { return DataRepositoryInstance; }
		}
	}
}