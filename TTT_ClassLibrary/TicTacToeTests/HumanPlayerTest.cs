using TTT_ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TicTacToeTests
{
    [TestClass()]
    public class HumanPlayerTest
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
        public void ConstructorShouldDefaultToX()
        {
            HumanPlayer playerOne = new HumanPlayer();
            Assert.AreEqual(playerOne.identity, 'X');
        }

        [TestMethod()]
        public void ShouldBeAbleToCreatePlayersForO()
        {
            HumanPlayer playerOne = new HumanPlayer('O');
            Assert.AreEqual(playerOne.identity, 'O');
        }

        [TestMethod()]
        public void MakeMoveShouldMakeACreatedMove()
        {
            HumanPlayer playerOne = new HumanPlayer();
            CreatedMove actual = playerOne.MakeMove(2, 1);
            CreatedMove expected = new CreatedMove(2, 1, 'X');
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void AnnounceHMNWinnerTest()
        {
            HumanPlayer target = new HumanPlayer("Marston");
            string expected = "Marston the Human won!";
            string actual = target.AnnounceWinner();
            Assert.AreEqual(expected, actual);
        }
    }
}
