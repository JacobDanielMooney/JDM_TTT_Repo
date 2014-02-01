using TTT_ClassLibrary;
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
            char[,] actual = target.CreateNewBoard();
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
        public void CheckForWinShouldReturnTrueIfThereAreThreeXsInARow()
        {
            //Three Across the Top
            BoardManager target = new BoardManager();
            HumanPlayer playerOne = new HumanPlayer('x');
            target.LogMove(playerOne.MakeMove(0, 0));
            target.LogMove(playerOne.MakeMove(1, 0));
            target.LogMove(playerOne.MakeMove(2, 0));
            Assert.AreEqual(true, target.CheckForWin());

            //Three Across the Middle
            target = new BoardManager();
            target.LogMove(playerOne.MakeMove(0, 1));
            target.LogMove(playerOne.MakeMove(1, 1));
            target.LogMove(playerOne.MakeMove(2, 1));
            Assert.AreEqual(true, target.CheckForWin());

            //Three Across the Bottom
            target = new BoardManager();
            target.LogMove(playerOne.MakeMove(0, 2));
            target.LogMove(playerOne.MakeMove(1, 2));
            target.LogMove(playerOne.MakeMove(2, 2));
            Assert.AreEqual(true, target.CheckForWin());

            //Three Down the Left Side
            target = new BoardManager();
            target.LogMove(playerOne.MakeMove(0, 0));
            target.LogMove(playerOne.MakeMove(0, 1));
            target.LogMove(playerOne.MakeMove(0, 2));
            Assert.AreEqual(true, target.CheckForWin());

            //Three Down the Middle
            target = new BoardManager();
            target.LogMove(playerOne.MakeMove(1, 0));
            target.LogMove(playerOne.MakeMove(1, 1));
            target.LogMove(playerOne.MakeMove(1, 2));
            Assert.AreEqual(true, target.CheckForWin());

            //Three Down the Right Side
            target = new BoardManager();
            target.LogMove(playerOne.MakeMove(1, 0));
            target.LogMove(playerOne.MakeMove(1, 1));
            target.LogMove(playerOne.MakeMove(1, 2));
            Assert.AreEqual(true, target.CheckForWin());

            //Three In A Slash
            target = new BoardManager();
            target.LogMove(playerOne.MakeMove(0, 2));
            target.LogMove(playerOne.MakeMove(1, 1));
            target.LogMove(playerOne.MakeMove(2, 0));
            Assert.AreEqual(true, target.CheckForWin());

            //Three In A Backslash
            target = new BoardManager();
            target.LogMove(playerOne.MakeMove(0, 0));
            target.LogMove(playerOne.MakeMove(1, 1));
            target.LogMove(playerOne.MakeMove(2, 2));
            Assert.AreEqual(true, target.CheckForWin());
        }

        [TestMethod()]
        public void CheckForWinShouldReturnTrueIfThereAreThreeOsInARow()
        {
            //Three Across the Top
            BoardManager target = new BoardManager();
            HumanPlayer playerOne = new HumanPlayer('o');
            target.LogMove(playerOne.MakeMove(0, 0));
            target.LogMove(playerOne.MakeMove(1, 0));
            target.LogMove(playerOne.MakeMove(2, 0));
            Assert.AreEqual(true, target.CheckForWin());

            //Three Across the Middle
            target = new BoardManager();
            target.LogMove(playerOne.MakeMove(0, 1));
            target.LogMove(playerOne.MakeMove(1, 1));
            target.LogMove(playerOne.MakeMove(2, 1));
            Assert.AreEqual(true, target.CheckForWin());

            //Three Across the Bottom
            target = new BoardManager();
            target.LogMove(playerOne.MakeMove(0, 2));
            target.LogMove(playerOne.MakeMove(1, 2));
            target.LogMove(playerOne.MakeMove(2, 2));
            Assert.AreEqual(true, target.CheckForWin());

            //Three Down the Left Side
            target = new BoardManager();
            target.LogMove(playerOne.MakeMove(0, 0));
            target.LogMove(playerOne.MakeMove(0, 1));
            target.LogMove(playerOne.MakeMove(0, 2));
            Assert.AreEqual(true, target.CheckForWin());

            //Three Down the Middle
            target = new BoardManager();
            target.LogMove(playerOne.MakeMove(1, 0));
            target.LogMove(playerOne.MakeMove(1, 1));
            target.LogMove(playerOne.MakeMove(1, 2));
            Assert.AreEqual(true, target.CheckForWin());

            //Three Down the Right Side
            target = new BoardManager();
            target.LogMove(playerOne.MakeMove(1, 0));
            target.LogMove(playerOne.MakeMove(1, 1));
            target.LogMove(playerOne.MakeMove(1, 2));
            Assert.AreEqual(true, target.CheckForWin());

            //Three In A Slash
            target = new BoardManager();
            target.LogMove(playerOne.MakeMove(0, 2));
            target.LogMove(playerOne.MakeMove(1, 1));
            target.LogMove(playerOne.MakeMove(2, 0));
            Assert.AreEqual(true, target.CheckForWin());

            //Three In A Backslash
            target = new BoardManager();
            target.LogMove(playerOne.MakeMove(0, 0));
            target.LogMove(playerOne.MakeMove(1, 1));
            target.LogMove(playerOne.MakeMove(2, 2));
            Assert.AreEqual(true, target.CheckForWin());
        }

        [TestMethod()]
        public void BoardManagerShouldKnowIfThereIsATie()
        {
            BoardManager target = new BoardManager();
            HumanPlayer playerOne = new HumanPlayer('X');
            ComputerPlayer playerTwo = new ComputerPlayer('O');

            target.LogMove(playerOne.MakeMove(1, 1));
            target.LogMove(playerTwo.MakeMove(0, 0));
            target.LogMove(playerOne.MakeMove(0, 1));
            target.LogMove(playerTwo.MakeMove(2, 1));
            target.LogMove(playerOne.MakeMove(0, 2));
            target.LogMove(playerTwo.MakeMove(2, 0));
            target.LogMove(playerOne.MakeMove(1, 0));
            target.LogMove(playerTwo.MakeMove(1, 2));
            target.LogMove(playerOne.MakeMove(2, 2));

            Assert.AreEqual(true, target.CheckForTie());
        }
    }
}
