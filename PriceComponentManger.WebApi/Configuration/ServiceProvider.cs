using System;
using System.Collections.Generic;
using System.Linq;
using PriceComponentManager.Database;
using PriceComponentManager.Database.Dto;
using PriceComponentManger.WebApi.Messaging;
using PriceComponentManger.WebApi.Storage;
using StructureMap;

namespace PriceComponentManger.WebApi.Configuration
{
	public sealed class ServiceProvider
	{
		private static readonly ICommandBus CommandBusInstance;
		private static readonly IDatabase DatabaseInstance;
		private static readonly bool IsInitialized;
		private static readonly object LockThis = new object();
		//private static readonly IDataRepository<T> DataRepositoryInstance;

		static ServiceProvider()
		{
			if(!IsInitialized)
			{
				lock(LockThis)
				{
					ContainerBootstrapper.BootstrapStructureMap();
					CommandBusInstance = ObjectFactory.GetInstance<ICommandBus>();
					DatabaseInstance = ObjectFactory.GetInstance<IDatabase>();
					//DataRepositoryInstance = ObjectFactory.GetInstance<IDataRepository<T>>();
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


		public static IEventRepository<T> GetEventRepository<T>()
		{
			return ObjectFactory.GetInstance<IEventRepository<T>>();
		}

		public static IDataRepository<T> GetDataRepository<T>() where T : IHaveUniqueId
		{
			return ObjectFactory.GetInstance<IDataRepository<T>>();
		}
	}
}