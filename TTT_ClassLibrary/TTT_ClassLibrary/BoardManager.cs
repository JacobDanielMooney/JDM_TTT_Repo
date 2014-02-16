using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TTT_ClassLibrary
{
    public class BoardManager
    {
        public char[,] boardArray = new char[3,3];

        public BoardManager()
        {
        }

        public char[,] CreateNewBoard(int boardSize)
        {
            boardArray = new char[boardSize, boardSize];
            return boardArray;
        }

        public CreatedMove LogMove(CreatedMove move)
        {
            if (boardArray[move.yAxis, move.xAxis] == '\0')
            {
                boardArray[move.yAxis, move.xAxis] = move.plyrIdentity;
            }
            else
            {
                return new CreatedMove(move.xAxis, move.yAxis, 'I');
            }
            return move;
        }

        public bool IsMoveValid(CreatedMove move)
        {
            if (boardArray[move.yAxis, move.xAxis] == '\0')
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckForTie(char[,] boardArray)
        {
            if (CheckForWin() == true)
            {
                return false;
            }

            foreach (char c in boardArray)
            {
                if (c == '\0')
                {
                    return false;
                }
            }

            return true;
        }

        public bool CheckForWin()
        {
            for (int i = 0; i < 3; i++)
            {
                if (CheckRowForWin(i, 'X') >= 3 ||
                    CheckRowForWin(i, 'O') >= 3 ||
                    CheckColumnForWin(i, 'X') >= 3 ||
                    CheckColumnForWin(i, 'O') >= 3)
                {
                    return true;
                }
            }
            if (CheckSlashForWin('X') >= 3 ||
                CheckSlashForWin('O') >= 3)
            {
                return true;
            }
            if (CheckBackSlashForWin('X') >= 3 ||
                CheckBackSlashForWin('O') >= 3)
            {
                return true;
            }
            return false;
        }

        public int CheckRowForWin(int row, char checkFor)
        {
            int tally = 0;
            for (int xAxisCounter = 0; xAxisCounter < 3; xAxisCounter++)
            {
                if (boardArray[row, xAxisCounter] == checkFor)
                {
                    tally++;
                }
            }
            return tally;
        }

        public int CheckColumnForWin(int column, char checkFor)
        {
            int tally = 0;
            for (int yAxisCounter = 0; yAxisCounter < 3; yAxisCounter++)
            {
                if (boardArray[yAxisCounter, column] == checkFor)
                {
                    tally++;
                }
            }
            return tally;
        }

        public int CheckSlashForWin(char checkFor)
        {
            int tally = 0;
            int xAxisIndex = 0;
            int yAxisIndex = 2;
            while (xAxisIndex < 3)
            {
                if (boardArray[yAxisIndex, xAxisIndex] == checkFor)
                {
                    tally++;
                }
                xAxisIndex++;
                yAxisIndex--;
            }
            return tally;
        }

        public int CheckBackSlashForWin(char checkFor)
        {
            int tally = 0;
            int xAxisIndex = 0;
            int yAxisIndex = 0;
            while (xAxisIndex < 3)
            {
                if (boardArray[yAxisIndex, xAxisIndex] == checkFor)
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
