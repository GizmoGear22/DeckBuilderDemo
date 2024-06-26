﻿using System;
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
using LogicLayer.Validation.CheckName;

namespace UnitTests.LogicLayerTests
{
	public class APIPostHandlerTests
	{
		private readonly Mock<IDBPostHandlers> _postHandlers;
		private readonly Mock<IIdValidation> _idValidation;
		private readonly Mock<ICheckIfNameExists> _checkIfNameExists;
		public APIPostHandlerTests() 
		{
			_postHandlers = new Mock<IDBPostHandlers>();
			_idValidation = new Mock<IIdValidation>();
			_checkIfNameExists = new Mock<ICheckIfNameExists>();
		}
		[Fact]
		public async Task APIPostHandlerTest()
		{
			//arrange
			var model = new CardModel
			{
				id = 1,
				name = "Machine Rifle"
			};

			var handler = new APIPostHandler(_postHandlers.Object, _idValidation.Object, _checkIfNameExists.Object);

			//act
			_idValidation.Setup(x => x.CheckId(model)).ReturnsAsync((true, null));
			_idValidation.Setup(x => x.CheckIfIdExists(model)).ReturnsAsync((true, null));
			_checkIfNameExists.Setup(x => x.CheckName(model)).ReturnsAsync((true, null));
			_checkIfNameExists.Setup(x => x.CheckNameCharacters(model)).ReturnsAsync((true, null));
			var result = handler.PostNewCard(model);

			//assert
			_postHandlers.Verify(x => x.DBPostHandler(model), Times.Once);
		}
	}
}
