using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DelegateUtilities;
using LogicLayer.APIGetLogic;
using Models;

namespace LogicLayer.Validation.CheckName
{
	public class CheckIfNameExists
	{
		private readonly IDBGetHandlers _dBGetHandlers;
		public CheckIfNameExists(IDBGetHandlers dbGetHandlers)
		{
			_dBGetHandlers = dbGetHandlers;
		}

		ValidationDelegates.ValidationMessageDelegate validationMessage = DelegateValidationMessage.ValidationMessage;
		public async Task <bool> CheckName(CardModel model)
		{
			var cards = await _dBGetHandlers.GetAllCardsFromRepository();
			foreach (var card in cards) 
			{
				if (model.name == card.name)
				{
					string message = "Please choose a different name";
					validationMessage(message);
					return false;
				}
				else
				{ return true; }
			}

		}
	}
}
