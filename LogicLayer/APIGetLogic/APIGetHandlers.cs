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
		public async Task<List<FrontEndModel>> GetAllCards()
		{
			var DBList = await _dbGetHandlers.GetAllCardsFromRepository();
			List<FrontEndModel> newList = new List<FrontEndModel>();
			foreach (var item in DBList)
			{
				newList.Add(DBModelToFrontModel.ConvertDBModeltoFrontEndModel(item));
			}
			return newList;

		}
	}
}
