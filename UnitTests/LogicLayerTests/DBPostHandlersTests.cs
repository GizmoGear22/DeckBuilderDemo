using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBAccess.DBControllers;
using LogicLayer.APIPostLogic;
using Models;
using Moq;

namespace UnitTests.LogicLayerTests
{
	public class DBPostHandlersTests
	{
		public async Task DBPostHandlerTest()
		{
			//arrange
			var mock = new Mock<IAvailableCardsController>();
			CardModel cardModel = new CardModel();

			mock.Setup(x => x.PostNewCardsToDB(cardModel));

			//act
			var result = new DBPostHandlers(mock.Object);

			//assert
		}
	}
}
