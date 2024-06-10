using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace DBAccess.DBControllers
{
	public interface IAvailableCardsController
	{
		string CnnVal();
		Task<List<CardModel>> SeeAllCardOptions();
		Task<List<CardModel>> SeeCardOptionsByType(string param);
	}
}