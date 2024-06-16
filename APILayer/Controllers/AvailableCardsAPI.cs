﻿using Microsoft.AspNetCore.Http;
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
		private readonly IAPIGetHandlers _apiGetHandlers;
		private readonly IAPIPostHandlers _postHandlers;
		private readonly ILogger _logger;
		public AvailableCardsAPI(IAPIGetHandlers aPIGetHandlers, IAPIPostHandlers postHandlers, ILogger logger) 
		{
			_apiGetHandlers = aPIGetHandlers;
			_postHandlers = postHandlers;
			_logger = logger;
		}

		// GET: ViewAllCards
		[Route("GetAllCards")]
		[HttpGet]

		public async Task<IEnumerable<CardModel>> GetAllCards()
		{
			var getData = await _apiGetHandlers.GetAllCardsFromRepository();
			return getData.ToList();
		}

		[Route("GetAllCards/Machine")]
		[HttpGet]
		public async Task<IEnumerable<CardModel>> GetAllCardsByMachineType()
		{
			var getData = await _apiGetHandlers.GetAllCardsByTypeRepository(CardType.Machine);
			return getData.ToList();
		}

// POST: Post new cards to Database
[Route("PostNewCard")]
		[HttpPost]
		public async Task<IActionResult> PostNewCard([FromBody] CardModel model)
		{
			try
			{
				if (model == null)
				{
					return BadRequest("Not a proper card");
				}

				await _postHandlers.APIPostHandler(model);
				return Ok();

			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				Console.WriteLine(ex.StackTrace);
				_logger.LogError(ex.Message);
				return StatusCode(500, "Problem at API");
			}
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
