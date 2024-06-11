using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Models;
using NPOI.SS.Formula.Functions;
using Dapper;

namespace DBAccess.DBControllers
{
	public class AvailableCardsController : IAvailableCardsController
	{
		private IDBCardAccess _connectionHandler;
		public AvailableCardsController(IDBCardAccess connectionHandler)
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

		public async Task<List<CardModel>> SeeCardOptionsByType(CardType param)
		{
			string sql = "Select * from dbo.AvailableCards where type = @param";
			var allCards = await _connectionHandler.DBGetConnectionHandlerByType<CardModel>(sql, param);
			return allCards;
		}

		public async Task<int> PostNewCardsToDB(CardModel model)
		{
			string sql = "INSERT INTO [dbo].[AvailableCards]([id],[name],[type],[cost],[attack],[defense]) Values (@id, @name, @type, @attack, @defense";
			var param = 
			new
			{
				id = model.id,
				name = model.name,
				type = model.type,
				cost = model.cost,
				attack = model.attack,
				defense = model.defense
			};
			var postCard = await _connectionHandler.DBPostConnectionHandler(sql, param);
			return postCard;
		}


	}
}
