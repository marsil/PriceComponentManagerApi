using System.Collections.Generic;
using KellermanSoftware.CompareNetObjects;

namespace PriceComponentManager.WebApi.Test.Extension
{
	public static class ObjectExtension
	{
		public static ComparisonResult Compare(this object obj, object obj2, List<string> membersToIgnore = null)
		{
			var compareLogic = new CompareLogic();

			if(membersToIgnore != null)
			{
				compareLogic = new CompareLogic { Config = { MembersToIgnore = membersToIgnore } };
			}
			
			return compareLogic.Compare(obj, obj2);
		}
	}
}
