using System.Collections.Generic;
using System.Threading.Tasks;

namespace DBAccess
{
	public interface IConnectionHandler
	{
		Task<List<T>> DBGetConnectionHandler<T>(string sqlString, string connectionValue);
		Task<List<T>> DBGetConnectionHandlerByType<T>(string sqlString, string connectionValue, string param);
	}
}