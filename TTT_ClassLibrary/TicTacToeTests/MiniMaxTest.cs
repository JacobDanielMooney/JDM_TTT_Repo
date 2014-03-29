using TTT_ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TicTacToeTests
{

    [TestClass()]
    public class MiniMaxTest
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
        public void CompCorrectlyIdentifiesTheWin()
        {
            char[,] givenBoard = new char[3, 3];
            givenBoard[0, 0] = 'O';
            givenBoard[0, 1] = 'O';
            givenBoard[2, 2] = 'X';
            givenBoard[2, 1] = 'X';
            MiniMax target = new MiniMax();
            Tuple<int,int> recievedMove = target.GetMove(givenBoard, 'O');
            Tuple<int,int> expectedMove = new Tuple<int,int>(2,0);
            Assert.AreEqual(expectedMove, recievedMove);
        }

        [TestMethod()]
        public void FirstMoveTest()
        {
            char[,] givenBoard = new char[3, 3];
            MiniMax target = new MiniMax();
            Tuple<int, int> recievedMove = target.GetMove(givenBoard, 'X');
            Tuple<int, int> expectedMove = new Tuple<int, int>(1, 1);
            Assert.AreEqual(expectedMove, recievedMove);
        }

        [TestMethod()]
        public void SpotTest()
        {
            char[,] givenBoard = new char[3, 3];
            MiniMax target = new MiniMax();
            givenBoard[1, 1] = 'X';
            givenBoard[0, 0] = 'O';
            givenBoard[0, 2] = 'X';
            givenBoard[2, 0] = 'O';
            Tuple<int, int> recievedMove = target.GetMove(givenBoard, 'X');
            Tuple<int, int> expectedMove = new Tuple<int, int>(0, 1);
            Assert.AreEqual(expectedMove, recievedMove);
        }

        [TestMethod()]
        public void CorrectlyTakesCorner()
        {
            char[,] givenBoard = new char[3, 3];
            MiniMax target = new MiniMax();
            givenBoard[1, 1] = 'X';
            Tuple<int, int> recievedMove = target.GetMove(givenBoard, 'O');
            Tuple<int, int> sideMoveOne = new Tuple<int, int>(1, 0);
            Tuple<int, int> sideMoveTwo = new Tuple<int, int>(0, 1);
            Tuple<int, int> sideMoveThree = new Tuple<int, int>(2, 1);
            Tuple<int, int> sideMoveFour = new Tuple<int, int>(1, 2);
            Assert.AreNotEqual(sideMoveOne, recievedMove);
            Assert.AreNotEqual(sideMoveTwo, recievedMove);
            Assert.AreNotEqual(sideMoveThree, recievedMove);
            Assert.AreNotEqual(sideMoveFour, recievedMove);
        }

        [TestMethod()]
        public void BestMaxScore()
        {
            MiniMax target = new MiniMax();
            int depth = 0;
            int expect = -1000;
            int actual = target.GetScore(depth);
            Assert.AreEqual(expect, actual);
        }

        [TestMethod()]
        public void BestMinScore()
        {
            MiniMax target = new MiniMax();
            int depth = 0;
            int expect = -1000;
            int actual = target.GetScore(depth);
            Assert.AreEqual(expect, actual);
        }

        [TestMethod()]
        public void BestMinAndMaxScoreAtDepth()
        {
            MiniMax target = new MiniMax();
            int depth = 5;
            int expect = 995;
            int actual = target.GetScore(depth);
            Assert.AreEqual(expect, actual);
            depth++;
            expect = -994;
            actual = target.GetScore(depth);
            Assert.AreEqual(expect, actual);
        }

        [TestMethod()]
        public void ReturnsScoreInFinalGameState()
        {
            MiniMax target = new MiniMax();
            int depth = 5;
            int expected = 995;
            char[,] givenBoard = new char[3,3];
            givenBoard[0,0] = 'X';
            givenBoard[2,0] = 'O';
            givenBoard[0,1] = 'X';
            givenBoard[2,1] = 'O';
            givenBoard[0,2] = 'X';
            int actual = 0;
            if (target.Win(givenBoard) == true)
            {
                actual = target.GetScore(depth);
            }
            Assert.AreEqual(expected, actual);

            givenBoard = returnTiedBoard();
            expected = 0;
            if (target.Tie(givenBoard))
            {
                actual = 0;
            }
            Assert.AreEqual(expected, actual);
            
        }

        [TestMethod()]
        public void GetMoveTest()
        {
            MiniMax target = new MiniMax();
            int depth = 7;
            char[,] givenBoard = new char[3, 3];
            givenBoard[0, 0] = 'X';
            givenBoard[0, 1] = 'X';
            givenBoard[0, 2] = 'X';
            Move returnedScore = target.HighScoreOfSquare(2, 0, givenBoard, depth, 'X');
            Assert.AreEqual(993, returnedScore.score);

            depth++;
            givenBoard[0, 0] = 'O';
            givenBoard[0, 1] = 'O';
            givenBoard[0, 2] = 'O';
            returnedScore = target.HighScoreOfSquare(2, 0, givenBoard, depth, 'O');
            Assert.AreEqual(-992, returnedScore.score);

            givenBoard = returnTiedBoard();
            returnedScore = returnedScore = target.HighScoreOfSquare(2, 2, givenBoard, depth, 'X');
            Assert.AreEqual(0, returnedScore.score);
        }

        public char[,] returnTiedBoard()
        {
            char[,] result = new char[3, 3]{{'Q','Q','Q'},
                                            {'Q','Q','Q'},
                                            {'Q','Q','Q'}};
            return result;

        }
    }
}
