using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using WordPuzzle.Models;


namespace WordPuzzle.Tests
{
  [TestClass]
  public class WordsTests
  {
    [TestMethod]
    public void Random_ReturnsRandomWordFromListOfWords_String()
    {
      string word = Words.Random();

      Assert.AreEqual(typeof(String), word.GetType());
    }

    [TestMethod]
    public void GetAvailableWords_ReturnsListOfAllAvailableWords_List()
    {
      List<string> wordList = Words.AvailableWords;

      Assert.AreEqual(typeof(List<string>), wordList.GetType());
    }

    [TestMethod]
    public void Add_AddsGivenWordToListOfAvailableWords_Void()
    {
      string newWord = "hello";
      
      Words.Add(newWord);

      Assert.IsTrue(Words.AvailableWords.Contains(newWord));
    }
  } 
}