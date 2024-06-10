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

namespace UnitTests.DBControllerTests
{
	public class DBConnectionControllerTests
	{
		private readonly IAvailableCardsController _availableCardsController;
		private readonly Mock<IConfiguration> _configurationMock;
		private readonly Mock<IConnectionHandler> _connectionHandlerMock;

		public DBConnectionControllerTests()
		{
			_configurationMock = new Mock<IConfiguration>();
			_connectionHandlerMock = new Mock<IConnectionHandler>();
			_availableCardsController = new AvailableCardsController(_configurationMock.Object, _connectionHandlerMock.Object);
		}

		[Fact]
		public async Task SeeAllCardOptionsTest()
		{
			//Arrange
			var cardList = SampleList();

			//_configurationMock.Setup(x => x.GetSection("ConnectionStrings:DefaultConnection")["YourConnectionString"]).Returns("YourConnectionString");
			_connectionHandlerMock.Setup(db => db.DBGetConnectionHandler<CardModel>(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(new List<CardModel>(cardList));

			//Act
			var result = await _availableCardsController.SeeAllCardOptions();

			//Assert

			Assert.NotNull(result);
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
					type = "concoction",
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

	}
}
