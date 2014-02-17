using TTT_ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TicTacToeTests
{
    [TestClass()]
    public class ComputerPlayerTest
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
        public void MakeMoveShouldGetRandomMoveOfMovesAvailable()
        {
            BoardManager board = new BoardManager();
            ComputerPlayer playerTwo = new ComputerPlayer('O');
            board.LogMove(new Tuple<int,int>(1,1));
            Tuple<int,int> playerChoice = playerTwo.MakeMove(board.boardArray);
            CreatedMove actual = new CreatedMove(playerChoice.Item1, playerChoice.Item2,playerTwo.identity);
            CreatedMove notExpected = new CreatedMove(1, 1, 'O');
            Assert.IsTrue(actual.xAxis >= 0 && actual.xAxis <= 2);
            Assert.IsTrue(actual.yAxis >= 0 && actual.yAxis <= 2);
            Assert.AreNotEqual(notExpected, actual);
        }
    }
}
