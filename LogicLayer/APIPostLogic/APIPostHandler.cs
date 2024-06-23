using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using LogicLayer.Validation;
using DelegateUtilities;

namespace LogicLayer.APIPostLogic
{
	public class APIPostHandler : IAPIPostHandler
	{
		private readonly IDBPostHandlers _dbPostHandlers;
		private readonly IIdValidation _idValidation;
		public APIPostHandler(IDBPostHandlers dbPostHandlers, IIdValidation idValidation)
		{
			_dbPostHandlers = dbPostHandlers;
			_idValidation = idValidation;
		}

		public async Task PostNewCard(CardModel model)
		{
			var checkifExists = _idValidation.CheckIfIdExists(model);
			var checkId = _idValidation.CheckId(model);

			if (await checkifExists && checkId)
			{
				await _dbPostHandlers.DBPostHandler(model);
			}
		}
	}
}
