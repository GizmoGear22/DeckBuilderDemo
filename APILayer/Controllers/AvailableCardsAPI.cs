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
		public async Task<IEnumerable<CardModel>> GetAllCardsByMachineType()
		{
			throw new NotImplementedException();
		}

// POST: Post new cards to Database
[Route("PostNewCard")]
		[HttpPost]
		public async Task<IActionResult> PostNewCard([FromBody] CardModel model)
		{
			throw new NotImplementedException();
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
