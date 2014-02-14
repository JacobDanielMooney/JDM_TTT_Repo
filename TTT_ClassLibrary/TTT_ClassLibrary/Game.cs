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
        public BoardChecker checker;
        public ComputerAI XAI;
        public ComputerAI OAI;

        public Game()
        {
            board = new BoardManager();
            checker = new BoardChecker();
        }

        public Game(Player one, Player two)
        {
            xPlayer = one;
            if (xPlayer.identity != 'X')
            {
                xPlayer.identity = 'X';
            }
            if (xPlayer.GetType() == typeof(ComputerPlayer))
            {
                XAI = new ComputerAI('O', 'X');
            }
            oPlayer = two;
            if (oPlayer.identity != 'O')
            {
                oPlayer.identity = 'O';
            }
            if (oPlayer.GetType() == typeof(ComputerPlayer))
            {
                OAI = new ComputerAI('X', 'O');
            }
            board = new BoardManager();
            checker = new BoardChecker();
        }

        public Game(Player one, Player two, BoardChecker ourChecker, BoardManager ourManager, int boardSize)
        {
            xPlayer = one;
            if (xPlayer.identity != 'X')
            {
                xPlayer.identity = 'X';
            }
            if (xPlayer.GetType() == typeof(ComputerPlayer))
            {
                XAI = new ComputerAI('O', 'X');
            }
            oPlayer = two;
            if (oPlayer.identity != 'O')
            {
                oPlayer.identity = 'O';
            }
            if (oPlayer.GetType() == typeof(ComputerPlayer))
            {
                OAI = new ComputerAI('X', 'O');
            }
            board = ourManager;
            checker = ourChecker;
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

        public CreatedMove XPlayerMove(int xAxisValue, int yAxisValue)
        {
            return xPlayer.MakeMove(xAxisValue, yAxisValue);
        }

        public CreatedMove OPlayerMove(int xAxisValue, int yAxisValue)
        {
            return oPlayer.MakeMove(xAxisValue, yAxisValue);
        }

        public CreatedMove XAIRandomMove()
        {
            return XAI.GetRandomMove(GetBoard());
        }

        public CreatedMove OAIRandomMove()
        {
            return OAI.GetRandomMove(GetBoard());
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
