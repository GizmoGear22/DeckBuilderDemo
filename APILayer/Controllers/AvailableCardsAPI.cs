using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using LogicLayer;
using LogicLayer.APIGetLogic;
using LogicLayer.APIPostLogic;

namespace APILayer.Controllers
{
	[ApiController]
	[Route("/api/[controller]")]
	public class AvailableCardsAPI : Controller
	{
		private readonly IAPIGetHandlers _apiGetHandler;
		private readonly IAPIPostHandlers _apiPostHandler;
		public AvailableCardsAPI(IAPIGetHandlers apiGetHandlers) 
		{
			_apiGetHandler = apiGetHandlers;
		}

		// GET: ViewAllCards
		[Route("GetAllCards")]
		[HttpGet]

		public async Task<IEnumerable<FrontEndModel>> GetAllCards()
		{
			var getData = await _apiGetHandler.GetAllCards();
			return getData.ToList();
		}

		[Route("GetAllCards/Machine")]
		[HttpGet]
		public async Task<IEnumerable<DBCardModel>> GetAllCardsByMachineType()
		{
			throw new NotImplementedException();
		}

// POST: Post new cards to Database
[Route("PostNewCard")]
		[HttpPost]
		public async Task<IActionResult> PostNewCard([FromBody] DBCardModel model)
		{

			_apiPostHandler.APIAddNewCard(model);
			throw new NotImplementedException();
		}

	}
}
