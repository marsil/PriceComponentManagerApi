using PriceComponentManager.Api.Messaging;
using PriceComponentManager.Database;

using StructureMap;

namespace PriceComponentManager.Api.Configuration
{
	public sealed class ServiceLocator
	{
		private static readonly ICommandBus CommandBusInstance;
		private static readonly IDatabase Database;
		private static readonly bool IsInitialized;
		private static readonly object LockThis = new object();

		static ServiceLocator()
		{
			if(!IsInitialized)
			{
				lock(LockThis)
				{
					ContainerBootstrapper.BootstrapStructureMap();
					CommandBusInstance = ObjectFactory.GetInstance<ICommandBus>();
					Database = ObjectFactory.GetInstance<IDatabase>();
					IsInitialized = true;
				}
			}
		}

		public static ICommandBus CommandBus
		{
			get { return CommandBusInstance; }
		}

		public static IDatabase ReportDatabase
		{
			get { return Database; }
		}
	}
}
