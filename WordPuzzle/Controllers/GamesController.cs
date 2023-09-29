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
    [HttpGet("/games/{gameId}")]
    public ActionResult Show(int gameId)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Game foundGame = Game.Find(gameId);
      List<Puzzle> gamePuzzles = foundGame.Puzzles;
      
      model.Add("game", foundGame);
      model.Add("puzzles", gamePuzzles);

      return View(model);
    }

    [HttpPost("/games/{gameId}/puzzles")]
    public ActionResult Create(int gameId, string chosenWord)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Game foundGame = Game.Find(gameId);
      Puzzle newPuzzle;
      if (chosenWord.ToLower() != "random")
      {
        newPuzzle = new Puzzle(chosenWord);
      }
      else
      {
        newPuzzle = new Puzzle();
      }
      foundGame.AddPuzzle(newPuzzle);
      List<Puzzle> gamePuzzles = foundGame.Puzzles;

      model.Add("game", foundGame);
      model.Add("puzzles", gamePuzzles);

      return View("Show", model);
    }

  }
}