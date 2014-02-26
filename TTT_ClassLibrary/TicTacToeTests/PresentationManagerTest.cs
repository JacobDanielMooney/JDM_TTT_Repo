using TTT_ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TicTacToeTests
{

    [TestClass()]
    public class PresentationManagerTest
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
        public void PresentationManagerShouldBeAbleToAskAboutGameSettings()
        {
            PresentationManager target = new PresentationManager();
            string actual = target.WelcomeAndAskForGameParams();
            string expected = "computers";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ShouldBeAbleToAskForFirstOrSecond()
        {
            PresentationManager target = new PresentationManager();
            bool actual = target.HumanGoesFirst();
            bool expected = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void PresentationManagerShouldBeAbleToAskForCoordinates()
        {
            PresentationManager target = new PresentationManager();
            Tuple<int, int> actual = target.PromptCoordinates();
            Tuple<int, int> expected = new Tuple<int, int>(0, 0);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void PresentationManagerShouldBeAbleToPromptForRestart()
        {
            PresentationManager target = new PresentationManager();
            bool actual = target.PlayAgain();
            bool expected = false;
            Assert.AreEqual(expected, actual);

        }

        [TestMethod()]
        public void PresentationManagerShouldBeAbleToPrintTheBoard()
        {
            PresentationManager target = new PresentationManager();
            HumanPlayer playerOne = new HumanPlayer('X');
            HumanPlayer playerTwo = new HumanPlayer('O');
            Game game = new Game(playerOne, playerTwo, new BoardManager());
            target.PrintBoard(game.board.boardArray);
            game.board.LogMove(new Tuple<int, int>(1, 1));
            target.PrintBoard(game.board.boardArray);
            game.board.LogMove(new Tuple<int, int>(0, 0));
            target.PrintBoard(game.board.boardArray);
            game.board.LogMove(new Tuple<int, int>(2, 1));
            target.PrintBoard(game.board.boardArray);
            game.board.LogMove(new Tuple<int, int>(1, 2));
            target.PrintBoard(game.board.boardArray);
        }
        
    }
}
