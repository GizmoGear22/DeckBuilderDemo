using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace LogicLayer.APIGetLogic
{
	public interface IDBGetHandlers
	{
		Task<IEnumerable<DBCardModel>> GetAllCardsByTypeRepository(CardType type);
		Task<IEnumerable<DBCardModel>> GetAllCardsFromRepository();
	}
}