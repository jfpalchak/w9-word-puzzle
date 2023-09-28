using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using WordPuzzle.Models;


namespace WordPuzzle.Tests
{
  [TestClass]
  public class PuzzleTests
  {
    [TestMethod]
    public void PuzzleConstructor_CreatesInstanceOfPuzzleGivenAWord_Puzzle()
    {
      Puzzle newPuzzle = new Puzzle("Word");
      Assert.AreEqual(typeof(Puzzle), newPuzzle.GetType());
    }

    [TestMethod]
    public void PuzzleConstructor_CreatesInstanceOfPuzzleWithRandomWordIfNotGivenOne_Puzzle()
    {
      Puzzle newPuzzle = new Puzzle();
      Assert.AreEqual(typeof(String), newPuzzle.Word.GetType());
    }

    [TestMethod]
    public void GetWord_ReturnsTheChosenWord_String()
    {
      string chosenWord = "word";
      Puzzle newPuzzle = new Puzzle(chosenWord);

      string result = newPuzzle.Word;

      Assert.AreEqual(chosenWord, result);
    }

    [TestMethod]
    public void GetLetters_ReturnsArrayOfLettersInPuzzle_CharArray()
    {
      string chosenWord = "word";
      char[] letterArray = chosenWord.ToCharArray();
      Puzzle newPuzzle = new Puzzle(chosenWord);

      char[] result = newPuzzle.Letters;

      CollectionAssert.AreEqual(letterArray, result);
    }

    [TestMethod]
    public void GetAttempts_ReturnsNumberOfAttemptsAvailableToPlayer_Int()
    {
      Puzzle newPuzzle = new Puzzle();

      int attempts = newPuzzle.Attempts;

      Assert.AreEqual(6, attempts);
    }

    [TestMethod]
    public void GetAnswer_ReturnsListOfBlankLettersPlayerMustGuess_List()
    {
      Puzzle newPuzzle = new Puzzle("word");
      List<char> blankList = new List<char> { '-', '-', '-', '-'};

      List<char> result = newPuzzle.Answer;

      CollectionAssert.AreEqual(blankList, result);
    }

    [TestMethod]
    public void Guess_ReturnsFalseIfLetterIsNotInTheWord_Bool()
    {
      Puzzle newPuzzle = new Puzzle("word");

      bool result = newPuzzle.Guess("i");

      Assert.AreEqual(false, result);
    }

    [TestMethod]
    public void Guess_AddsLetterToListOfGuessesIfLetterIsNotInWord_Bool()
    {
      Puzzle newPuzzle = new Puzzle("word");
      newPuzzle.Guess("i");
      List<char> guessList = new List<char> { 'i' };

      List<char> result = newPuzzle.GuessedLetters;

      CollectionAssert.AreEqual(guessList, result);
    }

    [TestMethod]
    public void Guess_ReturnsTrueIfLetterIsInTheWord_Bool()
    {
      Puzzle newPuzzle = new Puzzle("word");

      bool result = newPuzzle.Guess("w");

      Assert.AreEqual(true, result);
    }

    [TestMethod]
    public void Guess_ReplacesCorrespondingBlankWithAppropriateLetterIfGuessIsCorrect_Bool()
    {
      Puzzle newPuzzle = new Puzzle("word");
      newPuzzle.Guess("w");
      List<char> blankList = new List<char> { 'w', '-', '-', '-'};
      List<char> result = newPuzzle.Answer;

      CollectionAssert.AreEqual(blankList, result);
    }
  }
}