using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TTT_ClassLibrary
{
    public class GameManager
    {
        public Game game;
        public PresentationManager presenter;

        public GameManager()
        {
            presenter = new PresentationManager();
        }

        public GameManager(PresentationManager pm)
        {
            presenter = pm;
        }

        public Game MakeGame()
        {
            game = new Game();
            return game;
        }

        public Game MakeGame(string parameters)
        {
            switch (parameters)
            {
                case "human":
                    game = new Game(new HumanPlayer(), new HumanPlayer());
                    break;
                case "computer":
                    if (presenter.HumanGoesFirst())
                    {
                        game = new Game(new HumanPlayer(), new ComputerPlayer());
                    }
                    else
                    {
                        game = new Game(new ComputerPlayer(), new HumanPlayer());
                    }
                    break;
                case "computers":
                    game = new Game(new ComputerPlayer(), new ComputerPlayer());
                    break;
            }
            return game;
        }

        public void StartGame()
        {
            MakeGame(presenter.WelcomeAndAskForGameParams());
            presenter.Send("The board currently looks like this:");
            presenter.PrintBoard(game.GetBoard());
            while (game.CheckForWin() == '\0' && game.CheckForTie() != true)
            {
                Tuple<int, int> coordinatesToLog = GetNextTuple();
                int loopCount = 0;
                int loopLimit = 3;
                while (game.IsMoveValid(coordinatesToLog) != true)
                {
                    loopCount++;
                    if (loopCount >= loopLimit)
                    {
                        presenter.Send("Lets just give you a random move...");
                        coordinatesToLog = game.ForceMove();
                    }
                    else
                    {
                        presenter.Send("Sorry - that square is already taken.");
                        coordinatesToLog = GetNextTuple();
                    }
                }
                LogMove(coordinatesToLog);
                presenter.Send("The Board now looks like this:");
                presenter.PrintBoard(game.GetBoard());
            }
            ReportGameEnd();
            presenter.IO.Input();
            if (presenter.PlayAgain())
            {
                StartGame();
            }
        }

        public void ReportGameEnd()
        {
            if (game.CheckForWin() == 'X')
            {
                presenter.Send("X's Win!");
            }
            else if(game.CheckForWin() == 'O')
            {
                presenter.Send("O's Win!");
            }
            else if (game.CheckForTie())
            {
                presenter.Send("X's and O's have tied!");
            }
        }

        public Tuple<int, int> GetNextTuple()
        {
            if (game.GetActivePlayerID() == 'X')
            {
                presenter.Send("It is Player 1 (X's) turn.");
                presenter.IO.Input();
            }
            else
            {
                presenter.Send("It is Player 2 (O's) turn.");
                presenter.IO.Input();
            }
            if (game.NextMove() == null)
            {
                return presenter.PromptCoordinates();
            }
            else
            {
                return game.NextMove();
            }
        }

        public void LogMove(Tuple<int, int> coordinates)
        {
            game.LogMove(coordinates);
        }
    }
}
