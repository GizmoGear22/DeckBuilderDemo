using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Dapper;

namespace DBAccess
{
	public class ConnectionHandler : IConnectionHandler
	{

		public async Task<List<T>> DBGetConnectionHandler<T>(string sqlString, string connectionValue)
		{
			using (var connection = new SqlConnection(connectionValue))
			{
				var data = await connection.QueryAsync<T>(sqlString);
				return data.ToList();
			}
		}

		public async Task<List<T>> DBGetConnectionHandlerByType<T>(string sqlString, string connectionValue, string param)
		{
			using (var connection = new SqlConnection(connectionValue))
			{
				var parameter = new { type = param };
				var data = await connection.QueryAsync<T>(sqlString, parameter);
				return data.ToList();
			}
		}
	}
}
