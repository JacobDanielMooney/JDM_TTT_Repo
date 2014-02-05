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
        public void GameManagerEmptyConstructorTest()
        {
            GameManager target = new GameManager();
        }

        [TestMethod()]
        public void GameManagerFullConstructorTest()
        {
            GameManager target = new GameManager(new HumanPlayer('X'), new HumanPlayer('Y'), 3);
        }

        [TestMethod()]
        public void ShouldBeAbleToAddPlayers()
        {
            GameManager target = new GameManager();
            target.AddPlayer(new HumanPlayer('X'));

            Player actual = target.xPlayer;
            Player expected = new HumanPlayer('X');

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void AddPlayerShouldNotOverwritePlayers()
        {
            GameManager target = new GameManager();
            target.AddPlayer(new HumanPlayer('X'));
            target.AddPlayer(new HumanPlayer('O'));

            Player actual = target.xPlayer;
            Player expected = new HumanPlayer('X');

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void AddPlayerWontInputMoreThanTwoPlayers()
        {
            GameManager target = new GameManager();
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
            GameManager target = new GameManager();
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
            GameManager target = new GameManager();
            target.AddPlayer(new HumanPlayer('X'));
            target.AddPlayer(new HumanPlayer('X'));

            Assert.AreEqual(null, target.oPlayer);

            target = new GameManager(new HumanPlayer('X'), new HumanPlayer('O'), 3);
            target.RewritePlayer(new ComputerPlayer('O'));
            Assert.AreEqual(new HumanPlayer('X'), target.xPlayer);

            target = new GameManager(new HumanPlayer('X'), new HumanPlayer('O'), 3);
            target.RewritePlayer(new ComputerPlayer('X'));
            Assert.AreEqual(new HumanPlayer('O'), target.oPlayer);
        }

        [TestMethod()]
        public void ResetGameShouldBlankAllValues()
        {
            GameManager target = new GameManager(new HumanPlayer('X'), new HumanPlayer('O'), 3);
            target.ResetGame(3);
            Assert.AreEqual(null, target.xPlayer);
            Assert.AreEqual(null, target.oPlayer);
        }
    }
}
