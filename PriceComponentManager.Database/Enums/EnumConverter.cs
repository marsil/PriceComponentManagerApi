using System;

namespace PriceComponentManager.Database.Enums
{
	public static class EnumConverter
	{
		public static T Convert<T>(string value)
		{
			return (T)Enum.Parse(typeof(T), value);
		}
	}
}
