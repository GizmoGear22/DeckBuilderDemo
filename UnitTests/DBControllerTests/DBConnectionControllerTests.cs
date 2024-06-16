using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using DBAccess.DBControllers;
using Models;
using DBAccess;
using Dapper;
using System.Xml.Schema;
using System.Collections;
using System.Xml.Linq;
using System.Reflection;
using System.Net.Quic;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;
using Castle.Core.Logging;

namespace UnitTests.DBControllerTests
{
	public class DBConnectionControllerTests
	{
		private readonly IAvailableCardsController _availableCardsController;
		private readonly Mock<IDBCardAccess> _connectionHandlerMock;
		private readonly Mock<IConfiguration> _configuration;

		public DBConnectionControllerTests()
		{
			_connectionHandlerMock = new Mock<IDBCardAccess>();
			_configuration = new Mock<IConfiguration>();
			_availableCardsController = new AvailableCardsController(_connectionHandlerMock.Object);
		}

		SampleCardLists cardLists = new SampleCardLists();

		[Fact]
		public async Task SeeAllCardOptionsTest()
		{
			var sampleAllCards = cardLists.SampleList(); 
			//Arrange

			_connectionHandlerMock.Setup(db => db.DBGetConnectionHandler<CardModel>("Select * from dbo.AvailableCards")).ReturnsAsync(new List<CardModel>(sampleAllCards));

			//Act
			var result = await _availableCardsController.SeeAllCardOptions();

			//Assert
			Assert.NotNull(result);
			Assert.Equal(sampleAllCards, result);


		}

		[Fact]
		public async Task SeeAllCardOptionsByTypeTest()
		{
			//Arrange
			var cardList = cardLists.SampleListByType();
			_connectionHandlerMock.Setup(db => db.DBGetConnectionHandlerByType<CardModel>("Select * from dbo.AvailableCards where type = @param", CardType.Machine)).ReturnsAsync(new List<CardModel>(cardList));

			//Act

			var result = await _availableCardsController.SeeCardOptionsByType(CardType.Machine);

			//Assert

			Assert.Equal(cardList, result);

		}

		[Fact]
		public async Task DBPostConnectionHandlerTest()
		{
			//Arrange
			CardModel model = new CardModel
			{
				id = 1,
				name = "spring rifle",
				type = CardType.Machine,
				attack = 2,
				defense = 1
			};

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

			//Act
			var expected = 1;
			var result = await _availableCardsController.PostNewCardsToDB(model);

			//Assert
			_connectionHandlerMock.Verify(db =>  db.DBPostConnectionHandler(It.IsAny<string>(), It.IsAny<object>()), Times.Once());
			Assert.Equal(expected, result);
		}

	}
}
