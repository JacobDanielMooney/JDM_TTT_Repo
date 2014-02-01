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
            name = "hmnPlayer";
        }

        public HumanPlayer(string plyrName)
        {
            name = plyrName;
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
            name = "hmnPlayer";
        }

        public HumanPlayer(char playerIdentity, string plyrName)
        {
            if (playerIdentity.ToString().ToUpper() == "O")
            {
                identity = 'O';
            }
            else
            {
                identity = 'X';
            }
            name = plyrName;
        }

        public override CreatedMove MakeMove(int xValue, int yValue)
        {
            return new CreatedMove(xValue, yValue, identity);
        }

        public override string AnnounceWinner()
        {
            string result = String.Format("{0} the Human won!", name);
            return result;
        }
    }
}
