using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using LogicLayer;
using LogicLayer.APIGetLogic;
using LogicLayer.APIPostLogic;
using System.Reflection;
using Microsoft.Identity.Client;

namespace APILayer.Controllers
{
	[ApiController]
	[Route("/api/[controller]")]
	public class AvailableCardsAPI : Controller
	{
		private readonly IAPIGetHandlers _apiGetHandler;
		private readonly IAPIPostHandler _postHandler;
		public AvailableCardsAPI(IAPIGetHandlers apiGetHandlers, IAPIPostHandler postHandler) 
		{
			_apiGetHandler = apiGetHandlers;
			_postHandler = postHandler;

		}

		// GET: ViewAllCards
		[Route("GetAllCards")]
		[HttpGet]

		public async Task<IEnumerable<CardModel>> GetAllCards()
		{
			var getData = await _apiGetHandler.GetAllCards();
			foreach (var card in getData) 
			{
				if (card.type == CardType.Machine)
				{
					card.type.ToString();
				}
			}
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
			return getData;
		}

		// POST: Post new cards to Database
		[Route("PostNewCard")]
		[HttpPost]
		public async Task<IActionResult> PostNewCard([FromBody] CardModel model)
		{
			if (Enum.TryParse(typeof(CardType), model.inputType, out var type))
			{
				model.type = (CardType)type;
			}

			await _postHandler.PostNewCard(model);

			return Ok(model);	
		}

		//DELETE: Delete card
		[Route("DeleteCard")]
		[HttpDelete]
		public async Task<IActionResult> DeleteCard(int id)
		{
			var card = GetCardById(id);
			throw new NotImplementedException();

		}
	}
}
