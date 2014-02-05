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
        public void PresentationManagerShouldBeAbleToPromptUsers()
        {
            PresentationManager target = new PresentationManager();
            target.Send("Choose a mode:");
        }

        [TestMethod()]
        public void PresentationManagerShouldBeAbleToPrintTheBoard()
        {
            PresentationManager target = new PresentationManager();
            HumanPlayer playerOne = new HumanPlayer('X');
            HumanPlayer playerTwo = new HumanPlayer('O');
            GameManager game = new GameManager(playerOne, playerTwo, 3);
            target.PrintBoard(game.board.boardArray);
            game.board.LogMove(game.xPlayer.MakeMove(1, 1));
            target.PrintBoard(game.board.boardArray);
            game.board.LogMove(game.oPlayer.MakeMove(0, 0));
            target.PrintBoard(game.board.boardArray);
            game.board.LogMove(game.xPlayer.MakeMove(2, 0));
            target.PrintBoard(game.board.boardArray);
            game.board.LogMove(game.oPlayer.MakeMove(0, 2));
            target.PrintBoard(game.board.boardArray);
        }
        
    }
}
