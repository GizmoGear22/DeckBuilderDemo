using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using LogicLayer.Validation;
using DelegateUtilities;
using LogicLayer.Validation.CheckName;

namespace LogicLayer.APIPostLogic
{
	public class APIPostHandler : IAPIPostHandler
	{
		private readonly IDBPostHandlers _dbPostHandlers;
		private readonly IIdValidation _idValidation;
		private readonly ICheckIfNameExists _checkIfNameExists;
		public APIPostHandler(IDBPostHandlers dbPostHandlers, IIdValidation idValidation, ICheckIfNameExists checkIfNameExists)
		{
			_dbPostHandlers = dbPostHandlers;
			_idValidation = idValidation;
			_checkIfNameExists = checkIfNameExists;
		}

		public async Task PostNewCard(CardModel model)
		{
			(bool, string)[] checker =
			{
				await _idValidation.CheckIfIdExists(model),
				await _idValidation.CheckId(model),
				await _checkIfNameExists.CheckName(model),
				await _checkIfNameExists.CheckNameCharacters(model)
			};

			if (checker.All(c => c.Item1))
			{
				await _dbPostHandlers.DBPostHandler(model);
			}
		}
	}
}
