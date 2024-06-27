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
			var checkifExists = await _idValidation.CheckIfIdExists(model);
			var checkId = await _idValidation.CheckId(model);
			var checkName = await _checkIfNameExists.CheckName(model);
			var checkNameCharacters = await _checkIfNameExists.CheckNameCharacters(model);


			if (checkifExists && checkId && checkName && checkNameCharacters)
			{
				await _dbPostHandlers.DBPostHandler(model);
			}
		}
	}
}
