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
        public void ShouldBeAbleToTakeGameParamsFromPresenter()
        {
            GameManager target = new GameManager();
            target.MakeGame(target.presenter.WelcomeAndAskForGameParams());
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

        public void AreTwoGamesEqual(Game actual, Game expected)
        {
            Assert.AreEqual(actual.xPlayer, actual.xPlayer);
            Assert.AreEqual(expected.oPlayer, expected.oPlayer);
            CollectionAssert.AreEqual(actual.board.boardArray, expected.board.boardArray);
        }
    }
}
