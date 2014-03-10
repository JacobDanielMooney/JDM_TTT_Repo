using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TTT_ClassLibrary
{
    public class MiniMax
    {
        public Move GetMove(int depth, char[,] boardState, char playerID)
        {
            if (CheckForTie(boardState))
            {
                return new Move(depth, 0);
            }
            else if (CheckForWin(boardState) != '\0')
            {
                if (depth % 2 == 1)
                {
                    return new Move(depth, 1);
                }
                else
                {
                    return new Move(depth, -1);
                }
            }
            else
            {
                List<Move> possibleMoves = new List<Move>();
                for (int y = 0; y < boardState.GetLength(0); y++)
                {
                    for (int x = 0; x < boardState.GetLength(0); x++)
                    {
                        char[,] nextBoardState = NewBoardState(boardState);
                        if (nextBoardState[y, x] == '\0')
                        {
                            nextBoardState[y, x] = playerID;
                            char nextID;
                            if (playerID == 'X')
                            {
                                nextID = 'O';
                            }
                            else
                            {
                                nextID = 'X';
                            }
                            possibleMoves.Add(GetMove(depth + 1, nextBoardState, nextID));
                        }
                    }
                }
                if (depth % 2 == 0)
                {
                    return possibleMoves.Max<Move>();
                }
                else
                {
                    return possibleMoves.Min<Move>();
                }
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

        public bool CheckForTie(char[,] boardState)
        {
            if (CheckForWin(boardState) != '\0')
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

        public char CheckForWin(char[,] boardState)
        {
            for (int i = 0; i < 3; i++)
            {
                if (CheckRowForWin(i, 'X', boardState) >= 3 ||
                    CheckColumnForWin(i, 'X', boardState) >= 3)
                {
                    return 'X';
                }

                if (CheckRowForWin(i, 'O', boardState) >= 3 ||
                    CheckColumnForWin(i, 'O', boardState) >= 3)
                {
                    return 'O';
                }
            }
            if (CheckSlashForWin('X', boardState) >= 3 ||
                CheckBackSlashForWin('X', boardState) >= 3)
            {
                return 'X';
            }
            if (CheckSlashForWin('O', boardState) >= 3 ||
                CheckBackSlashForWin('O', boardState) >= 3)
            {
                return 'O';
            }
            return '\0';
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
