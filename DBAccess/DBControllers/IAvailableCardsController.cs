using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace DBAccess.DBControllers
{
	public interface IAvailableCardsController
	{
		Task<int> PostNewCardsToDB(DBCardModel model);
		Task<List<DBCardModel>> SeeAllCardOptions();
		Task<List<DBCardModel>> SeeCardOptionsByType(CardType param);
	}
}