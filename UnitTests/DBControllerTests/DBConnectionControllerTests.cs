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
			var result2 = SampleListByType();

			//Assert

			Assert.NotNull(result);
			Assert.Equal(sampleAllCards, result);

		}

		[Fact]
		public async Task SeeAllCardOptionsByTypeTest()
		{
			//Arrange
			var cardList = cardLists.SampleListByType();
			_connectionHandlerMock.Setup(db => db.DBGetConnectionHandlerByType<CardModel>("Select * from dbo.AvailableCards where type = @param", "machine")).ReturnsAsync(new List<CardModel>(cardList));

			//Act

			var result = await _availableCardsController.SeeCardOptionsByType("machine");

			//Assert

			Assert.Equal(cardList, result);

		}

		public List<CardModel> SampleList()
		{
			var output = new List<CardModel>
			{
				new CardModel
				{
					id = 1,
					name = "spring rifle",
					type = "machine",
					attack = 2,
					defense = 1
				},

				new CardModel
				{
					id = 2,
					name = "fire flask",
					type = "pyro",
					attack = 3,
					defense = 0
				},

				new CardModel
				{
					id = 3,
					name = "Gear Grinder",
					type = "machine",
					attack = 4,
					defense = 1
				}
			};
			return output;
		}

		public List<CardModel> SampleListByType()
		{
			var output = new List<CardModel>
			{
				new CardModel
				{
					id = 1,
					name = "spring rifle",
					type = "machine",
					attack = 2,
					defense = 1
				},
				new CardModel
				{
					id = 3,
					name = "Gear Grinder",
					type = "machine",
					attack = 4,
					defense = 1
				}
			};
			return output;

		}

	}
}
