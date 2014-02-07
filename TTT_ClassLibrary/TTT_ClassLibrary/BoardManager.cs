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
    }
}
