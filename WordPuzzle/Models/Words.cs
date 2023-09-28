using System.Collections.Generic;
using System;

namespace WordPuzzle.Models
{
  public class Words
  {
    public static List<string> AvailableWords { get; set; } = new List<string> {
      "word", "test", "available", "random", "wordle", 
      "epicodus"
    };

    public static string Random()
    {
      var random = new Random();
      int range = AvailableWords.Count;
      // Return a word from word list at random index between 0 and length of list - 1.
      string word = AvailableWords[random.Next(range)];
      return word;
    }

    public static void Add(string newWord)
    {
      AvailableWords.Add(newWord);
    }
  }
}