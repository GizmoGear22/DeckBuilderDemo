using System.Collections.Generic;
using System.Threading.Tasks;

namespace DBAccess
{
	public interface IDBCardAccess
	{
		string CnnVal();
		Task<List<T>> DBGetConnectionHandler<T>(string sqlString);
		Task<List<T>> DBGetConnectionHandlerByType<T>(string sqlString, string param);
	}
}