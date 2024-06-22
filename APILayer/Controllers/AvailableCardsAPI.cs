using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using LogicLayer;
using LogicLayer.APIGetLogic;
using LogicLayer.APIPostLogic;
using LogicLayer.Utility;
using System.Reflection;

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

		[Route("GetCardByID")]
		[HttpGet]
		public async Task <CardModel> GetCardById(int id)
		{
			throw new NotImplementedException();
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


/*
		// GET: AvailableCardsAPI/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: AvailableCardsAPI/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: AvailableCardsAPI/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: AvailableCardsAPI/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: AvailableCardsAPI/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: AvailableCardsAPI/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: AvailableCardsAPI/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
*/ 
	}
}
