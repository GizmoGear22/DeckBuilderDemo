using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer.Utility;
using Xunit;
using Models;

namespace UnitTests.LogicLayerTests
{
	public class CardTypeConversionTest
	{
		[Fact]
		public void IntToTypeConversionTest()
		{
			//Arrange
			var testModel = new CardModel
			{
				id = 1,
				name = "spring rifle",
				type = CardType.Machine,
				attack = 2,
				defense = 1
			};

			//Act
			var result = TypeConversions.IntToTypeConversion(testModel.type);
			var expected = new CardModel();
		}
	}
}
