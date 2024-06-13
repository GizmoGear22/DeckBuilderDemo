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

	public class APIPostHandlers : IAPIPostHandlers
	{
		private readonly IAvailableCardsController _controller;
		public APIPostHandlers(IAvailableCardsController controller)
		{
			_controller = controller;
		}

		public async Task APIPostHandler(CardModel model)
		{
			await _controller.PostNewCardsToDB(model);
		}
	}
}
