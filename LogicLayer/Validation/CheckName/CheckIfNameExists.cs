﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
		public async Task<(bool, string)> CheckName(CardModel model)
		{
			var cards = await _dBGetHandlers.GetAllCardsFromRepository();
			foreach (var card in cards)
			{
				if (!Regex.IsMatch(card.name, model.name))
				{
					continue;
				}
				else
				{
					string message = "Model name already exists.";
					await validationMessage(message);
					return (false, message);
				}
			}
			return (true, null);	

		}

		public async Task<(bool, string)> CheckNameCharacters(CardModel model)
		{
			if (RegexDefinitions.CheckNameCharacters(model.name))
			{ return (true, null); }
			else 
			{
				string message = "Please choose a different name";
				await validationMessage(message);
				return (false, message); }
		}
	}
}
