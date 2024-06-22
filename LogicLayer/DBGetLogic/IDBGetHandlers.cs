using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace LogicLayer.APIGetLogic
{
	public interface IDBGetHandlers
	{
		Task<IEnumerable<CardModel>> GetAllCardsByTypeRepository(CardType type);
		Task<IEnumerable<CardModel>> GetAllCardsFromRepository();
		Task<CardModel> GetCardByIdFromRepository(int id);
	}
}