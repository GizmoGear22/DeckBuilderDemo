using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using DBAccess;
using DBAccess.DBControllers;
using Models;

namespace LogicLayer.APIGetLogic
{
	public class DBGetHandlers : IDBGetHandlers
	{
		private readonly IAvailableCardsController _availableCardsController;
		private readonly IDBCardAccess _cardAccess;
		public DBGetHandlers(IAvailableCardsController availableCardsController, IDBCardAccess cardAccess)
		{
			_availableCardsController = availableCardsController;
			_cardAccess = cardAccess;
		}

		public async Task<IEnumerable<CardModel>> GetAllCardsFromRepository()
		{
			var allCardData = await _availableCardsController.SeeAllCardOptions();
			return allCardData;
		}


		public async Task<IEnumerable<CardModel>> GetAllCardsByTypeRepository(CardType type)
		{
			var data = await _availableCardsController.SeeCardOptionsByType(type);
			return data.ToList();
		}

	}
}

