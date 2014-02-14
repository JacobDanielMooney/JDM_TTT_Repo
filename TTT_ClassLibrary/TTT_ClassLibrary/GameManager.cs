using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TTT_ClassLibrary
{
    public class GameManager
    {
        Game game;

        public GameManager()
        {

        }

        public Game MakeGame()
        {
            game = new Game();
            return game;
        }
    }
}
