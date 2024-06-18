using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer.ModelConversions;
using Models;
using Moq;
using Xunit;

namespace UnitTests.LogicLayerTests
{
	public class ModelConversionTests
	{
		[Fact]
		public void DBModeltoFrontModelTest()
		{
			//arrange
			var input = new DBCardModel
			{
				id = 1,
				name = "spring rifle",
				type = CardType.Machine,
				attack = 2,
				defense = 1
			};

			//act
			var expected = new FrontEndModel
			{
				id = 1,
				name = "spring rifle",
				type = "Machine",
				attack = 2,
				defense = 1
			};

			var result = DBModelToFrontModel.ConvertDBModeltoFrontEndModel(input);
			//assert
			Assert.Equal(expected.id, result.id);
			Assert.Equal(expected.name, result.name);
			Assert.Equal(expected.type, result.type);
			Assert.Equal(expected.cost, result.cost);
			Assert.Equal(expected.attack, result.attack);
			Assert.Equal(expected.defense, result.defense);
		}

		[Fact]
		public void FrontEndModelToDBModelTest()
		{
			//arrange
			var input = new DBCardModel();
			{

			}
		}
	}
}
