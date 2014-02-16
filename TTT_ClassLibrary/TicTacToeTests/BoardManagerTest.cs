﻿using TTT_ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TicTacToeTests
{

    [TestClass()]
    public class BoardManagerTest
    {


        private TestContext testContextInstance;


        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        [TestMethod()]
        public void BoardManagerConstructorTest()
        {
            BoardManager target = new BoardManager();
        }


        [TestMethod()]
        public void CreateNewBoardShouldCreateA3x3TTTBoard()
        {
            BoardManager target = new BoardManager();
            char[,] expected = new char[3, 3];
            char[,] actual = target.CreateNewBoard(3);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void LogMoveShouldLogACreatedMove()
        {
            BoardManager target = new BoardManager();
            CreatedMove move = new CreatedMove(2, 1, 'O');
            target.LogMove(move);
            char actual = target.boardArray[1, 2];
            char expected = 'O';
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void LogMoveShouldNotOverwriteMoves()
        {
            BoardManager target = new BoardManager();
            CreatedMove moveOne = new CreatedMove(1, 1, 'X');
            CreatedMove moveTwo = new CreatedMove(1, 1, 'O');
            target.LogMove(moveOne);
            target.LogMove(moveTwo);
            char expectedIdentity = 'X';
            char actualIdentity = target.boardArray[1, 1];
            Assert.AreEqual(expectedIdentity, actualIdentity);
        }

        [TestMethod()]
        public void LogMoveShouldReturnAnInvalidCreatedMoveIfMovesAreInvalid()
        {
            BoardManager target = new BoardManager();
            CreatedMove moveOne = new CreatedMove(1, 1, 'X');
            CreatedMove moveTwo = new CreatedMove(1, 1, 'O');
            target.LogMove(moveOne);
            char actualIdentity = target.LogMove(moveTwo).plyrIdentity;
            char expectedIdentity = 'I';
            Assert.AreEqual(expectedIdentity, actualIdentity);
        }

        [TestMethod()]
        public void BoardManagerShouldBeAbleToCheckTheValidityOfAMove()
        {
            BoardManager target = new BoardManager();
            CreatedMove moveOne = new CreatedMove(1, 1, 'X');
            CreatedMove moveTwo = new CreatedMove(1, 1, 'O');
            target.LogMove(moveOne);
            bool expected = false;
            bool actual = target.IsMoveValid(moveTwo);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CheckForWinShouldReturnTrueIfThereAreThreeXsInARow()
        {
            //Three Across the Top
            BoardManager board = new BoardManager();
            board.LogMove(new CreatedMove(0, 0, 'X'));
            board.LogMove(new CreatedMove(1, 0, 'X'));
            board.LogMove(new CreatedMove(2, 0, 'X'));
            Assert.AreEqual(true, board.CheckForWin());

            //Three Across the Middle
            board = new BoardManager();
            board.LogMove(new CreatedMove(0, 1, 'X'));
            board.LogMove(new CreatedMove(1, 1, 'X'));
            board.LogMove(new CreatedMove(2, 1, 'X'));
            Assert.AreEqual(true, board.CheckForWin());

            //Three Across the Bottom
            board = new BoardManager();
            board.LogMove(new CreatedMove(0, 2, 'X'));
            board.LogMove(new CreatedMove(1, 2, 'X'));
            board.LogMove(new CreatedMove(2, 2, 'X'));
            Assert.AreEqual(true, board.CheckForWin());

            //Three Down the Left Side
            board = new BoardManager();
            board.LogMove(new CreatedMove(0, 0, 'X'));
            board.LogMove(new CreatedMove(0, 1, 'X'));
            board.LogMove(new CreatedMove(0, 2, 'X'));
            Assert.AreEqual(true, board.CheckForWin());

            //Three Down the Middle
            board = new BoardManager();
            board.LogMove(new CreatedMove(1, 0, 'X'));
            board.LogMove(new CreatedMove(1, 1, 'X'));
            board.LogMove(new CreatedMove(1, 2, 'X'));
            Assert.AreEqual(true, board.CheckForWin());

            //Three Down the Right Side
            board = new BoardManager();
            board.LogMove(new CreatedMove(2, 0, 'X'));
            board.LogMove(new CreatedMove(2, 1, 'X'));
            board.LogMove(new CreatedMove(2, 2, 'X'));
            Assert.AreEqual(true, board.CheckForWin());

            //Three In A Slash
            board = new BoardManager();
            board.LogMove(new CreatedMove(2, 0, 'X'));
            board.LogMove(new CreatedMove(1, 1, 'X'));
            board.LogMove(new CreatedMove(0, 2, 'X'));
            Assert.AreEqual(true, board.CheckForWin());

            //Three In A Backslash
            board = new BoardManager();
            board.LogMove(new CreatedMove(0, 0, 'X'));
            board.LogMove(new CreatedMove(1, 1, 'X'));
            board.LogMove(new CreatedMove(2, 2, 'X'));
            Assert.AreEqual(true, board.CheckForWin());
        }

        [TestMethod()]
        public void CheckForWinShouldReturnTrueIfThereAreThreeOsInARow()
        {
            //Three Across the Top
            BoardManager board = new BoardManager();
            board.LogMove(new CreatedMove(0, 0, 'O'));
            board.LogMove(new CreatedMove(1, 0, 'O'));
            board.LogMove(new CreatedMove(2, 0, 'O'));
            Assert.AreEqual(true, board.CheckForWin());

            //Three Across the Middle
            board = new BoardManager();
            board.LogMove(new CreatedMove(0, 1, 'O'));
            board.LogMove(new CreatedMove(1, 1, 'O'));
            board.LogMove(new CreatedMove(2, 1, 'O'));
            Assert.AreEqual(true, board.CheckForWin());

            //Three Across the Bottom
            board = new BoardManager();
            board.LogMove(new CreatedMove(0, 2, 'O'));
            board.LogMove(new CreatedMove(1, 2, 'O'));
            board.LogMove(new CreatedMove(2, 2, 'O'));
            Assert.AreEqual(true, board.CheckForWin());

            //Three Down the Left Side
            board = new BoardManager();
            board.LogMove(new CreatedMove(0, 0, 'O'));
            board.LogMove(new CreatedMove(0, 1, 'O'));
            board.LogMove(new CreatedMove(0, 2, 'O'));
            Assert.AreEqual(true, board.CheckForWin());

            //Three Down the Middle
            board = new BoardManager();
            board.LogMove(new CreatedMove(1, 0, 'O'));
            board.LogMove(new CreatedMove(1, 1, 'O'));
            board.LogMove(new CreatedMove(1, 2, 'O'));
            Assert.AreEqual(true, board.CheckForWin());

            //Three Down the Right Side
            board = new BoardManager();
            board.LogMove(new CreatedMove(2, 0, 'O'));
            board.LogMove(new CreatedMove(2, 1, 'O'));
            board.LogMove(new CreatedMove(2, 2, 'O'));
            Assert.AreEqual(true, board.CheckForWin());

            //Three In A Slash
            board = new BoardManager();
            board.LogMove(new CreatedMove(2, 0, 'O'));
            board.LogMove(new CreatedMove(1, 1, 'O'));
            board.LogMove(new CreatedMove(0, 2, 'O'));
            Assert.AreEqual(true, board.CheckForWin());

            //Three In A Backslash
            board = new BoardManager();
            board.LogMove(new CreatedMove(0, 0, 'O'));
            board.LogMove(new CreatedMove(1, 1, 'O'));
            board.LogMove(new CreatedMove(2, 2, 'O'));
            Assert.AreEqual(true, board.CheckForWin());
        }

        [TestMethod()]
        public void BoardManagerShouldKnowIfThereIsATie()
        {
            BoardManager board = new BoardManager();
            HumanPlayer playerOne = new HumanPlayer('X');
            ComputerPlayer playerTwo = new ComputerPlayer('O');

            board.LogMove(new CreatedMove(1, 1, 'X'));
            board.LogMove(new CreatedMove(0, 0, 'O'));
            board.LogMove(new CreatedMove(0, 1, 'X'));
            board.LogMove(new CreatedMove(2, 1, 'O'));
            board.LogMove(new CreatedMove(0, 2, 'X'));
            board.LogMove(new CreatedMove(2, 0, 'O'));
            board.LogMove(new CreatedMove(1, 0, 'X'));
            board.LogMove(new CreatedMove(1, 2, 'O'));
            board.LogMove(new CreatedMove(2, 2, 'X'));

            Assert.AreEqual(true, board.CheckForTie(board.boardArray));
        }

        
    }
}
