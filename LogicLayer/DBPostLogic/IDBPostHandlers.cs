using System.Threading.Tasks;
using Models;

namespace LogicLayer.APIPostLogic
{
	public interface IDBPostHandlers
	{
		Task DBPostHandler(CardModel model);
	}
}