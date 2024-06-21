using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Models;

namespace UnitTests.LogicLayerTests
{
	public class CardTypeParseTest
	{
		[Fact]
		public void TestCardTypeParse()
		{
			//Arrange
			var model = new
			{
				id = 1,
				name = "Test Machine",
				cost = 0,
				attack = 0,
				defense = 0,
				typeString = "Tesla"
			};

			//Act

			CardModel result = new CardModel
			{
				id = 1,
				name = "Test Machine",
				type = CardType.Tesla,
				cost = 0,
				attack = 0,
				defense = 0
			};

			var parse = Enum.TryParse(typeof(CardType), model.typeString, out var expected);
			CardModel inputModel = new CardModel();


			//Assert
			Assert.Equal(expected, result.type);
		}

	}
}
