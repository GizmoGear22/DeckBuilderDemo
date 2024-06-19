using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace LogicLayer.APIGetLogic
{
	public interface IAPIGetHandlers
	{
		Task<List<CardModel>> GetAllCards();
	}
}