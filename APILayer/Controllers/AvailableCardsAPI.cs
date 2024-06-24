using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using LogicLayer;
using LogicLayer.APIGetLogic;
using LogicLayer.APIPostLogic;
using System.Reflection;
using Microsoft.Identity.Client;
using LogicLayer.APIDeleteLogic;

namespace APILayer.Controllers
{
	[ApiController]
	[Route("/api/[controller]")]
	public class AvailableCardsAPI : Controller
	{
		private readonly IAPIGetHandlers _apiGetHandler;
		private readonly IAPIPostHandler _postHandler;
		private readonly IAPIDeleteHandlers _deleteHandler;
		public AvailableCardsAPI(IAPIGetHandlers apiGetHandlers, IAPIPostHandler postHandler, IAPIDeleteHandlers deleteHandler) 
		{
			_apiGetHandler = apiGetHandlers;
			_postHandler = postHandler;
			_deleteHandler = deleteHandler;

		}

		// GET: ViewAllCards
		[Route("GetAllCards")]
		[HttpGet]

		public async Task<IEnumerable<CardModel>> GetAllCards()
		{
			var getData = await _apiGetHandler.GetAllCards();

			return getData.ToList();
		}

		//Get: ViewCardsByType
		[Route("GetAllCardByType")]
		[HttpGet]
		public async Task<IEnumerable<CardModel>> GetAllCardsByType(CardType type)
		{
			var getData = await _apiGetHandler.GetAllCardsByType(type);
			return getData.ToList();
		}

		//Get: ViewCardById
		[Route("GetCardByID")]
		[HttpGet]
		public async Task <CardModel> GetCardById(int id)
		{
			var getData = await _apiGetHandler.GetCardById(id);
			if (getData != null)
			{
				return getData;
			}
			else
			{
				throw new Exception("Model cannot be null");
			}


		}

		// POST: Post new cards to Database
		[Route("PostNewCard")]
		[HttpPost]
		public async Task<IActionResult> PostNewCard([FromBody] CardModel model)
		{
			if (ModelState.IsValid)
			{
				if (Enum.TryParse(typeof(CardType), model.inputType, out var type))
				{
					model.type = (CardType)type;
				}

				await _postHandler.PostNewCard(model);
				return Ok(model);
			}
			else { throw new Exception("Please use a proper model"); }


		}

		//DELETE: Delete card
		[Route("DeleteCard")]
		[HttpDelete]
		public async Task<IActionResult> DeleteCard(CardModel model)
		{
			var card = await _apiGetHandler.GetCardById(model.id);
			await _deleteHandler.DeleteCard(card);
			return Ok(model);

		}
	}
}
