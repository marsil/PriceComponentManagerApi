using PriceComponentManager.Cqrs.Messaging;
using PriceComponentManager.Database;
using StructureMap;

namespace PriceComponentManager.Cqrs.Configuration
{
	public sealed class ServiceProvider
	{
		private static readonly ICommandBus CommandBusInstance;
		private static readonly IDatabase DatabaseInstance;
		private static readonly bool IsInitialized;
		private static readonly object LockThis = new object();

		static ServiceProvider()
		{
			if(!IsInitialized)
			{
				lock(LockThis)
				{
					ContainerBootstrapper.BootstrapStructureMap();
					CommandBusInstance = ObjectFactory.GetInstance<ICommandBus>();
					DatabaseInstance = ObjectFactory.GetInstance<IDatabase>();
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
	}
}
