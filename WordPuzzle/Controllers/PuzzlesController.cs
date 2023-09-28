using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using WordPuzzle.Models;

namespace WordPuzzle.Controllers
{
  public class PuzzlesController : Controller
  {
    [HttpGet("/games/{gameId}/puzzles/{puzzleId}")]
    public ActionResult Show(int gameId, int puzzleId)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Game foundGame = Game.Find(gameId);
      Puzzle foundPuzzle = Puzzle.Find(puzzleId);

      model.Add("game", foundGame);
      model.Add("puzzle", foundPuzzle);

      return View(model);
    }

    // SHOW FORM FOR NEW PUZZLE
    // (The Route to create will be in Games Controller, since adding a new puzzle modifies a Game)
    [HttpPost("/games/{gameId}/puzzles/new")]
    public ActionResult New(int gameId)
    {
      Game game = Game.Find(gameId);

      return View(game);
    }
  }
}