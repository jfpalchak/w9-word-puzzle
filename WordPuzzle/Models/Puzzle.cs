using System.Collections.Generic;

namespace WordPuzzle.Models
{
  public class Puzzle
  {
    public string Word { get; set; }
    public char[] Letters { get; set; }
    public List<char> GuessedLetters { get; set; } = new List<char>{};
    public int Attempts { get; } = 6;

    public Puzzle(string chosenWord)
    {
      Word = chosenWord;
      Letters = chosenWord.ToCharArray();
    }

    public Puzzle()
    {
      Word = Words.Random();
      Letters = Word.ToCharArray();
    }
  }
}