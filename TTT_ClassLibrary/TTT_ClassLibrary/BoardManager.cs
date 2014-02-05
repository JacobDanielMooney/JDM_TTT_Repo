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

        public void LogMove(CreatedMove move)
        {
            boardArray[move.yAxis, move.xAxis] = move.plyrIdentity;
        }
    }
}
