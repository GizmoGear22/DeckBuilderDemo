using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer.ModelConversions;
using Models;

namespace LogicLayer.APIGetLogic
{
	public class APIGetHandlers : IAPIGetHandlers
	{
		private readonly IDBGetHandlers _dbGetHandlers;
		public APIGetHandlers(IDBGetHandlers dbGetHandlers)
		{
			_dbGetHandlers = dbGetHandlers;
		}
		public async Task<List<CardModel>> GetAllCards()
		{
			var dataList = await _dbGetHandlers.GetAllCardsFromRepository();
			return dataList.ToList();
		}

		public async Task<List<CardModel>> GetAllCardsByType(CardType type)
		{
			var dataList = await _dbGetHandlers.GetAllCardsByTypeRepository(type);	
			return dataList.ToList();
		}

		public async Task<CardModel> GetCardById(int id)
		{
			var data = await _dbGetHandlers.GetCardByIdFromRepository(id);
			//Fake model for validation purposes. Because of CardModel, the other handlers would not accept a null return
			if (data == null)
			{
				data = new CardModel
				{
					id = 0,
					name = ""
				};
				return data;
			} else
			{
				return data;
			}

		}
	}
}
