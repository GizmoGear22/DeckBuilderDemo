using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace LogicLayer.APIPostLogic
{
	public class APIPostHandler : IAPIPostHandler
	{
		private readonly IDBPostHandlers _dbPostHandlers;
		public APIPostHandler(IDBPostHandlers dbPostHandlers)
		{
			_dbPostHandlers = dbPostHandlers;
		}
		public async Task PostNewCard(CardModel model)
		{
			await _dbPostHandlers.DBPostHandler(model);
		}
	}
}
