using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TTT_ClassLibrary
{
    public class BoardChecker
    {

        public bool CheckForTie(char[,] boardArray)
        {
            if (CheckForWin(boardArray) == true)
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

        public bool CheckForWin(char[,] boardArray)
        {
            for (int i = 0; i < 3; i++)
            {
                if (CheckRowForWin(i, boardArray, 'X') >= 3 ||
                    CheckRowForWin(i, boardArray, 'O') >= 3 ||
                    CheckColumnForWin(i, boardArray, 'X') >= 3 ||
                    CheckColumnForWin(i, boardArray, 'O') >= 3)
                {
                    return true;
                }
            }
            if (CheckSlashForWin(boardArray, 'X') >= 3 || 
                CheckSlashForWin(boardArray, 'O') >= 3)
            {
                return true;
            }
            if (CheckBackSlashForWin(boardArray, 'X') >= 3 ||
                CheckBackSlashForWin(boardArray, 'O') >= 3)
            {
                return true;
            }
            return false;
        }

        public int CheckRowForWin(int row, char[,] boardArray, char checkFor)
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

        public int CheckColumnForWin(int column, char[,] boardArray, char checkFor)
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

        public int CheckSlashForWin(char[,] boardArray, char checkFor)
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

        public int CheckBackSlashForWin(char[,] boardArray, char checkFor)
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
