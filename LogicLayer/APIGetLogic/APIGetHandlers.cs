using System;
using System.Collections.Generic;
using System.Linq;
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
		public APIGetHandlers(IAvailableCardsController availableCardsController)
		{
			_availableCardsController = availableCardsController;
		}
		public async Task<IEnumerable<CardModel>> GetAllCards()
		{
			var data = await _availableCardsController.SeeAllCardOptions();
			return data.ToList();
		}

		public async Task<IEnumerable<CardModel>> GetAllCardsByType(CardType type)
		{
			var data = await _availableCardsController.SeeCardOptionsByType(type);
			return data.ToList();
		}
	}
}
