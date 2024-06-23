using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Models;
using LogicLayer.Validation;
using Moq;
using LogicLayer.APIGetLogic;

namespace UnitTests.LogicLayerTests.Validations
{
	public class IDValidationsTests
	{
		[Theory]
		[InlineData(1, "Machine Rifle")]
		[InlineData(2, "Oil Flask")]
		public void CheckIDTest(int id, string name)
		{
			//arrange
			CardModel card = new CardModel
			{
				id = id,
				name = name,
			};
			var mock = new Mock<IAPIGetHandlers>();
			mock.Setup(x => x.Equals(card)).Returns(true);

			IdValidation validate = new IdValidation(mock.Object);
			
			//act
			var result = validate.CheckId(card);

			//assert
			Assert.True(result);
		}

		[Theory]
		[InlineData(-1, "Obelisk")]
		public void CheckIDFalseTest(int id, string name)
		{
			CardModel card = new CardModel
			{
				id = id,
				name = name,
			};
			var mock = new Mock<IAPIGetHandlers>();
			mock.Setup(x => x.Equals(card)).Returns(true);

			IdValidation validate = new IdValidation(mock.Object);

			//act

			//assert
			Assert.Throws<Exception>(() => validate.CheckId(card));
		}
	}
}
