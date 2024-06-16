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
	public class APIGetHandlers : IAPIGetHandlers
	{
		private readonly IAvailableCardsController _availableCardsController;
		private readonly IDBCardAccess _cardAccess;
		public APIGetHandlers(IAvailableCardsController availableCardsController, IDBCardAccess cardAccess)
		{
			_availableCardsController = availableCardsController;
			_cardAccess = cardAccess;
		}

		public async Task<IEnumerable<CardModel>> GetAllCardsFromRepository()
		{
			var allCardData = await _availableCardsController.SeeAllCardOptions();
			return allCardData;
		}


		public async Task<IEnumerable<CardModel>> GetAllCardsByType(CardType type)
		{
			var data = await _availableCardsController.SeeCardOptionsByType(type);
			return data.ToList();
		}

	}
}

