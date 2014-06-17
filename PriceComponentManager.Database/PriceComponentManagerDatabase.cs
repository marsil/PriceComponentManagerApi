using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;
using PriceComponentManager.Database.Common;
using PriceComponentManager.Database.Dto;
using PriceComponentManager.Database.Enums;

namespace PriceComponentManager.Database
{
	public class PriceComponentManagerDatabase : IDatabase
	{
		public void AddEvent<T>(EventDto<T> eventDto)
		{
			var parameters = new List<SqlParameter>
				                 {
									new SqlParameter("@Id", SqlDbType.UniqueIdentifier, 16) { Value = eventDto.UniqueId },
									new SqlParameter("@UserId", eventDto.UserId),
									new SqlParameter("@Type", eventDto.Type.ToString()),
					 				new SqlParameter("EntityType", eventDto.EntityType.ToString()),
									new SqlParameter("@Data", JsonConvert.SerializeObject(eventDto.Data)),
									new SqlParameter("@StartTime", eventDto.StartTime),
									new SqlParameter("@EndTime", eventDto.EndTime ?? DateTime.UtcNow),
									new SqlParameter("@Version", eventDto.Version)
				                 };

			DatabaseExecutor.Insert("INSERT INTO [dbo].[Event] VALUES(@Id, @UserId, @Type, @EntityType, @Data, @StartTime, @EndTime, @Version)", parameters);
		}

		public List<EventDto<T>> GetEvents<T>(EntityType entityType)
		{
			var parameters = new List<SqlParameter> { new SqlParameter("EntityType", entityType.ToString()) };
			return DatabaseExecutor.Select<T>(@"SELECT [Id], [RowNr], [Type], [EntityType], [Data], [StartTime], [EndTime], [Version] FROM [dbo].[Event] WHERE EntityType = @EntityType ORDER BY RowNr", parameters);
		}

		public List<EventDto<T>> GetAllEvents<T>()
		{
			return DatabaseExecutor.Select<T>(@"SELECT [Id], [RowNr], [Type], [EntityType], [Data], [StartTime], [EndTime], [Version] FROM [dbo].[Event] ORDER BY RowNr");
		}

		public void AddQuery(QueryDto queryDto)
		{
			var parameters = new List<SqlParameter>
				                 {
									new SqlParameter("@Id", SqlDbType.UniqueIdentifier, 16) { Value = queryDto.UniqueId },
					 				new SqlParameter("@UserId", queryDto.UserId),
									new SqlParameter("@Url", queryDto.Url),
									new SqlParameter("@Parameters", queryDto.Parameters),
									new SqlParameter("@Data", queryDto.Data),
									new SqlParameter("@StartTime", queryDto.StartTime),
									new SqlParameter("@EndTime", queryDto.EndTime ?? DateTime.UtcNow),
				                 };

			DatabaseExecutor.Insert("INSERT INTO [dbo].[Query] VALUES(aaa @Id, @UserId, @Url, @Parameters, @Data, @StartTime, @EndTime)", parameters);
		}

		public void AddException(ExceptionDto exceptionDto)
		{
			var parameters = new List<SqlParameter>
				                 {
									new SqlParameter("@Id", SqlDbType.UniqueIdentifier, 16) { Value = exceptionDto.UniqueId },
					 				new SqlParameter("@UserId", exceptionDto.UserId),
									new SqlParameter("@Url", exceptionDto.Url),
									new SqlParameter("@Parameters", exceptionDto.Parameters),
									new SqlParameter("@Message", exceptionDto.Messsage),
									new SqlParameter("@Source", exceptionDto.Source),
									new SqlParameter("@StackTrace", exceptionDto.StackTrace),
									new SqlParameter("@Time", exceptionDto.Time),
				                 };

			DatabaseExecutor.Insert("INSERT INTO [dbo].[Exception] VALUES(@Id, @UserId, @Url, @Parameters, @Message, @Source, @StackTrace, @Time)", parameters);
		}
	}
}