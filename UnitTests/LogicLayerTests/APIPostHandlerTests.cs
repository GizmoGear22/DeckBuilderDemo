using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Xunit;
using Models;
using LogicLayer.APIPostLogic;
using System.Security.Cryptography.X509Certificates;
using LogicLayer.Validation;

namespace UnitTests.LogicLayerTests
{
	public class APIPostHandlerTests
	{
		private readonly Mock<IDBPostHandlers> _postHandlers;
		private readonly Mock<IIdValidation> _idValidation;
		public APIPostHandlerTests() 
		{
			_postHandlers = new Mock<IDBPostHandlers>();
			_idValidation = new Mock<IIdValidation>();
		}
		[Fact]
		public void APIPostHandlerTest()
		{
			//arrange
			var model = new CardModel
			{
				id = 1,
				name = "Machine Rifle"
			};

			_idValidation.Setup(x => x.CheckIfIdExists(model)).ReturnsAsync(true);
			var handler = new APIPostHandler(_postHandlers.Object, _idValidation.Object);

			//act
			var result = handler.PostNewCard(model);

			//assert
			_postHandlers.Verify(x => x.DBPostHandler(model), Times.Once);
		}
	}
}
