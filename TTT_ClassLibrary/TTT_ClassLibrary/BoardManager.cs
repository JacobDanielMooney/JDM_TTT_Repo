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

        public char[,] CreateNewBoard()
        {
            boardArray = new char[3, 3];
            return boardArray;
        }

        public void LogMove(CreatedMove move)
        {
            boardArray[move.yAxis, move.xAxis] = move.plyrIdentity;
        }

        public bool CheckForTie()
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
                if (CheckRowForWin(i) >= 3 || CheckRowForWin(i) <= -3)
                {
                    return true;
                }
                if (CheckColumnForWin(i) >= 3 || CheckColumnForWin(i) <= -3)
                {
                    return true;
                }
            }
            if (CheckSlashForWin() >= 3 || CheckSlashForWin() <= -3)
            {
                return true;
            }
            if (CheckBackSlashForWin() >= 3 || CheckBackSlashForWin() <= -3)
            {
                return true;
            }
            return false;
        }

        public int CheckRowForWin(int row)
        {
            int tally = 0;
            for (int xAxisCounter = 0; xAxisCounter < 3; xAxisCounter++)
            {
                if (boardArray[row, xAxisCounter] == 'X')
                {
                    tally++;
                }
                else if (boardArray[row, xAxisCounter] == 'O')
                {
                    tally--;
                }
            }
            return tally;
        }

        public int CheckColumnForWin(int column)
        {
            int tally = 0;
            for (int yAxisCounter = 0; yAxisCounter < 3; yAxisCounter++)
            {
                if (boardArray[yAxisCounter, column] == 'X')
                {
                    tally++;
                }
                else if (boardArray[yAxisCounter, column] == 'O')
                {
                    tally--;
                }
            }
            return tally;
        }

        public int CheckSlashForWin()
        {
            int tally = 0;
            int xAxisIndex = 0;
            int yAxisIndex = 2;
            while (xAxisIndex < 3)
            {
                if (boardArray[yAxisIndex, xAxisIndex] == 'X')
                {
                    tally++;
                }
                else if (boardArray[yAxisIndex, xAxisIndex] == 'O')
                {
                    tally--;
                }
                xAxisIndex++;
                yAxisIndex--;
            }
            return tally;
        }

        public int CheckBackSlashForWin()
        {
            int tally = 0;
            int xAxisIndex = 0;
            int yAxisIndex = 0;
            while (xAxisIndex < 3)
            {
                if (boardArray[yAxisIndex, xAxisIndex] == 'X')
                {
                    tally++;
                }
                else if (boardArray[yAxisIndex, xAxisIndex] == 'O')
                {
                    tally--;
                }
                xAxisIndex++;
                yAxisIndex++;
            }
            return tally;
        }

    }
}
