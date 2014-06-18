using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace PriceComponentManager.Database.Common
{
	public static class DatabaseExecutor
	{
		public static List<T> Select<T>(string sql, Func<SqlDataReader, List<T>> readerFunc, List<SqlParameter> parameters = null)
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
						return readerFunc.Invoke(reader);
					}
				}
			}
		}

		//public static List<EventDto<T>> Select<T>(string sql, List<SqlParameter> parameters = null)
		//{
		//	using(var sqlConnection = new SqlConnection(GetConnectionString()))
		//	{
		//		sqlConnection.Open();
		//		using(var sqlCommand = new SqlCommand(sql, sqlConnection))
		//		{
		//			if(parameters != null)
		//				sqlCommand.Parameters.AddRange(parameters.ToArray());

		//			using(var reader = sqlCommand.ExecuteReader())
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

		private static string GetConnectionString()
		{
			return ConfigurationManager.ConnectionStrings["PriceComponentManagerConnection"].ConnectionString;
		}
	}
}
