using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace DBAccess
{
	public interface IConnectionHandler
	{
		Task<List<T>> DBGetConnectionHandler<T>(string sqlString);
		Task<List<T>> DBGetConnectionHandlerByType<T>(string sqlString, string param);
	}
}