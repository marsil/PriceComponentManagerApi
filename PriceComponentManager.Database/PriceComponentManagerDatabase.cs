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
			var sql = "INSERT INTO [dbo].[Event] VALUES(@Id, @UserId, @Type, @EntityType, @Data, @StartTime, @EndTime, @Version)";
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
			DatabaseExecutor.Insert(sql, parameters);
		}

		public List<EventDto<T>> GetEvents<T>(EntityType entityType)
		{
			var sql = @"SELECT [Id], [RowNr], [Type], [EntityType], [Data], [StartTime], [EndTime], [Version] FROM [dbo].[Event] WHERE EntityType = @EntityType ORDER BY RowNr";
			var parameters = new List<SqlParameter> { new SqlParameter("EntityType", entityType.ToString()) };
			return DatabaseExecutor.Select(
				sql,
				reader =>
					{
						var eventDtos = new List<EventDto<T>>();
						while(reader.Read())
						{
							eventDtos.Add(new EventDto<T>
							{
								UniqueId = (Guid)reader["Id"],
								RowNr = (int)reader["RowNr"],
								Type = EnumConverter.Convert<EventType>((string)reader["Type"]),
								EntityType = EnumConverter.Convert<EntityType>((string)reader["EntityType"]),
								Data = JsonConvert.DeserializeObject<T>((string)reader["Data"]),
								StartTime = (DateTime)reader["StartTime"],
								EndTime = (DateTime)reader["EndTime"],
								Version = (int)reader["Version"]
							});
						}

						return eventDtos;
					},
					parameters);
		}

		public List<EventDto<T>> GetEvents<T>()
		{
			var sql = @"SELECT [Id], [RowNr], [Type], [EntityType], [Data], [StartTime], [EndTime], [Version] FROM [dbo].[Event] ORDER BY RowNr";
			return DatabaseExecutor.Select(
				sql,
				reader =>
					{
						var eventDtos = new List<EventDto<T>>();
						while(reader.Read())
						{
							eventDtos.Add(new EventDto<T>
							{
								UniqueId = (Guid)reader["Id"],
								RowNr = (int)reader["RowNr"],
								Type = EnumConverter.Convert<EventType>((string)reader["Type"]),
								EntityType = EnumConverter.Convert<EntityType>((string)reader["EntityType"]),
								Data = JsonConvert.DeserializeObject<T>((string)reader["Data"]),
								StartTime = (DateTime)reader["StartTime"],
								EndTime = (DateTime)reader["EndTime"],
								Version = (int)reader["Version"]
							});
						}

						return eventDtos;
					});
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

		public List<QueryDto> GetQueries()
		{
			var sql = @"SELECT [Id] ,[RowNr], [UserId], [Url], [Parameters], [Data], [StartTime], [EndTime] FROM [dbo].[Query] ORDER BY [RowNr]";
			return DatabaseExecutor.Select(
				sql,
				reader =>
					{
						var queryDtos = new List<QueryDto>();
						while(reader.Read())
						{
							queryDtos.Add(new QueryDto
							{
								UniqueId = (Guid)reader["Id"],
								RowNr = (int)reader["RowNr"],
								UserId = (string)reader["UserId"],
								Url = (string)reader["Url"],
								Parameters = (string)reader["Parameters"],
								Data = (string)reader["Data"],
								StartTime = (DateTime)reader["StartTime"],
								EndTime = (DateTime)reader["EndTime"]
							});
						}

						return queryDtos;
					});
		}

		public void AddException(ExceptionDto exceptionDto)
		{
			var sql = "INSERT INTO [dbo].[Exception] VALUES(@Id, @UserId, @Url, @Parameters, @Message, @Source, @StackTrace, @Time)";
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
			DatabaseExecutor.Insert(sql, parameters);
		}

		public List<ExceptionDto> GetExceptions()
		{
			var sql = "@SELECT [Id], [UserId], [Url], [Parameters], [Message], [Source], [StackTrace], [Time] FROM [dbo].[Exception]";
			return DatabaseExecutor.Select(
				sql,
				reader =>
				{
					var exceptionDtos = new List<ExceptionDto>();
					while(reader.Read())
					{
						exceptionDtos.Add(new ExceptionDto
						{
							UniqueId = (Guid)reader["Id"],
							UserId = (string)reader["UserId"],
							Url = (string)reader["Url"],
							Parameters = (string)reader["Parameters"],
							Messsage = (string)reader["Message"],
							Source = (string)reader["Source"],
							StackTrace = (string)reader["StackTrace"],
							Time = (DateTime)reader["Time"]
						});
					}

					return exceptionDtos;
				});
		}
	}
}