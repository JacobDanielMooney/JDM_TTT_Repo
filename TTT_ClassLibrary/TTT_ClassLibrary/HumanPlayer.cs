using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TTT_ClassLibrary
{
    public class HumanPlayer : Player
    {
        public HumanPlayer()
        {
            identity = 'X';
        }

        public HumanPlayer(char playerIdentity)
        {
            if (playerIdentity.ToString().ToUpper() == "O")
            {
                identity = 'O';
            }
            else
            {
                identity = 'X';
            }
        }

        public override Tuple<int,int> MakeMove(char[,] boardState)
        {
            return null;
        }
    }
}
