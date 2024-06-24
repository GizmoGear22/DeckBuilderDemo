using System.Threading.Tasks;
using Models;

namespace LogicLayer.DBDeleteLogic
{
	public interface IDBDeleteHandler
	{
		Task DeleteCardFromRepository(CardModel card);
	}
}