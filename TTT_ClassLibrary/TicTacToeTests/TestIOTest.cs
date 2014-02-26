using TTT_ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TicTacToeTests
{

    [TestClass()]
    public class TestIOTest
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
        public void InputTest()
        {
            PresentationManager target = new PresentationManager(new TestIO());
            target.IO.Input();
            TestIO io = (TestIO)target.IO;
            io.desiredInString = "Hello World";
            string actual = io.Input();
            string expected = "Hello World";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void OutputTest()
        {
            PresentationManager target = new PresentationManager(new TestIO());
            target.IO.Output("testString");
            TestIO io = (TestIO)target.IO;
            string actual = io.lastOutString;
            string expected = "testString";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void OutputLnTest()
        {
            PresentationManager target = new PresentationManager(new TestIO());
            target.IO.OutputLn("testString");
            TestIO io = (TestIO)target.IO;
            string actual = io.lastOutString;
            string expected = "testString";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void fauxInputTest()
        {
            GameManager testManager = new GameManager(new PresentationManager(new TestIO()));
            TestIO io = (TestIO)testManager.presenter.IO;
            io.desiredInString = "human";
            testManager.MakeGame(testManager.presenter.WelcomeAndAskForGameParams());
            Assert.AreEqual(testManager.game.xPlayer.GetType(), typeof(HumanPlayer));
            Assert.AreEqual(testManager.game.oPlayer.GetType(), typeof(HumanPlayer));
            testManager.game.board.ForceMove(new Tuple<int,int>(0,0), 'X');
            testManager.game.board.ForceMove(new Tuple<int,int>(1,0), 'X');
            testManager.game.board.ForceMove(new Tuple<int,int>(2,0), 'X');
            testManager.ReportGameEnd();
            Assert.AreEqual("X's Win!", io.lastOutString);
        }
    }
}
