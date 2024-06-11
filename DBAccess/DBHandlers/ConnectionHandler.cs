using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Dapper;
using Models;

namespace DBAccess
{
	public class ConnectionHandler : IConnectionHandler
	{
		private readonly IConfiguration _configuration;
		ConnectionHandler(IConfiguration configuration)
		{
			_configuration = configuration;
		}
		public string CnnVal()
		{
			return _configuration.GetConnectionString("DBAccessHandler");
		}

		public async Task<List<T>> DBGetConnectionHandler<T>(string sqlString)
		{
			using (var connection = new SqlConnection(CnnVal()))
			{
				var data = await connection.QueryAsync<T>(sqlString);
				return data.ToList();
			}
		}

		public async Task<List<T>> DBGetConnectionHandlerByType<T>(string sqlString, string param)
		{
			using (var connection = new SqlConnection(CnnVal()))
			{
				var parameter = new { type = param };
				var data = await connection.QueryAsync<T>(sqlString, parameter);
				return data.ToList();
			}
		}
	}
}
