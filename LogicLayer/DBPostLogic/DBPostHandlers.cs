using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBAccess;
using DBAccess.DBControllers;
using Models;

namespace LogicLayer.APIPostLogic
{

	public class DBPostHandlers : IDBPostHandlers
	{
		private readonly IAvailableCardsController _controller;
		public DBPostHandlers(IAvailableCardsController controller)
		{
			_controller = controller;
		}

		public async Task DBPostHandler(DBCardModel model)
		{
			await _controller.PostNewCardsToDB(model);
		}
	}
}
