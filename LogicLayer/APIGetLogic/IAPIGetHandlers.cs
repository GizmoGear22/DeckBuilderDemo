using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace LogicLayer.APIGetLogic
{
	public interface IAPIGetHandlers
	{
		Task<IEnumerable<CardModel>> GetAllCardsByType(CardType type);
		Task<IEnumerable<CardModel>> GetAllCardsFromRepository();
	}
}