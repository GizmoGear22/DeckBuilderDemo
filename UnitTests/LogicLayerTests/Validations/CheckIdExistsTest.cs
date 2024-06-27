using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using LogicLayer;
using LogicLayer.APIGetLogic;
using Models;
using LogicLayer.Validation;

namespace UnitTests.LogicLayerTests.Validations
{
	public class CheckIdExistsTest
	{
		[Fact]
		public async Task CheckIdTest()
		{
			CardModel tempModel = new CardModel
			{
				id = 1,
				name = "spring rifle"
			};

			//arrange
			var mock = new Mock<IAPIGetHandlers>();
			mock.Setup(x => x.GetCardById(tempModel.id)).ReturnsAsync(tempModel);

			//act
			IdValidation id = new IdValidation(mock.Object);
			var result = await id.CheckIfIdExists(tempModel);

			//assert
			Assert.False(result);
		}


	}
}
