using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace DBAccess.DBControllers
{
	public interface IAvailableCardsController
	{
		Task<List<CardModel>> SeeAllCardOptions();
		Task<List<CardModel>> SeeCardOptionsByType(CardType param);
		Task<int> PostNewCardsToDB(CardModel model);
	}
}