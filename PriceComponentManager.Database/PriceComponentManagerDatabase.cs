using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PriceComponentManager.Database.Dto;
using PriceComponentManager.Database.Enums;

namespace PriceComponentManager.Database
{
	public class PriceComponentManagerDatabase : IDatabase
	{
		public Task<int> AddEvent<T>(EventDto<T> eventDto)
		{
			var parameters = new List<SqlParameter>
				                 {
									new SqlParameter("@Id", SqlDbType.UniqueIdentifier, 16) { Value = eventDto.UniqueId },
									new SqlParameter("@Type", eventDto.Type.ToString()),
					 				new SqlParameter("EntityType", eventDto.EntityType.ToString()),
									new SqlParameter("@Data", JsonConvert.SerializeObject(eventDto.Data)),
									new SqlParameter("@StartTime", eventDto.StartTime),
									new SqlParameter("@EndTime", eventDto.EndTime ?? DateTime.UtcNow),
									new SqlParameter("@Version", eventDto.Version)
				                 };

			return DatabaseExecutor.Insert("INSERT INTO [dbo].[Event] VALUES(@Id, @Type, @EntityType, @Data, @StartTime, @EndTime, @Version)", parameters);
		}

		public Task<List<EventDto<T>>> GetEvents<T>(EntityType entityType)
		{
			var parameters = new List<SqlParameter> { new SqlParameter("EntityType", entityType.ToString()) };
			return DatabaseExecutor.Select<T>(@"SELECT [Id], [RowNr], [Type], [EntityType], [Data], [StartTime], [EndTime], [Version] FROM [dbo].[Event] WHERE EntityType = @EntityType ORDER BY RowNr", parameters);
		}

		public Task<List<EventDto<T>>> GetAllEvents<T>()
		{
			return DatabaseExecutor.Select<T>(@"SELECT [Id], [RowNr], [Type], [EntityType], [Data], [StartTime], [EndTime], [Version] FROM [dbo].[Event] ORDER BY RowNr");
		}

		public Task<int> AddQuery<TParameter, TData>(QueryDto<TParameter, TData> queryDto)
		{
			var parameters = new List<SqlParameter>
				                 {
									new SqlParameter("@Id", SqlDbType.UniqueIdentifier, 16) { Value = queryDto.UniqueId },
					 				new SqlParameter("EntityType", queryDto.EntityType.ToString()),
									new SqlParameter("Parameters", JsonConvert.SerializeObject(queryDto.Parameters)),
									new SqlParameter("Url", queryDto.Url),
									new SqlParameter("@Data", JsonConvert.SerializeObject(queryDto.Data)),
									new SqlParameter("@StartTime", queryDto.StartTime),
									new SqlParameter("@EndTime", queryDto.EndTime ?? DateTime.UtcNow),
				                 };

			return DatabaseExecutor.Insert("INSERT INTO [dbo].[Query] VALUES(@Id, @EntityType, @Parameters, @Url, @Data, @StartTime, @EndTime)", parameters);
		}
	}
}