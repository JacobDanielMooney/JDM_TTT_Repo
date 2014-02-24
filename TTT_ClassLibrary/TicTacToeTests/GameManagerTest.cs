using TTT_ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TicTacToeTests
{
    
    [TestClass()]
    public class GameManagerTest
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
        public void GameManagerConstructorTest()
        {
            GameManager target = new GameManager();
        }

        [TestMethod()]
        public void GameManagerShouldBeAbleToMakeAGame()
        {
            GameManager target = new GameManager();
            Game actual = target.MakeGame();
            Game expected = new Game();
            AreTwoGamesEqual(actual, expected);
        }

        [TestMethod()]
        public void StartTest()
        {
            GameManager target = new GameManager();
            target.StartGame();
        }

        [TestMethod()]
        public void ShouldBeAbleToTakeGameParamsFromPresenter()
        {
            GameManager target = new GameManager();
            target.MakeGame("computers");
            Game actual = target.game;
            Game expected = new Game(new ComputerPlayer(), new ComputerPlayer());
            AreTwoGamesEqual(actual, expected);

            target.MakeGame("human");
            actual = target.game;
            expected = new Game(new HumanPlayer(), new HumanPlayer());
            AreTwoGamesEqual(actual, expected);

            target.MakeGame("computer");
            actual = target.game;
            expected = new Game(new HumanPlayer(), new ComputerPlayer());
        }

        [TestMethod()]
        public void ShouldBeAbleToGetTupleOfNextMove()
        {
            GameManager target = new GameManager();
            target.MakeGame("computer");
            Tuple<int,int> actual = target.GetNextTuple();
            Tuple<int, int> expected = new Tuple<int, int>(0, 0);
            Assert.AreEqual(expected, actual);
            target.LogMove(actual);
            actual = target.GetNextTuple();
            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod()]
        public void ShouldBeAbleToLogAMove()
        {
            GameManager target = new GameManager();
            target.MakeGame("computer");
            Tuple<int, int> XatOneOne = new Tuple<int, int>(1, 1);
            target.LogMove(XatOneOne);
            char actual = target.game.board.boardArray[1, 1];
            char expected = 'X';
            Assert.AreEqual(expected, actual);
            Tuple<int, int> OatZeroZero = new Tuple<int, int>(0, 0);
            target.LogMove(OatZeroZero);
            actual = target.game.board.boardArray[0, 0];
            expected = 'O';
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GameManagerShouldBeAbleToReportOnWinsAndTies()
        {
            GameManager target = new GameManager();
            target.MakeGame("human");
            target.game.board.ForceMove(new Tuple<int, int>(0, 0), 'X');
            target.game.board.ForceMove(new Tuple<int, int>(1, 0), 'X');
            target.game.board.ForceMove(new Tuple<int, int>(2, 0), 'X');
            target.ReportGameEnd();
            
            target = new GameManager();
            target.MakeGame("human");
            target.game.board.ForceMove(new Tuple<int, int>(0, 0), 'O');
            target.game.board.ForceMove(new Tuple<int, int>(1, 0), 'O');
            target.game.board.ForceMove(new Tuple<int, int>(2, 0), 'O');
            target.ReportGameEnd();
            
            target = new GameManager();
            target.MakeGame("human");
            target.game.board.LogMove(new Tuple<int, int>(1, 1));
            target.game.board.LogMove(new Tuple<int, int>(0, 0));
            target.game.board.LogMove(new Tuple<int, int>(0, 1));
            target.game.board.LogMove(new Tuple<int, int>(2, 1));
            target.game.board.LogMove(new Tuple<int, int>(0, 2));
            target.game.board.LogMove(new Tuple<int, int>(2, 0));
            target.game.board.LogMove(new Tuple<int, int>(1, 0));
            target.game.board.LogMove(new Tuple<int, int>(1, 2));
            target.game.board.LogMove(new Tuple<int, int>(2, 2));
            target.ReportGameEnd();


        }

        [TestMethod()]
        public void StartGameTest()
        {
            GameManager target = new GameManager();
            target.StartGame();
        }

        public void AreTwoGamesEqual(Game actual, Game expected)
        {
            Assert.AreEqual(actual.xPlayer, expected.xPlayer);
            Assert.AreEqual(actual.oPlayer, expected.oPlayer);
            CollectionAssert.AreEqual(actual.board.boardArray, expected.board.boardArray);
        }
    }
}
