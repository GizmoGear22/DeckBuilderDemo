using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DelegateUtilities;
using LogicLayer.APIGetLogic;
using Models;

namespace LogicLayer.Validation
{
	public class IdValidation : IIdValidation
	{
		private readonly IAPIGetHandlers _handlers;
		public IdValidation(IAPIGetHandlers handlers)
		{
			_handlers = handlers;
		}
		ValidationDelegates.ValidationMessageDelegate validationMessage = DelegateValidationMessage.ValidationMessage;
		public bool CheckId(CardModel model)
		{

			if (model.id < 0)
			{
				string message = "Can't have ID Number less than or equal to 0";
				validationMessage(message);
				return false;
			}
			else
			{
				return true;
			}
		}

		public bool CheckIfIdExists(CardModel model)
		{
			if (_handlers.GetCardById(model.id) != null)
			{
				string message = "ID already exists";
				validationMessage(message);
				return false;
			}
			else
			{
				return true;
			}
		}


	}
}
