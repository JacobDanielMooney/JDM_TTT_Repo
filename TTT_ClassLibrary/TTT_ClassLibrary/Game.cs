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

        public Game(Player one, Player two, BoardManager ourManager)
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

        public Tuple<int,int> ForceMove()
        {
            if (board.movesMade % 2 == 0)
            {
                HumanPlayer inactivePlayer = (HumanPlayer)xPlayer;
                return inactivePlayer.ForceMove(board.boardArray);
            }
            else
            {
                HumanPlayer inactivePlayer = (HumanPlayer)oPlayer;
                return inactivePlayer.ForceMove(board.boardArray);
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

        public void ResetGame()
        {
            xPlayer = null;
            oPlayer = null;
            board.ResetBoard();
        }

        public char[,] GetBoard()
        {
            return board.boardArray;
        }

        public Tuple<int,int> NextMove()
        {
            if (board.movesMade % 2 == 0)
            {
                return xPlayer.MakeMove(board.boardArray);
            }
            else
            {
                return oPlayer.MakeMove(board.boardArray);
            }
        }

        public Tuple<int,int> LogMove(Tuple<int, int> coordinates)
        {
            return board.LogMove(coordinates);
        }

        public bool IsMoveValid(Tuple<int,int> coordinates)
        {
            return board.IsMoveValid(coordinates);
        }

        public bool CheckForWin()
        {
            return board.CheckForWin();
        }

        public bool CheckForTie()
        {
            return board.CheckForTie();
        }
    }
}
