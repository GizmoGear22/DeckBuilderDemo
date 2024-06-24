using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer.DBDeleteLogic;
using Models;

namespace LogicLayer.APIDeleteLogic
{
	public class APIDeleteHandlers : IAPIDeleteHandlers
	{
		private readonly IDBDeleteHandler _deleteHandler;
		public APIDeleteHandlers(IDBDeleteHandler dbDeleteHandler)
		{
			_deleteHandler = dbDeleteHandler;
		}

		public async Task DeleteCard(CardModel model)
		{
			await _deleteHandler.DeleteCardFromRepository(model);
		}
	}
}
