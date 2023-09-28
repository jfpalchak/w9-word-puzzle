using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using WordPuzzle.Models;

namespace WordPuzzle.Controllers
{
  public class GamesController : Controller
  {
    // SHOW ALL GAMES
    [HttpGet("/games")]
    public ActionResult Index()
    {
      List<Game> allGames = Game.GetAll();
      return View(allGames);
    }

    // SHOW NEW GAME FORM
    [HttpGet("/games/new")]
    public ActionResult New()
    {
      return View();
    }

    // CREATE NEW GAME & RETURN TO SHOW ALL GAMES
    [HttpPost("/games")]
    public ActionResult Create(string playerName)
    {
      Game newGame = new Game(playerName);
      return RedirectToAction("Index");
    }

    // SHOW SPECIFIC GAME AND ALL THE PUZZLES THAT HAVE BEEN STARTED
    [HttpGet("/games/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Game foundGame = Game.Find(id);
      List<Puzzle> gamePuzzles = foundGame.Puzzles;
      
      model.Add("game", foundGame);
      model.Add("puzzles", gamePuzzles);

      return View(model);
    }
  }
}