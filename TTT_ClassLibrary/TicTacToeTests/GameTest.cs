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
            Game target = new Game(new HumanPlayer('X'), new HumanPlayer('Y'), new BoardChecker(), new BoardManager(), 3);
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

            target = new Game(new HumanPlayer('X'), new HumanPlayer('O'), new BoardChecker(), new BoardManager(), 3);
            target.RewritePlayer(new ComputerPlayer('O'));
            Assert.AreEqual(new HumanPlayer('X'), target.xPlayer);

            target = new Game(new HumanPlayer('X'), new HumanPlayer('O'), new BoardChecker(), new BoardManager(), 3);
            target.RewritePlayer(new ComputerPlayer('X'));
            Assert.AreEqual(new HumanPlayer('O'), target.oPlayer);

            target = new Game(new HumanPlayer('X'), new HumanPlayer('Y'), new BoardChecker(), new BoardManager(), 3);
            Assert.AreEqual(new HumanPlayer('O'), target.oPlayer);
        }

        [TestMethod()]
        public void ResetGameShouldBlankAllValues()
        {
            Game target = new Game(new HumanPlayer('X'), new HumanPlayer('O'), new BoardChecker(), new BoardManager(), 3);
            target.ResetGame(3);
            Assert.AreEqual(null, target.xPlayer);
            Assert.AreEqual(null, target.oPlayer);
        }

        [TestMethod()]
        public void GameShouldBeAbleToMakeMovesOnBehalfOfItsPlayers()
        {
            Game target = new Game(new HumanPlayer('X'), new HumanPlayer('O'), new BoardChecker(), new BoardManager(), 3);
            target.LogMove(target.XPlayerMove(1, 1));
            char actual = target.board.boardArray[1, 1];
            char expected = 'X';
            target.LogMove(target.OPlayerMove(2, 2));
            actual = target.board.boardArray[2, 2];
            expected = 'O';
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GameShouldBeAbleToLogMoves()
        {
            Game target = new Game(new HumanPlayer('X'), new HumanPlayer('O'), new BoardChecker(), new BoardManager(), 3);
            target.LogMove(target.XPlayerMove(1,1));
        }

        [TestMethod()]
        public void GameShouldBeAbleToCheckAMovesValidity()
        {
            Game target = new Game(new HumanPlayer('X'), new HumanPlayer('O'), new BoardChecker(), new BoardManager(), 3);
            target.LogMove(target.XPlayerMove(1,1));
            bool actual = target.IsMoveValid(target.LogMove(target.OPlayerMove(1,1)));
            bool expected = false;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GameShouldHaveTwoAIs()
        {
            Game target = new Game(new HumanPlayer(), new HumanPlayer(), new BoardChecker(), new BoardManager(), 3);
            Assert.AreEqual(null, target.XAI);
            Assert.AreEqual(null, target.OAI);

            target = new Game(new HumanPlayer(), new ComputerPlayer(), new BoardChecker(), new BoardManager(), 3);
            Assert.AreEqual(null, target.XAI);
            Assert.AreEqual(new ComputerAI('X', 'O'), target.OAI);

            target = new Game(new ComputerPlayer(), new HumanPlayer(), new BoardChecker(), new BoardManager(), 3);
            Assert.AreEqual(null, target.OAI);
            Assert.AreEqual(new ComputerAI('O', 'X'), target.XAI);

            target = new Game(new ComputerPlayer(), new ComputerPlayer(), new BoardChecker(), new BoardManager(), 3);
            Assert.AreEqual(new ComputerAI('O', 'X'), target.XAI);
            Assert.AreEqual(new ComputerAI('X', 'O'), target.OAI);
        }

        [TestMethod()]
        public void GameShouldBeAbleToGetBoardArray()
        {
            Game target = new Game(new HumanPlayer(), new HumanPlayer());
            char[,] actual = target.GetBoard();
            char[,] expected = new char[3, 3];
            CollectionAssert.AreEqual(expected, actual);
            target.LogMove(target.XPlayerMove(1, 1));
            expected[1, 1] = 'X';
            CollectionAssert.AreEqual(expected, actual);
            
        }

        [TestMethod()]
        public void GameShouldBeAbleToLogAIMoves()
        {
            Game target = new Game(new ComputerPlayer(), new ComputerPlayer());
            CreatedMove XRandomMove = target.LogMove(target.XAIRandomMove());
            char actual = target.GetBoard()[XRandomMove.yAxis, XRandomMove.xAxis];
            char expected = 'X';
            Assert.AreEqual(expected, actual);

            CreatedMove ORandomMove = target.LogMove(target.OAIRandomMove());
            actual = target.GetBoard()[ORandomMove.yAxis, ORandomMove.xAxis];
            expected = 'O';
            Assert.AreEqual(expected, actual);
        }
    }
}
