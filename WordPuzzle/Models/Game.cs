using System.Collections.Generic;
using System;

namespace WordPuzzle.Models
{
  public class Game
  {
    private static List<Game> _instances = new List<Game>{};
    public Puzzle Puzzle { get; set; }
    // public List<Puzzle> Puzzles { get; set; }
    public int Id { get; set; }
    public string Type { get; set; }

    public Game()
    {
      _instances.Add(this);
      Id = _instances.Count;

      Puzzle = new Puzzle();
      
      Type = "Random";
    }

    public Game(string chosenWord)
    {
      _instances.Add(this);
      Id = _instances.Count;

      Puzzle = new Puzzle(chosenWord);

      Type = "Custom";
    }

    public static Game Find(int searchId)
    {
      return _instances[searchId-1];
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }

    public string CheckState()
    {
      if (Puzzle.Attempts == 0)
      {
        return "LOST";
      }
      else if (!String.Join("", Puzzle.Answer).Contains('-'))
      {
        return "WON";
      }
      else
      {
        return "ONGOING";
      }
    }
  }
}