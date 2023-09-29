using System.Collections.Generic;
using System;

namespace WordPuzzle.Models
{
  public class Puzzle
  {
    public string Word { get; set; }
    public char[] Letters { get; set; }
    public List<char> Answer { get; set; } = new List<char>{};
    public List<char> GuessedLetters { get; set; } = new List<char>{};

    private static List<Puzzle> _instances = new List<Puzzle>{};
    public int Id { get; set; }

    public int Attempts { get; set; } = 6;

    public Puzzle(string chosenWord)
    {
      Word = chosenWord;
      Letters = chosenWord.ToCharArray();
      foreach (char letter in Letters)
      {
        Answer.Add('-');
      }
      _instances.Add(this);
      Id = _instances.Count;
    }

    // Overloader: no argument creates a random word for the puzzle
    public Puzzle()
    {
      Word = Words.Random();
      Letters = Word.ToCharArray();
      foreach (char letter in Letters)
      {
        Answer.Add('-');
      }
      _instances.Add(this);
      Id = _instances.Count;
    }

    public bool Guess(string userGuess)
    {
      char guess = char.Parse(userGuess);

      if (!Word.Contains(guess))
      {
        GuessedLetters.Add(guess);
        Attempts -= 1;
        return false;
      }

      ReplaceBlankWith(guess);
      
      return true;
    }

    // REPLACE CORRESPONDING BLANK LETTERS IF THE GUESS MATCHES A LETTER IN THE WORD
    private void ReplaceBlankWith(char guess)
    {
      // Loop through each letter in the word.
      // If one or more letters match the player's guess, 
      // replace the corresponding Blank ('-') with the appropriate letter.
      foreach(char letter in Letters)
      {
        if (letter == guess)
        {
          int index = Array.IndexOf(Letters, letter);
          Answer[index] = letter;
        }
      }
    }

    public string CheckPuzzleState()
    {
      if (Attempts == 0)
      {
        return "LOST";
      }
      else if (!String.Join("", Answer).Contains('-'))
      {
        return "WON";
      }
      else
      {
        return "ONGOING";
      }
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }

    public static List<Puzzle> GetAll()
    {
      return _instances;
    }

    public static Puzzle Find(int searchId)
    {
      return _instances[searchId-1];
    }
  }
}