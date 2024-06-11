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
using Microsoft.Extensions.Configuration;
using System.Xml.Schema;
using System.Collections;
using System.Xml.Linq;

namespace UnitTests.DBControllerTests
{
	public class DBConnectionControllerTests
	{
		private readonly IAvailableCardsController _availableCardsController;
		private readonly Mock<IDBCardAccess> _connectionHandlerMock;

		public DBConnectionControllerTests()
		{
			_connectionHandlerMock = new Mock<IDBCardAccess>();
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
			_connectionHandlerMock.Setup(db => db.DBGetConnectionHandlerByType<CardModel>("Select * from dbo.AvailableCards where type = @param", CardType.machine)).ReturnsAsync(new List<CardModel>(cardList));

			//Act

			var result = await _availableCardsController.SeeCardOptionsByType(CardType.machine);

			//Assert

			Assert.Equal(cardList, result);

		}

		[Fact]
		public async Task DBPostConnectionHandlerTest()
		{
			//Arrange
			_connectionHandlerMock.Setup(db => db.DBPostConnectionHandler)

			//Act

			//Assert
		}

	}
}
