using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PriceComponentManager.WebApi.Test.Infrastucture
{
	[TestClass]
	public abstract class TestSetup
	{
		[AssemblyInitialize]
		public static void AssemblyInit(TestContext context)
		{
		}

		[AssemblyCleanup]
		public static void AssemblyCleanup()
		{
		}
	}
}
