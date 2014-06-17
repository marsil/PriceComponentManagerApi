using System;
using PriceComponentManager.Database.Dto;
using PriceComponentManager.Database.Enums;

namespace PriceComponentManger.WebApi.Common
{
	public static class QueryDtoCreator
	{
		public static QueryDto<TParameter, TData> Create<TParameter, TData>(EntityType entityType, TParameter paramers, string url, TData data)
		{
			return new QueryDto<TParameter, TData>
				       {
					       UniqueId = new Guid(),
					       EntityType = entityType,
					       Parameters = paramers,
					       Url = url,
					       Data = data,
					       StartTime = DateTime.UtcNow
				       };
		}
	}
}