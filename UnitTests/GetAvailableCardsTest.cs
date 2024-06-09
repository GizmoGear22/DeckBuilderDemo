using Xunit;
using Moq;
using DBAccess;
using Models;
using System.Runtime.CompilerServices;

namespace UnitTests
{
	public class GetAvailableCardsTest
	{
		private IConnectionHandler _connectionHandler;
		GetAvailableCardsTest(IConnectionHandler connectionHandler)
		{
			_connectionHandler = connectionHandler;
		}
		[Fact]
		public async Task TestGetAvailableCards()
		{
			//Arrange
			var mock = new Mock<IConnectionHandler>();
			string sql = "Select * from dbo.AvailableCards";
			mock.Setup(db => db.DBGetConnectionHandler<CardModel>(sql, "ConnectionValue")).ReturnsAsync(new List<CardModel>(SampleList()));

			//Act
			var actualList = await mock.Object.DBGetConnectionHandler<CardModel>(sql, "ConnectionValue");
			var expected = SampleList();


			//Assert

			Assert.Equal(actualList, expected);
		}

		private List<CardModel> SampleList()
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
				}
			};
			return output;
		}
	}
}