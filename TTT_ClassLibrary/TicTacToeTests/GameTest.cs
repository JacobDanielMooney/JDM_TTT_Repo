using TTT_ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TicTacToeTests
{

    [TestClass()]
    public class GameTest
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
        public void GameManagerEmptyConstructorTest()
        {
            Game target = new Game();
        }

        [TestMethod()]
        public void GameManagerFullConstructorTest()
        {
            Game target = new Game(new HumanPlayer('X'), new HumanPlayer('Y'), new BoardManager());
        }

        [TestMethod()]
        public void ShouldBeAbleToAddPlayers()
        {
            Game target = new Game();
            target.AddPlayer(new HumanPlayer('X'));

            Player actual = target.xPlayer;
            Player expected = new HumanPlayer('X');

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void AddPlayerShouldNotOverwritePlayers()
        {
            Game target = new Game();
            target.AddPlayer(new HumanPlayer('X'));
            target.AddPlayer(new HumanPlayer('O'));

            Player actual = target.xPlayer;
            Player expected = new HumanPlayer('X');

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void AddPlayerWontInputMoreThanTwoPlayers()
        {
            Game target = new Game();
            target.AddPlayer(new HumanPlayer('X'));
            target.AddPlayer(new HumanPlayer('O'));
            target.AddPlayer(new ComputerPlayer('X'));

            Player notExpected = new ComputerPlayer('X');
            Assert.AreNotEqual(notExpected, target.xPlayer);
            Assert.AreNotEqual(notExpected, target.oPlayer);
        }

        [TestMethod()]
        public void RewritePlayerWillRewritePlayers()
        {
            Game target = new Game();
            target.AddPlayer(new HumanPlayer('X'));
            target.AddPlayer(new HumanPlayer('O'));
            target.RewritePlayer(new ComputerPlayer('X'));

            Player expected = new ComputerPlayer('X');

            Assert.AreEqual(expected, target.xPlayer);

            target.RewritePlayer(new ComputerPlayer('O'));
            expected = new ComputerPlayer('O');

            Assert.AreEqual(expected, target.oPlayer);
        }

        [TestMethod()]
        public void ShouldNotBeAbleToMakeTwoPlayersWithIdenticalIdentities()
        {
            Game target = new Game();
            target.AddPlayer(new HumanPlayer('X'));
            target.AddPlayer(new HumanPlayer('X'));

            Assert.AreEqual(null, target.oPlayer);

            target = new Game(new HumanPlayer('X'), new HumanPlayer('O'), new BoardManager());
            target.RewritePlayer(new ComputerPlayer('O'));
            Assert.AreEqual(new HumanPlayer('X'), target.xPlayer);

            target = new Game(new HumanPlayer('X'), new HumanPlayer('O'), new BoardManager());
            target.RewritePlayer(new ComputerPlayer('X'));
            Assert.AreEqual(new HumanPlayer('O'), target.oPlayer);

            target = new Game(new HumanPlayer('X'), new HumanPlayer('O'), new BoardManager());
            Assert.AreEqual(new HumanPlayer('O'), target.oPlayer);
        }

        [TestMethod()]
        public void ResetGameShouldBlankAllValues()
        {
            Game target = new Game(new HumanPlayer('X'), new HumanPlayer('O'), new BoardManager());
            target.LogMove(new Tuple<int,int>(1,1));
            target.LogMove(new Tuple<int,int>(1,1));
            target.ResetGame();
            Assert.AreEqual(null, target.xPlayer);
            Assert.AreEqual(null, target.oPlayer);
            CollectionAssert.AreEqual(new char[3, 3], target.board.boardArray);
        }

        [TestMethod()]
        public void NextMoveShouldCallMakeMoveOfAppropriatePlayer()
        {
            Game target = new Game(new HumanPlayer('X'), new ComputerPlayer('O'));
            Tuple<int,int> actual = target.NextMove();
            Tuple<int,int> expected = null;
            Assert.AreEqual(expected, actual);
            target.LogMove(new Tuple<int, int>(1, 1));
            actual = target.NextMove();
            Tuple<int, int> notExpected = null;
            Assert.AreNotEqual(notExpected, actual);
        }

        [TestMethod()]
        public void GameShouldBeAbleToLogMoves()
        {
            Game target = new Game(new HumanPlayer('X'), new HumanPlayer('O'), new BoardManager());
            target.LogMove(new Tuple<int,int>(1,1));
            char actual = target.board.boardArray[1, 1];
            char expected = 'X';
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GameShouldBeAbleToForceMovesForInactivePlayers()
        {
            Game target = new Game(new HumanPlayer('X'), new HumanPlayer('O'));
            target.ForceMove();
        }

        [TestMethod()]
        public void GameShouldBeAbleToCheckAMovesValidity()
        {
            Game target = new Game(new HumanPlayer('X'), new HumanPlayer('O'), new BoardManager());
            target.LogMove(new Tuple<int, int>(1, 1));
            bool actual = target.IsMoveValid(new Tuple<int,int>(1,1));
            bool expected = false;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GameShouldBeAbleToGetBoardArray()
        {
            Game target = new Game(new HumanPlayer(), new HumanPlayer());
            char[,] actual = target.GetBoard();
            char[,] expected = new char[3, 3];
            CollectionAssert.AreEqual(expected, actual);
            target.LogMove(new Tuple<int, int>(1, 1));
            expected[1, 1] = 'X';
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GameShouldKnowWhoIsActivePlayer()
        {
            Game target = new Game(new HumanPlayer(), new ComputerPlayer());
            char actual = target.GetActivePlayerID();
            char expected = 'X';
            Assert.AreEqual(expected, actual);
            target.LogMove(new Tuple<int, int>(1, 1));
            actual = target.GetActivePlayerID();
            expected = 'O';
            Assert.AreEqual(expected, actual);
        }
    }
}
