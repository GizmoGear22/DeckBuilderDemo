using Xunit;
using Moq;
using DBAccess;
using Models;
using System.Runtime.CompilerServices;
using System.Diagnostics;

namespace UnitTests
{
	public class GetAvailableCardsTest
	{

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

			var id1 = actualList[0].id;
			var id2 = expected[0].id;

			var name1 = actualList[0].name;
			var name2 = expected[0].name;

			var type1 = actualList[0].type;
			var type2 = expected[0].type;

			var cost1 = actualList[0].cost;
			var cost2 = expected[0].cost;
			
			var attack1 = actualList[0].attack;
			var attack2 = expected[0].attack;

			var defense1 = actualList[0].defense;
			var defense2 = expected[0].defense;


			//Assert
			Assert.Equal(id1, id2);
			Assert.Equal(name1, name2);
			Assert.Equal(type1, type2);
			Assert.Equal(cost1, cost2);
			Assert.Equal(attack1, attack2);
			Assert.Equal(defense1, defense2);
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
				}
			};
			return output;
		}
	}
}