using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TTT_ClassLibrary
{
    public class Game
    {
        public Player xPlayer;
        public Player oPlayer;
        public BoardManager board;

        public Game()
        {
            board = new BoardManager();
        }

        public Game(Player one, Player two)
        {
            xPlayer = one;
            if (xPlayer.identity != 'X')
            {
                xPlayer.identity = 'X';
            }
            oPlayer = two;
            if (oPlayer.identity != 'O')
            {
                oPlayer.identity = 'O';
            }
            board = new BoardManager();
        }

        public Game(Player one, Player two, BoardManager ourManager, int boardSize)
        {
            xPlayer = one;
            if (xPlayer.identity != 'X')
            {
                xPlayer.identity = 'X';
            }
            oPlayer = two;
            if (oPlayer.identity != 'O')
            {
                oPlayer.identity = 'O';
            }
            board = ourManager;
            board.CreateNewBoard(boardSize);
        }

        public void AddPlayer(Player playerToAdd)
        {
            if (playerToAdd.identity == 'X' && xPlayer == null)
            {
                xPlayer = playerToAdd;
            }
            if (playerToAdd.identity == 'O' && oPlayer == null)
            {
                oPlayer = playerToAdd;
            }
        }

        public void RewritePlayer(Player playerToAdd)
        {
            if (playerToAdd.identity == 'X')
            {
                xPlayer = playerToAdd;
            }
            if (playerToAdd.identity == 'O')
            {
                oPlayer = playerToAdd;
            }
        }

        public void ResetGame(int newBoardSize)
        {
            board.CreateNewBoard(newBoardSize);
            xPlayer = null;
            oPlayer = null;
        }

        public char[,] GetBoard()
        {
            return board.boardArray;
        }

        public CreatedMove LogMove(CreatedMove move)
        {
            return board.LogMove(move);
        }

        public bool IsMoveValid(CreatedMove moveToCheck)
        {
            return board.IsMoveValid(moveToCheck);
        }
    }
}
