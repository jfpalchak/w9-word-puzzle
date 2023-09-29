using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using WordPuzzle.Models;


namespace WordPuzzle.Tests
{
  [TestClass]
  public class GameTests
  {
    [TestMethod]
    public void AddPuzzles_AddsNewPuzzleToList_Void()
    {
      Game newGame = new Game("Joe");
      List<Puzzle> list = newGame.Puzzles;
      Puzzle firstPuzzle = list[0];
      Puzzle secondPuzzle = new Puzzle();
      Puzzle found1Puzzle = Puzzle.Find(1);
      Puzzle found2Puzzle = Puzzle.Find(2);
      newGame.AddPuzzle(secondPuzzle);
      Puzzle otherPuzzle = list[1];

      Assert.AreEqual(firstPuzzle, found1Puzzle);
      Assert.AreEqual(otherPuzzle, found2Puzzle);
    }
  } 
}