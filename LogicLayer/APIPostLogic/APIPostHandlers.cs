using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBAccess.DBControllers;
using LogicLayer.ModelConversions;
using Models;

namespace LogicLayer.APIPostLogic
{
	public class APIPostHandlers
	{
		private readonly IDBPostHandlers _handler;
		public APIPostHandlers(IDBPostHandlers handler)
		{
			_handler = handler;
		}
		public async Task<DBCardModel> APIAddNewCard(FrontEndModel model)
		{
			var DBList = FrontEndModelToDBModel.ConvertFrontEndModelToCardModel(model);
			await _handler.DBPostHandler(DBList);
			return DBList;
		}
	}
}
