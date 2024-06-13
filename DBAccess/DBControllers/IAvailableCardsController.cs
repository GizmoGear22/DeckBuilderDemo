using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace DBAccess.DBControllers
{
	public interface IAvailableCardsController
	{
		Task<int> PostNewCardsToDB(CardModel model);
		Task<List<CardModel>> SeeAllCardOptions();
		Task<List<CardModel>> SeeCardOptionsByType(CardType param);
	}
}