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
                    game = new Game(new HumanPlayer(), new ComputerPlayer());
                    break;
                case "computers":
                    game = new Game(new HumanPlayer(), new ComputerPlayer());
                    break;
            }
            return game;
        }
    }
}
