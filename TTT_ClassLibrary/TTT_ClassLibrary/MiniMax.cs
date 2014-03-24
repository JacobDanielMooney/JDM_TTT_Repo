using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TTT_ClassLibrary
{
    public class MiniMax
    {
        public Tuple<int,int> GetMove(char[,] boardState, char playerID)
        {
            List<Move> possibleMoves = new List<Move>();
            for (int y = 0; y < boardState.GetLength(0); y++)
            {
                for (int x = 0; x < boardState.GetLength(0); x++)
                {
                    char[,] newBoardState = NewBoardState(boardState);
                    if (newBoardState[y, x] == '\0')
                    {
                        newBoardState[y, x] = playerID;
                        char nextPlayerID;
                        if (playerID == 'X')
                        {
                            nextPlayerID = 'O';
                        }
                        else
                        {
                            nextPlayerID = 'X';
                        }
                        possibleMoves.Add(HighScoreOfSquare(x, y, newBoardState, 1, nextPlayerID));
                    }

                }
            }

            int maxScore = possibleMoves.Max<Move>().score;
            List<Move> maxMoves = new List<Move>();
            foreach (Move m in possibleMoves)
            {
                if (m.score == maxScore)
                {
                    maxMoves.Add(m);
                }
            }

            foreach (Move m in maxMoves)
            {
                if (m.coordinates.Item1 == 1 && m.coordinates.Item2 == 1)
                {
                    return m.coordinates;
                }
            }

            return possibleMoves.Max<Move>().coordinates;
        }

        public Move HighScoreOfSquare(int xCoord, int yCoord, char[,] boardState, int depth, char playerID)
        {
            if (Tie(boardState))
            {
                return new Move(0, xCoord, yCoord);
            }

            if (Win(boardState))
            {
                return new Move(GetScore(depth), xCoord, yCoord);
            }

            List<Move> childMoves = new List<Move>();

            for (int y = 0; y < boardState.GetLength(0); y++)
            {
                for (int x = 0; x < boardState.GetLength(0); x++)
                {
                    char[,] newBoardState = NewBoardState(boardState);
                    if (newBoardState[y, x] == '\0')
                    {
                        newBoardState[y, x] = playerID;
                        char nextPlayerID;
                        if (playerID == 'X')
                        {
                            nextPlayerID = 'O';
                        }
                        else
                        {
                            nextPlayerID = 'X';
                        }

                        int nextDepth = depth + 1;
                        childMoves.Add(HighScoreOfSquare(x, y, newBoardState, nextDepth, nextPlayerID));
                    }
                }
            }

            if (depth % 2 == 0)
            {
                return new Move(childMoves.Max<Move>().score, xCoord, yCoord);
            }
            else
            {
                return new Move(childMoves.Min<Move>().score, xCoord, yCoord);
            }
        }

        public int GetScore(int depth)
        {
            if (depth % 2 == 1)
            {
                return 1000 - depth;
            }
            else
            {
                return -1000 + depth;
            }
        }

        public char[,] NewBoardState(char[,] oldBoard)
        {
            char[,] newBoard = new char[oldBoard.GetLength(0), oldBoard.GetLength(0)];
            for (int y = 0; y < oldBoard.GetLength(0); y++)
            {
                for (int x = 0; x < oldBoard.GetLength(0); x++)
                {
                    newBoard[y, x] = oldBoard[y, x];
                }
            }
            return newBoard;
        }

        public bool Tie(char[,] boardState)
        {
            if (Win(boardState) == true)
            {
                return false;
            }

            foreach (char c in boardState)
            {
                if (c == '\0')
                {
                    return false;
                }
            }

            return true;
        }

        public bool Win(char[,] boardState)
        {
            for (int i = 0; i < 3; i++)
            {
                if (CheckRowForWin(i, 'X', boardState) >= 3 ||
                    CheckColumnForWin(i, 'X', boardState) >= 3 ||
                    CheckRowForWin(i, 'O', boardState) >= 3 ||
                    CheckColumnForWin(i, 'O', boardState) >= 3)
                {
                    return true;
                }
            }
            if (CheckSlashForWin('X', boardState) >= 3 ||
                CheckBackSlashForWin('X', boardState) >= 3 ||
                CheckSlashForWin('O', boardState) >= 3 ||
                CheckBackSlashForWin('O', boardState) >= 3)
            {
                return true;
            }
            return false;
        }

        private int CheckRowForWin(int row, char checkFor, char[,] boardState)
        {
            int tally = 0;
            for (int xAxisCounter = 0; xAxisCounter < 3; xAxisCounter++)
            {
                if (boardState[row, xAxisCounter] == checkFor)
                {
                    tally++;
                }
            }
            return tally;
        }

        private int CheckColumnForWin(int column, char checkFor, char[,] boardState)
        {
            int tally = 0;
            for (int yAxisCounter = 0; yAxisCounter < 3; yAxisCounter++)
            {
                if (boardState[yAxisCounter, column] == checkFor)
                {
                    tally++;
                }
            }
            return tally;
        }

        private int CheckSlashForWin(char checkFor, char[,] boardState)
        {
            int tally = 0;
            int xAxisIndex = 0;
            int yAxisIndex = 2;
            while (xAxisIndex < 3)
            {
                if (boardState[yAxisIndex, xAxisIndex] == checkFor)
                {
                    tally++;
                }
                xAxisIndex++;
                yAxisIndex--;
            }
            return tally;
        }

        private int CheckBackSlashForWin(char checkFor, char[,] boardState)
        {
            int tally = 0;
            int xAxisIndex = 0;
            int yAxisIndex = 0;
            while (xAxisIndex < 3)
            {
                if (boardState[yAxisIndex, xAxisIndex] == checkFor)
                {
                    tally++;
                }
                xAxisIndex++;
                yAxisIndex++;
            }
            return tally;
        }
    }
}
