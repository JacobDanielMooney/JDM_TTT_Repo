using TTT_ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TicTacToeTests
{
    
    [TestClass()]
    public class ComputerAITest
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
        public void ComputerAIConstructorTest()
        {
            BoardManager board = new BoardManager();
            HumanPlayer playerOne = new HumanPlayer();
            board.LogMove(playerOne.MakeMove(0, 0));

            ComputerAI target = new ComputerAI(board.boardArray, playerOne.identity);

            char[,] expected = new char[3, 3];
            expected[0,0] = 'X';
            char[,] actual = target.currentBoardState;

            CollectionAssert.AreEqual(expected, actual);

            Assert.AreEqual('X', target.enemyIdentity);

        }

        [TestMethod()]
        public void WeighOpponentPresenceTest()
        {
            BoardManager board = new BoardManager();
            HumanPlayer playerOne = new HumanPlayer();
            ComputerPlayer playerTwo = new ComputerPlayer('O');
            board.LogMove(playerOne.MakeMove(0, 0));
            board.LogMove(playerTwo.MakeMove(1, 1));
            board.LogMove(playerOne.MakeMove(1, 0));

            ComputerAI target = new ComputerAI(board.boardArray, playerOne.identity);

            target.WeighOpponentPresence(board.boardArray, 1, 0);
        }

        [TestMethod()]
        public void GetNextMoveShouldReturnProperMove()
        {
            BoardManager board = new BoardManager();
            HumanPlayer playerOne = new HumanPlayer();
            board.LogMove(playerOne.MakeMove(0, 0));

            ComputerAI target = new ComputerAI(board.boardArray, playerOne.identity);

            CreatedMove expectedMove = new CreatedMove(1, 1, 'O');
            CreatedMove actualMove = target.GetNextMove(board.boardArray);
            //Assert.AreEqual(expectedMove, actualMove);
        }
    }
}
