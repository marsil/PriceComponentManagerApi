using KellermanSoftware.CompareNetObjects;

namespace PriceComponentManager.Api.Test
{
	public static class ObjectExtension
	{
		public static ComparisonResult Compare(this object obj, object obj2)
		{
			var c = new CompareLogic();
			return c.Compare(obj, obj2);
		}
	}
}
