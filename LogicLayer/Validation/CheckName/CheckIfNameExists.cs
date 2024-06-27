using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DelegateUtilities;
using LogicLayer.APIGetLogic;
using Models;

namespace LogicLayer.Validation.CheckName
{
	public class CheckIfNameExists : ICheckIfNameExists
	{
		private readonly IDBGetHandlers _dBGetHandlers;
		public CheckIfNameExists(IDBGetHandlers dbGetHandlers)
		{
			_dBGetHandlers = dbGetHandlers;
		}

		ValidationDelegates.ValidationMessageDelegate validationMessage = DelegateValidationMessage.ValidationMessage;
		public async Task<bool> CheckName(CardModel model)
		{
			var cards = await _dBGetHandlers.GetAllCardsFromRepository();
			foreach (var card in cards)
			{
				if (!Regex.IsMatch(card.name, model.name))
				{
					string message = "Please choose a different name";
					validationMessage(message);
					return false;
				}
			}
			return true;

		}

		public bool CheckNameCharacters(CardModel model)
		{
			if (RegexDefinitions.CheckNameCharacters(model.name))
			{ return true; }
			else 
			{
				string message = "Please choose a different name";
				validationMessage(message);
				return false; }
		}
	}
}
