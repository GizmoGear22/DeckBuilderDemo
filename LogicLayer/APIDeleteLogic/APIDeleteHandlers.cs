﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer.APIPostLogic;
using LogicLayer.DBDeleteLogic;
using LogicLayer.Validation.CheckName;
using LogicLayer.Validation;
using Models;

namespace LogicLayer.APIDeleteLogic
{
	public class APIDeleteHandlers : IAPIDeleteHandlers
	{
		private readonly IDBDeleteHandler _deleteHandler;
		private readonly IIdValidation _idValidation;
		private readonly ICheckIfNameExists _checkIfNameExists;
		public APIDeleteHandlers(IDBDeleteHandler dbDeleteHandler, IIdValidation idValidation, ICheckIfNameExists checkIfNameExists)
		{
			_deleteHandler = dbDeleteHandler;
			_idValidation = idValidation;
			_checkIfNameExists = checkIfNameExists;
		}

		public async Task DeleteCard(CardModel model)
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
				await _deleteHandler.DeleteCardFromRepository(model);
			}

		}
	}
}
