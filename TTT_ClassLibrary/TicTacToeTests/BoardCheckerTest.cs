using TTT_ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TicTacToeTests
{
    [TestClass()]
    public class BoardCheckerTest
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
        public void CheckForWinShouldReturnTrueIfThereAreThreeXsInARow()
        {
            BoardChecker target = new BoardChecker();
            //Three Across the Top
            BoardManager board = new BoardManager();
            HumanPlayer playerOne = new HumanPlayer('x');
            board.LogMove(playerOne.MakeMove(0, 0));
            board.LogMove(playerOne.MakeMove(1, 0));
            board.LogMove(playerOne.MakeMove(2, 0));
            Assert.AreEqual(true, target.CheckForWin(board.boardArray));

            //Three Across the Middle
            board = new BoardManager();
            board.LogMove(playerOne.MakeMove(0, 1));
            board.LogMove(playerOne.MakeMove(1, 1));
            board.LogMove(playerOne.MakeMove(2, 1));
            Assert.AreEqual(true, target.CheckForWin(board.boardArray));

            //Three Across the Bottom
            board = new BoardManager();
            board.LogMove(playerOne.MakeMove(0, 2));
            board.LogMove(playerOne.MakeMove(1, 2));
            board.LogMove(playerOne.MakeMove(2, 2));
            Assert.AreEqual(true, target.CheckForWin(board.boardArray));

            //Three Down the Left Side
            board = new BoardManager();
            board.LogMove(playerOne.MakeMove(0, 0));
            board.LogMove(playerOne.MakeMove(0, 1));
            board.LogMove(playerOne.MakeMove(0, 2));
            Assert.AreEqual(true, target.CheckForWin(board.boardArray));

            //Three Down the Middle
            board = new BoardManager();
            board.LogMove(playerOne.MakeMove(1, 0));
            board.LogMove(playerOne.MakeMove(1, 1));
            board.LogMove(playerOne.MakeMove(1, 2));
            Assert.AreEqual(true, target.CheckForWin(board.boardArray));

            //Three Down the Right Side
            board = new BoardManager();
            board.LogMove(playerOne.MakeMove(1, 0));
            board.LogMove(playerOne.MakeMove(1, 1));
            board.LogMove(playerOne.MakeMove(1, 2));
            Assert.AreEqual(true, target.CheckForWin(board.boardArray));

            //Three In A Slash
            board = new BoardManager();
            board.LogMove(playerOne.MakeMove(0, 2));
            board.LogMove(playerOne.MakeMove(1, 1));
            board.LogMove(playerOne.MakeMove(2, 0));
            Assert.AreEqual(true, target.CheckForWin(board.boardArray));

            //Three In A Backslash
            board = new BoardManager();
            board.LogMove(playerOne.MakeMove(0, 0));
            board.LogMove(playerOne.MakeMove(1, 1));
            board.LogMove(playerOne.MakeMove(2, 2));
            Assert.AreEqual(true, target.CheckForWin(board.boardArray));
        }

        [TestMethod()]
        public void CheckForWinShouldReturnTrueIfThereAreThreeOsInARow()
        {
            BoardChecker target = new BoardChecker();

            //Three Across the Top
            BoardManager board = new BoardManager();
            HumanPlayer playerOne = new HumanPlayer('o');
            board.LogMove(playerOne.MakeMove(0, 0));
            board.LogMove(playerOne.MakeMove(1, 0));
            board.LogMove(playerOne.MakeMove(2, 0));
            Assert.AreEqual(true, target.CheckForWin(board.boardArray));

            //Three Across the Middle
            board = new BoardManager();
            board.LogMove(playerOne.MakeMove(0, 1));
            board.LogMove(playerOne.MakeMove(1, 1));
            board.LogMove(playerOne.MakeMove(2, 1));
            Assert.AreEqual(true, target.CheckForWin(board.boardArray));

            //Three Across the Bottom
            board = new BoardManager();
            board.LogMove(playerOne.MakeMove(0, 2));
            board.LogMove(playerOne.MakeMove(1, 2));
            board.LogMove(playerOne.MakeMove(2, 2));
            Assert.AreEqual(true, target.CheckForWin(board.boardArray));

            //Three Down the Left Side
            board = new BoardManager();
            board.LogMove(playerOne.MakeMove(0, 0));
            board.LogMove(playerOne.MakeMove(0, 1));
            board.LogMove(playerOne.MakeMove(0, 2));
            Assert.AreEqual(true, target.CheckForWin(board.boardArray));

            //Three Down the Middle
            board = new BoardManager();
            board.LogMove(playerOne.MakeMove(1, 0));
            board.LogMove(playerOne.MakeMove(1, 1));
            board.LogMove(playerOne.MakeMove(1, 2));
            Assert.AreEqual(true, target.CheckForWin(board.boardArray));

            //Three Down the Right Side
            board = new BoardManager();
            board.LogMove(playerOne.MakeMove(1, 0));
            board.LogMove(playerOne.MakeMove(1, 1));
            board.LogMove(playerOne.MakeMove(1, 2));
            Assert.AreEqual(true, target.CheckForWin(board.boardArray));

            //Three In A Slash
            board = new BoardManager();
            board.LogMove(playerOne.MakeMove(0, 2));
            board.LogMove(playerOne.MakeMove(1, 1));
            board.LogMove(playerOne.MakeMove(2, 0));
            Assert.AreEqual(true, target.CheckForWin(board.boardArray));

            //Three In A Backslash
            board = new BoardManager();
            board.LogMove(playerOne.MakeMove(0, 0));
            board.LogMove(playerOne.MakeMove(1, 1));
            board.LogMove(playerOne.MakeMove(2, 2));
            Assert.AreEqual(true, target.CheckForWin(board.boardArray));
        }

        [TestMethod()]
        public void BoardManagerShouldKnowIfThereIsATie()
        {
            BoardChecker target = new BoardChecker();
            BoardManager board = new BoardManager();
            HumanPlayer playerOne = new HumanPlayer('X');
            ComputerPlayer playerTwo = new ComputerPlayer('O');

            board.LogMove(playerOne.MakeMove(1, 1));
            board.LogMove(playerTwo.MakeMove(0, 0));
            board.LogMove(playerOne.MakeMove(0, 1));
            board.LogMove(playerTwo.MakeMove(2, 1));
            board.LogMove(playerOne.MakeMove(0, 2));
            board.LogMove(playerTwo.MakeMove(2, 0));
            board.LogMove(playerOne.MakeMove(1, 0));
            board.LogMove(playerTwo.MakeMove(1, 2));
            board.LogMove(playerOne.MakeMove(2, 2));

            Assert.AreEqual(true, target.CheckForTie(board.boardArray));
        }
    }
}
