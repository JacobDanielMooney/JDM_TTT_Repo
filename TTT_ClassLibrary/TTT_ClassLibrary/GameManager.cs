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
            while (game.CheckForWin() != true && game.CheckForTie() != true)
            {
                Tuple<int, int> coordinatesToLog = GetNextTuple();
                int loopCount = 0;
                int loopLimit = 3;
                while (game.IsMoveValid(coordinatesToLog) != true)
                {
                    presenter.Send("Sorry - that square is already taken.");
                    coordinatesToLog = GetNextTuple();
                    loopCount++;
                    if (loopCount >= loopLimit)
                    {
                        presenter.Send("Lets just give you a random move...");
                        coordinatesToLog = game.ForceMove();
                    }
                }
                LogMove(coordinatesToLog);
                presenter.Send("The Board now looks like this:");
                presenter.PrintBoard(game.GetBoard());
            }
            presenter.Send("There has been a win/tie!");
            Console.ReadLine();
        }

        public Tuple<int, int> GetNextTuple()
        {
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
