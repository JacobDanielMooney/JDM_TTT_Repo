using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TTT_ClassLibrary
{
    public class GameManager
    {
        public Player xPlayer;
        public Player oPlayer;
        public BoardManager board;
        public BoardChecker checker;

        public GameManager()
        {
            board = new BoardManager();
            checker = new BoardChecker();
        }

        public GameManager(Player one, Player two, int boardSize)
        {
            xPlayer = one;
            oPlayer = two;
            board = new BoardManager();
            checker = new BoardChecker();
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
    }
}
