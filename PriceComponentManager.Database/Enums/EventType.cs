namespace PriceComponentManager.Database.Enums
{
	public enum EventType
	{
		[StringValue("Created")]
		Created = 0,
		[StringValue("Updated")]
		Updated = 1,
		[StringValue("Deleted")]
		Deleted = 2
	}
}