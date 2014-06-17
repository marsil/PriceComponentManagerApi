using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Newtonsoft.Json;
using PriceComponentManager.Database.Dto;
using PriceComponentManager.Database.Enums;

namespace PriceComponentManager.Database.Common
{
	public static class DatabaseExecutor
	{
		public static List<EventDto<T>> Select<T>(string sql, List<SqlParameter> parameters = null)
		{
			using(var sqlConnection = new SqlConnection(GetConnectionString()))
			{
				sqlConnection.Open();
				using(var sqlCommand = new SqlCommand(sql, sqlConnection))
				{
					if(parameters != null)
						sqlCommand.Parameters.AddRange(parameters.ToArray());

					using(var reader = sqlCommand.ExecuteReader())
					{
						return ReadItems<T>(reader).ToList();
					}
				}
			}
		}

		//public static async Task<List<EventDto<T>>> Select<T>(string sql, List<SqlParameter> parameters = null)
		//{
		//	using (var sqlConnection = new SqlConnection(GetConnectionString()))
		//	{
		//		sqlConnection.Open();
		//		using (var sqlCommand = new SqlCommand(sql, sqlConnection))
		//		{
		//			if(parameters != null)
		//				sqlCommand.Parameters.AddRange(parameters.ToArray());

		//			using(var reader = await sqlCommand.ExecuteReaderAsync())
		//			{
		//				return ReadItems<T>(reader).ToList();
		//			}
		//		}
		//	}
		//}

		public static void Insert(string sql, List<SqlParameter> parameters)
		{
			using(var sqlConnection = new SqlConnection(GetConnectionString()))
			{
				sqlConnection.Open();
				using(var sqlCommand = new SqlCommand(sql, sqlConnection))
				{
					sqlCommand.Parameters.AddRange(parameters.ToArray());
					sqlCommand.ExecuteNonQuery();
				}
			}
		}

		//public static async Task<int> Insert(string sql, List<SqlParameter> parameters)
		//{
		//	using(var sqlConnection = new SqlConnection(GetConnectionString()))
		//	{
		//		sqlConnection.Open();
		//		using(var sqlCommand = new SqlCommand(sql, sqlConnection))
		//		{
		//			sqlCommand.Parameters.AddRange(parameters.ToArray());
		//			return await sqlCommand.ExecuteNonQueryAsync();
		//		}
		//	}
		//}

		private static List<EventDto<T>> ReadItems<T>(SqlDataReader reader)
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
		}

		//private static IEnumerable<EventDto<T>> ReadItems<T>(SqlDataReader reader)
		//{
		//	while(reader.Read())
		//	{
		//		yield return new EventDto<T>
		//		{
		//			UniqueId = (Guid)reader["Id"],
		//			RowNr = (int)reader["RowNr"],
		//			Type = EnumConverter.Convert<EventType>((string)reader["Type"]),
		//			EntityType = EnumConverter.Convert<EntityType>((string)reader["EntityType"]),
		//			Data = JsonConvert.DeserializeObject<T>((string)reader["Data"]),
		//			StartTime = (DateTime)reader["StartTime"],
		//			EndTime = (DateTime)reader["EndTime"],
		//			Version = (int)reader["Version"]
		//		};
		//	}
		//}

		private static string GetConnectionString()
		{
			return ConfigurationManager.ConnectionStrings["PriceComponentManagerConnection"].ConnectionString;
		}
	}
}
