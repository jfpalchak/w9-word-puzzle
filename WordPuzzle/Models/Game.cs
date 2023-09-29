using System.Collections.Generic;
using System;

namespace WordPuzzle.Models
{
  public class Game
  {
    private static List<Game> _instances = new List<Game>{};
    public List<Puzzle> Puzzles { get; set; }
    public int Id { get; set; }
    public string Type { get; set; }
    public string PlayerName { get; set; }


    public Game(string playerName)
    {
      _instances.Add(this);
      Id = _instances.Count;

      Puzzles = new List<Puzzle> {new Puzzle()};
            
      Type = "Random";
      PlayerName = playerName;
    }

    public Game(string playerName, string chosenWord)
    {
      _instances.Add(this);
      Id = _instances.Count;

      Puzzles = new List<Puzzle> {new Puzzle(chosenWord)};

      Type = "Custom";
      PlayerName = playerName;
    }

    public static Game Find(int searchId)
    {
      return _instances[searchId-1];
    }

    public static List<Game> GetAll()
    {
      return _instances;
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }

    public void AddPuzzle(Puzzle newPuzzle)
    {
      Puzzles.Add(newPuzzle);
    }
  }
}