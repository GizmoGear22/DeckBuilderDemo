using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Models;
using NPOI.SS.Formula.Functions;

namespace DBAccess.DBControllers
{
	public class AvailableCardsController : IAvailableCardsController
	{
		private IConnectionHandler _connectionHandler;
		public AvailableCardsController(IConnectionHandler connectionHandler)
		{
			_connectionHandler = connectionHandler;
		}




		public async Task<List<CardModel>> SeeAllCardOptions()
		{
			//string connectionString = CnnVal();
			string sql = "Select * from dbo.AvailableCards";
			var allCards = await _connectionHandler.DBGetConnectionHandler<CardModel>(sql);
			return allCards;
		}

		public async Task<List<CardModel>> SeeCardOptionsByType(string param)
		{
			string sql = "Select * from dbo.AvailableCards where type = @param";
			var allCards = await _connectionHandler.DBGetConnectionHandlerByType<CardModel>(sql, param);
			return allCards;
		}


	}
}
